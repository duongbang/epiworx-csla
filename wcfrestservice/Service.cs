using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.ServiceModel.Activation;
using System.ServiceModel.Web;
using System.Net;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Data;
using Epiworx.WcfRestService.Data;

namespace Epiworx.WcfRestService
{
    [ServiceContract]
    [AspNetCompatibilityRequirements(RequirementsMode = AspNetCompatibilityRequirementsMode.Allowed)]
    [ServiceBehavior(InstanceContextMode = InstanceContextMode.PerCall)]
    public class Service
    {
        [WebGet(UriTemplate = "authorize/{username}/{password}")]
        public TokenData Authorize(string username, string password)
        {
            BusinessPrincipal.Login(username, password);

            var result = new TokenData();
            var token = new Token();
            var tokenRepository = new TokenRepository();

            token.Key = Guid.NewGuid().ToString().ToUpper();
            token.UserName = username;
            token.CreatedDate = DateTime.Now;
            token.ExpirationDate = DateTime.Now.AddMinutes(30);

            tokenRepository.AddToken(token);

            result.Key = token.Key;

            return result;
        }

        [WebGet(UriTemplate = "feed?maximumRecords={maximumRecords}&token={token}")]
        public List<FeedData> GetFeed(string maximumRecords, string token)
        {
            this.ValidateToken(token);

            this.Login(token);

            var feeds = FeedRepository.FeedFetchInfoList(int.Parse(maximumRecords));

            var result = feeds.Select(row => new FeedData(row))
                .ToList();

            this.Logout();

            return result;
        }

        [WebGet(UriTemplate = "project/{id}?token={token}")]
        public ProjectData GetProject(string id, string token)
        {
            this.ValidateToken(token);

            this.Login(token);

            var result = new ProjectData(
                ProjectRepository.ProjectFetch(int.Parse(id)));

            this.Logout();

            return result;
        }

        [WebGet(UriTemplate = "project?token={token}")]
        public List<ProjectData> GetProjects(string token)
        {
            this.ValidateToken(token);

            this.Login(token);

            var projects = ProjectRepository.ProjectFetchInfoList(
                new ProjectDataCriteria());

            var timelines = TimelineRepository.TimelineFetchInfoList(
                 projects.Select(row => row.ProjectId).Distinct().ToArray(), SourceType.Project);

            var result = projects.Select(row => new ProjectData(row))
                .ToList();

            foreach (var project in result)
            {
                project.Timelines = timelines
                    .Where(row => row.SourceId == project.ProjectId)
                    .OrderByDescending(row => row.CreatedDate)
                    .Select(row => new TimelineData(row))
                    .ToList();
            }

            this.Logout();

            return result;
        }

        [WebGet(UriTemplate = "user/?token={token}")]
        public UserData GetMe(string token)
        {
            this.ValidateToken(token);

            this.Login(token);

            var result = new UserData(
                UserRepository.UserFetch());

            result.Timelines = TimelineRepository.TimelineFetchInfoList(result.UserId, SourceType.User)
                .OrderByDescending(timeline => timeline.CreatedDate)
                .Select(timeline => new TimelineData(timeline)).
                ToList();

            this.Logout();

            return result;
        }

        [WebGet(UriTemplate = "user/{id}?token={token}")]
        public UserData GetUser(string id, string token)
        {
            this.ValidateToken(token);

            this.Login(token);

            var result = new UserData(
                UserRepository.UserFetch(int.Parse(id)));

            this.Logout();

            return result;
        }

        [WebGet(UriTemplate = "user?token={token}")]
        public List<UserData> GetUsers(string token)
        {
            this.ValidateToken(token);

            this.Login(token);

            var users = UserRepository.UserFetchInfoList(
                new UserDataCriteria
                    {
                        IsActive = true,
                        IsArchived = false
                    });

            var timelines = TimelineRepository.TimelineFetchInfoList(
                 users.Select(row => row.UserId).Distinct().ToArray(), SourceType.User);

            var result = users.Select(row => new UserData(row))
                .ToList();

            foreach (var user in result)
            {
                user.Timelines = timelines
                    .Where(row => row.SourceId == user.UserId)
                    .OrderByDescending(row => row.CreatedDate)
                    .Select(row => new TimelineData(row))
                    .ToList();
            }

            this.Logout();

            return result;
        }

        private void ValidateToken(string key)
        {
            var tokenRepository = new TokenRepository();
            var token = tokenRepository.GetToken(key);

            if (token == null)
            {
                throw new WebFaultException<string>(
                    string.Format("The token '{0}' is no longer valid.", key), HttpStatusCode.BadRequest);
            }

            if (token.CreatedDate.AddDays(1) <= DateTime.Now
                || DateTime.Now >= token.ExpirationDate)
            {
                tokenRepository.DeleteToken(token);
                throw new WebFaultException<string>(
                    string.Format("The token '{0}' has expired.", key), HttpStatusCode.BadRequest);
            }

            token.ExpirationDate = DateTime.Now.AddMinutes(30);

            tokenRepository.UpdateToken(token);
        }

        private void Login(string key)
        {
            var tokenRepository = new TokenRepository();
            var token = tokenRepository.GetToken(key);

            BusinessPrincipal.LoadPrincipal(token.UserName);
        }

        private void Logout()
        {
            BusinessPrincipal.Logout();
        }
    }
}
