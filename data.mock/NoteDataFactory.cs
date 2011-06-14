using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Epiworx.Data.Mock
{
    public class NoteDataFactory : INoteDataFactory
    {
        public NoteData Fetch(NoteDataCriteria criteria)
        {
            var data = MockDb.Notes
                .Where(row => row.NoteId == criteria.NoteId)
                .SingleOrDefault();

            data = this.Fetch(data);

            return data;
        }

        public NoteData Fetch(NoteData data)
        {
            data.Source = MockDb.Sources
               .Where(row => row.SourceId == data.SourceId)
               .SingleOrDefault();

            data.SourceType = MockDb.SourceTypes
               .Where(row => row.SourceTypeId == data.SourceTypeId)
               .SingleOrDefault();

            data.CreatedByUser = MockDb.Users
                .Where(row => row.UserId == data.CreatedBy)
                .SingleOrDefault();

            data.ModifiedByUser = MockDb.Users
                .Where(row => row.UserId == data.ModifiedBy)
                .SingleOrDefault();

            return data;
        }

        public NoteData[] FetchInfoList(NoteDataCriteria criteria)
        {
            var query = MockDb.Notes
                .AsQueryable();

            var notes = query.AsQueryable();

            var data = new List<NoteData>();

            foreach (var note in notes)
            {
                data.Add(this.Fetch(note));
            }

            return data.ToArray();
        }

        public NoteData Create()
        {
            return new NoteData();
        }

        public NoteData Update(NoteData data)
        {
            var note = MockDb.Notes
                .Where(row => row.NoteId == data.NoteId)
                .SingleOrDefault();

            Csla.Data.DataMapper.Map(data, note);

            return data;
        }

        public NoteData Insert(NoteData data)
        {
            if (MockDb.Notes.Count() == 0)
            {
                data.NoteId = 1;
            }
            else
            {
                data.NoteId = MockDb.Notes.Select(row => row.NoteId).Max() + 1;
            }

            MockDb.Notes.Add(data);

            return data;
        }

        public void Delete(NoteDataCriteria criteria)
        {
            var data = MockDb.Notes
                .Where(row => row.NoteId == criteria.NoteId)
                .SingleOrDefault();

            MockDb.Notes.Remove(data);
        }
    }
}
