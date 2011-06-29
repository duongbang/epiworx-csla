using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class WeekDataFactory : IWeekDataFactory
    {
        public WeekData Fetch(WeekDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var week = this.Fetch(ctx, criteria)
                    .Single();

                var weekData = new WeekData();

                this.Fetch(week, weekData);

                return weekData;
            }
        }

        public WeekData[] FetchInfoList(WeekDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var weeks = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var weekDataList = new List<WeekData>();

                foreach (var week in weeks)
                {
                    var weekData = new WeekData();

                    this.Fetch(week, weekData);

                    weekDataList.Add(weekData);
                }

                return weekDataList.ToArray();
            }
        }

        public WeekData[] FetchLookupInfoList(WeekDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var weeks = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var weekDataList = new List<WeekData>();

                foreach (var week in weeks)
                {
                    var weekData = new WeekData();

                    this.Fetch(week, weekData);

                    weekDataList.Add(weekData);
                }

                return weekDataList.ToArray();
            }
        }

        public WeekData Create()
        {
            return new WeekData();
        }

        public WeekData Update(WeekData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var week =
                    new Week
                    {
                        WeekId = data.WeekId
                    };

                ctx.ObjectContext.Weeks.Attach(week);

                DataMapper.Map(data, week);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public WeekData Insert(WeekData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var week = new Week();

                DataMapper.Map(data, week);

                ctx.ObjectContext.AddToWeeks(week);

                ctx.ObjectContext.SaveChanges();

                data.WeekId = week.WeekId;

                return data;
            }
        }

        public void Delete(WeekDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var week = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Weeks.DeleteObject(week);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Week week, WeekData weekData)
        {
            DataMapper.Map(week, weekData);

            weekData.CreatedByUser = new UserData();
            DataMapper.Map(week.CreatedByUser, weekData.CreatedByUser);

            weekData.ModifiedByUser = new UserData();
            DataMapper.Map(week.ModifiedByUser, weekData.ModifiedByUser);
        }

        private IQueryable<Week> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             WeekDataCriteria criteria)
        {
            IQueryable<Week> query = ctx.ObjectContext.Weeks;

            if (criteria.WeekId != null)
            {
                query = query.Where(row => row.WeekId == criteria.WeekId);
            }

            if (criteria.EndDate != null
                && criteria.EndDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.EndDate >= criteria.EndDate.DateFrom);
            }

            if (criteria.EndDate != null
                && (criteria.EndDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.EndDate <= criteria.EndDate.DateTo);
            }

            if (criteria.Period != null)
            {
                query = query.Where(row => row.Period == criteria.Period);
            }

            if (criteria.StartDate != null
                && criteria.StartDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.StartDate >= criteria.StartDate.DateFrom);
            }

            if (criteria.StartDate != null
                && (criteria.StartDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.StartDate <= criteria.StartDate.DateTo);
            }

            if (criteria.Year != null)
            {
                query = query.Where(row => row.Year == criteria.Year);
            }

            if (criteria.CreatedBy != null)
            {
                query = query.Where(row => row.CreatedBy == criteria.CreatedBy);
            }

            if (criteria.CreatedDate != null
                && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null
                && (criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
            }

            if (criteria.ModifiedBy != null)
            {
                query = query.Where(row => row.ModifiedBy == criteria.ModifiedBy);
            }

            if (criteria.ModifiedDate != null
                && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null
                && (criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date))
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.SortBy != null)
            {
                query = query.OrderBy(string.Format(
                    "{0} {1}",
                    criteria.SortBy,
                    criteria.SortOrder == ListSortDirection.Ascending ? "ASC" : "DESC"));
            }

            if (criteria.SkipRecords != null)
            {
                query = query.Skip(criteria.SkipRecords.Value);
            }

            if (criteria.MaximumRecords != null)
            {
                query = query.Take(criteria.MaximumRecords.Value);
            }

            return query;
        }
    }
}
