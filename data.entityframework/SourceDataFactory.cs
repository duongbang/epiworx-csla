using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class SourceDataFactory : ISourceDataFactory
    {
        public SourceData Fetch(SourceDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var source = this.Fetch(ctx, criteria)
                    .Single();

                var sourceData = new SourceData();

                this.Fetch(source, sourceData);

                return sourceData;
            }
        }

        public SourceData[] FetchInfoList(SourceDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var sources = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var sourceDataList = new List<SourceData>();

                foreach (var source in sources)
                {
                    var sourceData = new SourceData();

                    this.Fetch(source, sourceData);

                    sourceDataList.Add(sourceData);
                }

                return sourceDataList.ToArray();
            }
        }

        public SourceData[] FetchLookupInfoList(SourceDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var sources = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var sourceDataList = new List<SourceData>();

                foreach (var source in sources)
                {
                    var sourceData = new SourceData();

                    this.Fetch(source, sourceData);

                    sourceDataList.Add(sourceData);
                }

                return sourceDataList.ToArray();
            }
        }

        public SourceData Create()
        {
            return new SourceData();
        }

        public SourceData Update(SourceData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var source =
                    new Source
                    {
                        SourceId = data.SourceId,
                        SourceTypeId = data.SourceTypeId
                    };

                ctx.ObjectContext.Sources.Attach(source);

                Csla.Data.DataMapper.Map(data, source);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public SourceData Insert(SourceData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var source = new Source();

                Csla.Data.DataMapper.Map(data, source);

                ctx.ObjectContext.AddToSources(source);

                ctx.ObjectContext.SaveChanges();

                data.SourceId = source.SourceId;

                return data;
            }
        }

        public void Delete(SourceDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var source = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Sources.DeleteObject(source);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Source source, SourceData sourceData)
        {
            Csla.Data.DataMapper.Map(source, sourceData);
        }

        private IQueryable<Source> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             SourceDataCriteria criteria)
        {
            IQueryable<Source> query = ctx.ObjectContext.Sources
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.SourceId != null)
            {
                query = query.Where(row => row.SourceId == criteria.SourceId);
            }

            if (criteria.SourceTypeId != null)
            {
                query = query.Where(row => row.SourceTypeId == criteria.SourceTypeId);
            }

            if (criteria.Name != null)
            {
                query = query.Where(row => row.Name == criteria.Name);
            }

            if (criteria.ModifiedDate != null && criteria.ModifiedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.ModifiedDate >= criteria.ModifiedDate.DateFrom);
            }

            if (criteria.ModifiedDate != null && criteria.ModifiedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.ModifiedDate <= criteria.ModifiedDate.DateTo);
            }

            if (criteria.CreatedDate != null && criteria.CreatedDate.DateFrom.Date != DateTime.MinValue.Date)
            {
                query = query.Where(row => row.CreatedDate >= criteria.CreatedDate.DateFrom);
            }

            if (criteria.CreatedDate != null && criteria.CreatedDate.DateTo.Date != DateTime.MaxValue.Date)
            {
                query = query.Where(row => row.CreatedDate <= criteria.CreatedDate.DateTo);
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
