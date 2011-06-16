using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;

namespace Epiworx.Test.Helpers
{
    public class NoteTestHelper
    {
        public static Note NoteAdd()
        {
            var note = NoteTestHelper.NoteNew();

            note = NoteRepository.NoteSave(note);

            return note;
        }

        public static Note NoteNew()
        {
            var note = NoteRepository.NoteNew();

            note.Body = DataHelper.RandomString(1000);

            return note;
        }
    }
}

