using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class Feed
    {
        private static Csla.PropertyInfo<int> FeedIdProperty =
            RegisterProperty<int>(row => row.FeedId, "FeedId");
        [DataObjectField(true, false)]
        public int FeedId
        {
            get { return this.GetProperty(FeedIdProperty); }
            private set { this.SetProperty(FeedIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ActionProperty =
            RegisterProperty<string>(row => row.Action, "Action");
        public string Action
        {
            get { return this.GetProperty(ActionProperty); }
            set { this.SetProperty(ActionProperty, value); }
        }

        private static Csla.PropertyInfo<string> DescriptionProperty =
            RegisterProperty<string>(row => row.Description, "Description");
        public string Description
        {
            get { return this.GetProperty(DescriptionProperty); }
            set { this.SetProperty(DescriptionProperty, value); }
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
            set { this.SetProperty(SourceNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceTypeIdProperty =
            RegisterProperty<int>(row => row.SourceTypeId, "SourceTypeId");
        public int SourceTypeId
        {
            get { return this.GetProperty(SourceTypeIdProperty); }
            set { this.SetProperty(SourceTypeIdProperty, value); }
        }

        public string SourceTypeName
        {
            get { return DataHelper.FetchSourceTypeName(this.SourceTypeId); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            private set { this.SetProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByEmailProperty =
            RegisterProperty<string>(row => row.CreatedByEmail, "CreatedByEmail");
        public string CreatedByEmail
        {
            get { return this.GetProperty(CreatedByEmailProperty); }
            set { this.SetProperty(CreatedByEmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            set { this.SetProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            private set { this.SetProperty(CreatedDateProperty, value); }
        }

        private static Csla.PropertyInfo<FeedSources> SourcesProperty =
            RegisterProperty<FeedSources>(row => row.Sources);
        public FeedSources Sources
        {
            get { return this.GetProperty(SourcesProperty); }
            private set { this.LoadProperty(SourcesProperty, value); }
        }
    }
}
