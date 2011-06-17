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
    public class AttachmentTest
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
        public void Attachment_Create()
        {
            var attachment = AttachmentRepository.AttachmentNew(0, SourceType.None);

            Assert.IsTrue(attachment.IsNew, "IsNew should be true");
            Assert.IsTrue(attachment.IsDirty, "IsDirty should be true");
            Assert.IsFalse(attachment.IsValid, "IsValid should be false");
            Assert.IsTrue(attachment.IsSelfDirty, "IsSelfDirty should be true");
            Assert.IsFalse(attachment.IsSelfValid, "IsSelfValid should be false");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(attachment, DbType.Int32, "SourceId"),
                "SourceId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(attachment, DbType.Int32, "SourceTypeId"),
                "SourceTypeId should be required");

            Assert.IsTrue(
                ValidationHelper.ContainsRule(attachment, DbType.String, "Name"),
                "Name should be required");
        }

        [TestMethod]
        public void Attachment_Fetch()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var attachment = AttachmentTestHelper.AttachmentNew(project.ProjectId, SourceType.Project);

            attachment = AttachmentRepository.AttachmentSave(attachment);

            attachment = AttachmentRepository.AttachmentFetch(attachment.AttachmentId);

            Assert.IsTrue(attachment != null, "Row returned should not equal null");
        }

        [TestMethod]
        public void Attachment_Fetch_Info_List()
        {
            var project = ProjectTestHelper.ProjectAdd();

            AttachmentTestHelper.AttachmentAdd(project.ProjectId, SourceType.Project);
            AttachmentTestHelper.AttachmentAdd(project.ProjectId, SourceType.Project);

            var attachments = AttachmentRepository.AttachmentFetchInfoList(new AttachmentDataCriteria());

            Assert.IsTrue(attachments.Count() > 1, "Row returned should be greater than one");
        }

        [TestMethod]
        public void Attachment_Add()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var attachment = AttachmentTestHelper.AttachmentNew(project.ProjectId, SourceType.Project);

            Assert.IsTrue(attachment.IsValid, "IsValid should be true");

            attachment = AttachmentRepository.AttachmentSave(attachment);

            Assert.IsTrue(attachment.AttachmentId != 0, "AttachmentId should be a non-zero value");

            AttachmentRepository.AttachmentFetch(attachment.AttachmentId);
        }

        [TestMethod]
        public void Attachment_Edit()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var attachment = AttachmentTestHelper.AttachmentNew(project.ProjectId, SourceType.Project);

            var name = attachment.Name;

            Assert.IsTrue(attachment.IsValid, "IsValid should be true");

            attachment = AttachmentRepository.AttachmentSave(attachment);

            attachment = AttachmentRepository.AttachmentFetch(attachment.AttachmentId);

            attachment.Name = DataHelper.RandomString(20);

            attachment = AttachmentRepository.AttachmentSave(attachment);

            attachment = AttachmentRepository.AttachmentFetch(attachment.AttachmentId);

            Assert.IsTrue(attachment.Name != name, "Name should have different value");
        }

        [TestMethod]
        public void Attachment_Delete()
        {
            var project = ProjectTestHelper.ProjectAdd();

            var attachment = AttachmentTestHelper.AttachmentNew(project.ProjectId, SourceType.Project);

            Assert.IsTrue(attachment.IsValid, "IsValid should be true");

            attachment = AttachmentRepository.AttachmentSave(attachment);

            attachment = AttachmentRepository.AttachmentFetch(attachment.AttachmentId);

            AttachmentRepository.AttachmentDelete(attachment.AttachmentId);

            try
            {
                AttachmentRepository.AttachmentFetch(attachment.AttachmentId);
            }
            catch (Exception ex)
            {
                Assert.IsTrue(ex.GetBaseException() is InvalidOperationException);
            }
        }
    }
}