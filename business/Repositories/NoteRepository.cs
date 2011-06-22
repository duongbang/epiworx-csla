using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class NoteRepository
    {
        public static Note NoteFetch(int noteId)
        {
            return Note.FetchNote(
                new NoteDataCriteria
                {
                    NoteId = noteId
                });
        }

        public static NoteInfoList NoteFetchInfoList(int sourceId, SourceType sourceType)
        {
            return
                NoteRepository.NoteFetchInfoList(
                    new NoteDataCriteria
                        {
                            SourceId = sourceId,
                            SourceTypeId = (int)sourceType
                        });
        }

        public static NoteInfoList NoteFetchInfoList(NoteDataCriteria criteria)
        {
            return NoteInfoList.FetchNoteInfoList(criteria);
        }

        public static Note NoteSave(Note note)
        {
            if (!note.IsValid)
            {
                return note;
            }

            Note result;

            if (note.IsNew)
            {
                result = NoteRepository.NoteInsert(note);
            }
            else
            {
                result = NoteRepository.NoteUpdate(note);
            }

            return result;
        }

        public static Note NoteInsert(Note note)
        {
            note = note.Save();

            SourceRepository.SourceAdd(note.NoteId, SourceType.Note, note.Body);

            return note;
        }

        public static Note NoteUpdate(Note note)
        {
            note = note.Save();

            SourceRepository.SourceUpdate(note.NoteId, SourceType.Note, note.Body);

            return note;
        }

        public static Note NoteNew()
        {
            var note = Note.NewNote();

            return note;
        }

        public static Note NoteNew(int sourceId, SourceType sourceType)
        {
            var note = Note.NewNote();

            note.SourceId = sourceId;
            note.SourceTypeId = (int)sourceType;

            return note;
        }

        public static bool NoteDelete(Note note)
        {
            Note.DeleteNote(
                new NoteDataCriteria
                {
                    NoteId = note.NoteId
                });

            SourceRepository.SourceDelete(note.NoteId, SourceType.Note);

            return true;
        }

        public static bool NoteDelete(int noteId)
        {
            return NoteRepository.NoteDelete(
                NoteRepository.NoteFetch(noteId));
        }
    }
}
