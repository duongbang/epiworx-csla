using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Security;
using Epiworx.Data;
using Epiworx.Test.Helpers;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Epiworx.Test
{
    [TestClass]
    public class NoteTest
    {
        [TestInitialize]
        public void MyTestInitialize()
        {
            BusinessPrincipal.Login("Administrator", "master");
        }

        [TestCleanup]
        public void MyTestCleanup()
        {
            BusinessPrincipal.Logout();
        }

        [TestMethod]
        public void Note_Create()
        {
            var note = NoteRepository.NoteNew();

            Assert.IsTrue(note.IsNew, "IsNew should be true");
            Assert.IsTrue(note.IsDirty, "IsDirty should be true");
            Assert.IsFalse(note.IsValid, "IsValid should be false");
            Assert.IsTrue(note.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(note.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(note, DbType.String, "Body"),
               "Body should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(note, DbType.Int32, "SourceId"),
               "SourceId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(note, DbType.Int32, "SourceTypeId"),
               "SourceTypeId should be required");
        }

        [TestMethod]
        public void Note_Fetch()
        {
            var note = NoteTestHelper.NoteNew();

            note = NoteRepository.NoteSave(note);

            note = NoteRepository.NoteFetch(note.NoteId);

            Assert.IsTrue(note != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Note_Fetch_Info_List()
        {
            NoteTestHelper.NoteAdd();
            NoteTestHelper.NoteAdd();

            var notes = NoteRepository.NoteFetchInfoList(new NoteDataCriteria());

            Assert.IsTrue(notes.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Note_Add()
        {
            var note = NoteTestHelper.NoteNew();

            Assert.IsTrue(note.IsValid, "IsValid should be true");

            note = NoteRepository.NoteSave(note);

            Assert.IsTrue(note.NoteId != 0, "NoteId should be a non-zero value");

            NoteRepository.NoteFetch(note.NoteId);
        }

        [TestMethod]
        public void Note_Edit()
        {
            var note = NoteTestHelper.NoteNew();

            var name = note.Body;

            Assert.IsTrue(note.IsValid, "IsValid should be true");

            note = NoteRepository.NoteSave(note);

            note = NoteRepository.NoteFetch(note.NoteId);

            note.Body = DataHelper.RandomString(20);

            note = NoteRepository.NoteSave(note);

            note = NoteRepository.NoteFetch(note.NoteId);

            Assert.IsTrue(note.Body != name, "Body should have different value");
        }

        [TestMethod]
        public void Note_Delete()
        {
            var note = NoteTestHelper.NoteNew();

            Assert.IsTrue(note.IsValid, "IsValid should be true");

            note = NoteRepository.NoteSave(note);

            note = NoteRepository.NoteFetch(note.NoteId);

            NoteRepository.NoteDelete(note.NoteId);

            try
            {
                NoteRepository.NoteFetch(note.NoteId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}