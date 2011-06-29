using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Linq.Dynamic;
using System.Text;

namespace Epiworx.Data.EntityFramework
{
    public class NoteDataFactory : INoteDataFactory
    {
        public NoteData Fetch(NoteDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var note = this.Fetch(ctx, criteria)
                    .Single();

                var noteData = new NoteData();

                this.Fetch(note, noteData);

                return noteData;
            }
        }

        public NoteData[] FetchInfoList(NoteDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var notes = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var noteDataList = new List<NoteData>();

                foreach (var note in notes)
                {
                    var noteData = new NoteData();

                    this.Fetch(note, noteData);

                    noteDataList.Add(noteData);
                }

                return noteDataList.ToArray();
            }
        }

        public NoteData[] FetchLookupInfoList(NoteDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var notes = this.Fetch(ctx, criteria)
                    .AsEnumerable();

                var noteDataList = new List<NoteData>();

                foreach (var note in notes)
                {
                    var noteData = new NoteData();

                    this.Fetch(note, noteData);

                    noteDataList.Add(noteData);
                }

                return noteDataList.ToArray();
            }
        }

        public NoteData Create()
        {
            return new NoteData();
        }

        public NoteData Update(NoteData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                         .GetManager(Database.ApplicationConnection, false))
            {
                var note =
                    new Note
                    {
                        NoteId = data.NoteId
                    };

                ctx.ObjectContext.Notes.Attach(note);

                DataMapper.Map(data, note);

                ctx.ObjectContext.SaveChanges();

                return data;
            }
        }

        public NoteData Insert(NoteData data)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                           .GetManager(Database.ApplicationConnection, false))
            {
                var note = new Note();

                DataMapper.Map(data, note);

                ctx.ObjectContext.AddToNotes(note);

                ctx.ObjectContext.SaveChanges();

                data.NoteId = note.NoteId;

                return data;
            }
        }

        public void Delete(NoteDataCriteria criteria)
        {
            using (var ctx = Csla.Data.ObjectContextManager<ApplicationEntities>
                          .GetManager(Database.ApplicationConnection, false))
            {
                var note = this.Fetch(ctx, criteria)
                    .Single();

                ctx.ObjectContext.Notes.DeleteObject(note);

                ctx.ObjectContext.SaveChanges();
            }
        }

        private void Fetch(Note note, NoteData noteData)
        {
            DataMapper.Map(note, noteData);

            noteData.Source = new SourceData();
            DataMapper.Map(note.Source, noteData.Source);

            noteData.CreatedByUser = new UserData();
            DataMapper.Map(note.CreatedByUser, noteData.CreatedByUser);

            noteData.ModifiedByUser = new UserData();
            DataMapper.Map(note.ModifiedByUser, noteData.ModifiedByUser);
        }

        private IQueryable<Note> Fetch(
             Csla.Data.ObjectContextManager<ApplicationEntities> ctx,
             NoteDataCriteria criteria)
        {
            IQueryable<Note> query = ctx.ObjectContext.Notes
                .Include("Source")
                .Include("CreatedByUser")
                .Include("ModifiedByUser");

            if (criteria.NoteId != null)
            {
                query = query.Where(row => row.NoteId == criteria.NoteId);
            }

            if (criteria.Body != null)
            {
                query = query.Where(row => row.Body == criteria.Body);
            }

            if (criteria.IsArchived != null)
            {
                query = query.Where(row => row.IsArchived == criteria.IsArchived);
            }

            if (criteria.SourceId != null)
            {
                query = query.Where(row => criteria.SourceId.Contains(row.SourceId));
            }

            if (criteria.SourceTypeId != null)
            {
                query = query.Where(row => row.SourceTypeId == criteria.SourceTypeId);
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

            if (criteria.Text != null)
            {
                query = query.Where(row => row.Body.Contains(criteria.Text));
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
