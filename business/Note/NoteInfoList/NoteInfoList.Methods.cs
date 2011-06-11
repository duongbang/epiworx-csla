using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class NoteInfoList
    {
        internal static NoteInfoList FetchNoteInfoList(NoteDataCriteria criteria)
        {
            return Csla.DataPortal.Fetch<NoteInfoList>(criteria);
        }
    }
}
