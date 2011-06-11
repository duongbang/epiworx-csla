using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;

namespace Epiworx.Business
{
    public partial class Attachment
    {
        private static Csla.PropertyInfo<int> AttachmentIdProperty =
            RegisterProperty<int>(row => row.AttachmentId, "AttachmentId");
        [DataObjectField(true, false)]
        public int AttachmentId
        {
            get { return this.GetProperty(AttachmentIdProperty); }
            private set { this.SetProperty(AttachmentIdProperty, value); }
        }

        private static Csla.PropertyInfo<byte[]> FileDataProperty =
            RegisterProperty<byte[]>(row => row.FileData, "FileData");
        public byte[] FileData
        {
            get { return this.GetProperty(FileDataProperty); }
            set { this.SetProperty(FileDataProperty, value); }
        }

        private static Csla.PropertyInfo<string> FileTypeProperty =
            RegisterProperty<string>(row => row.FileType, "FileType");
        public string FileType
        {
            get { return this.GetProperty(FileTypeProperty); }
            set { this.SetProperty(FileTypeProperty, value); }
        }

        private static Csla.PropertyInfo<bool> IsArchivedProperty =
            RegisterProperty<bool>(row => row.IsArchived, "IsArchived");
        public bool IsArchived
        {
            get { return this.GetProperty(IsArchivedProperty); }
            set { this.SetProperty(IsArchivedProperty, value); }
        }

        private static Csla.PropertyInfo<string> NameProperty =
            RegisterProperty<string>(row => row.Name, "Name");
        public string Name
        {
            get { return this.GetProperty(NameProperty); }
            set { this.SetProperty(NameProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceIdProperty =
            RegisterProperty<int>(row => row.SourceId, "SourceId");
        public int SourceId
        {
            get { return this.GetProperty(SourceIdProperty); }
            set { this.SetProperty(SourceIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> SourceNameProperty =
            RegisterProperty<string>(row => row.SourceName, "SourceName");
        public string SourceName
        {
            get { return this.GetProperty(SourceNameProperty); }
            private set { this.SetProperty(SourceNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceTypeIdProperty =
            RegisterProperty<int>(row => row.SourceTypeId, "SourceTypeId");
        public int SourceTypeId
        {
            get { return this.GetProperty(SourceTypeIdProperty); }
            set { this.SetProperty(SourceTypeIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> SourceTypeNameProperty =
            RegisterProperty<string>(row => row.SourceTypeName, "SourceTypeName");
        public string SourceTypeName
        {
            get { return this.GetProperty(SourceTypeNameProperty); }
            private set { this.SetProperty(SourceTypeNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            private set { this.SetProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            private set { this.SetProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            private set { this.SetProperty(CreatedDateProperty, value); }
        }

        private static Csla.PropertyInfo<int> ModifiedByProperty =
            RegisterProperty<int>(row => row.ModifiedBy, "ModifiedBy");
        public int ModifiedBy
        {
            get { return this.GetProperty(ModifiedByProperty); }
            private set { this.SetProperty(ModifiedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> ModifiedByNameProperty =
            RegisterProperty<string>(row => row.ModifiedByName, "ModifiedByName");
        public string ModifiedByName
        {
            get { return this.GetProperty(ModifiedByNameProperty); }
            private set { this.SetProperty(ModifiedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> ModifiedDateProperty =
            RegisterProperty<DateTime>(row => row.ModifiedDate, "ModifiedDate");
        public DateTime ModifiedDate
        {
            get { return this.GetProperty(ModifiedDateProperty); }
            private set { this.SetProperty(ModifiedDateProperty, value); }
        }

        // public static Csla.PropertyInfo<ChildPropertyType> ChildPropertyProperty =
        //     RegisterProperty<ChildPropertyType>(row => row.ChildProperty);
        // public ChildPropertyType ChildProperty
        // {
        //     get { return GetProperty(ChildPropertyProperty); }
        //     private set { LoadProperty(ChildPropertyProperty, value); }
        // }
    }
}
