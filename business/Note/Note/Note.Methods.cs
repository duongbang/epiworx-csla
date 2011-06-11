using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Security.Helpers;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class Note
    {
        public override string ToString()
        {
			return string.Format("{0}", this.Body);
        }

        public NoteInfo ToNoteInfo()
        {
            var result = new NoteInfo();

            Csla.Data.DataMapper.Map(this, result);

            return result;
        }

        protected override void PropertyHasChanged(Csla.Core.IPropertyInfo property)
        {
            base.PropertyHasChanged(property);

            switch (property.Name)
            {
                default:
                    break;
            }
        }

        internal static Note NewNote()
        {
            return Csla.DataPortal.Create<Note>();
        }

        internal static Note FetchNote(NoteDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<Note>(criteria);
        }

        internal static Note FetchNote(NoteData data)
        {
            var result = new Note();

            result.Fetch(data);
            result.MarkOld();

            return result;
        }

        internal static void DeleteNote(NoteDataCriteria criteria)
        {
            Csla.DataPortal.Delete<Note>(criteria);
        }
    }
}
