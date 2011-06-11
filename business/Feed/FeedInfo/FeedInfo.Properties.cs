using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class FeedInfo
    {
        private static Csla.PropertyInfo<int> FeedIdProperty =
            RegisterProperty<int>(row => row.FeedId, "FeedId");
        public int FeedId
        {
            get { return this.GetProperty(FeedIdProperty); }
            set { this.LoadProperty(FeedIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> ActionProperty =
            RegisterProperty<string>(row => row.Action, "Action");
        public string Action
        {
            get { return this.GetProperty(ActionProperty); }
            set { this.LoadProperty(ActionProperty, value); }
        }

        private static Csla.PropertyInfo<int> CreatedByProperty =
            RegisterProperty<int>(row => row.CreatedBy, "CreatedBy");
        public int CreatedBy
        {
            get { return this.GetProperty(CreatedByProperty); }
            set { this.LoadProperty(CreatedByProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByEmailProperty =
            RegisterProperty<string>(row => row.CreatedByEmail, "CreatedByEmail");
        public string CreatedByEmail
        {
            get { return this.GetProperty(CreatedByEmailProperty); }
            set { this.LoadProperty(CreatedByEmailProperty, value); }
        }

        private static Csla.PropertyInfo<string> CreatedByNameProperty =
            RegisterProperty<string>(row => row.CreatedByName, "CreatedByName");
        public string CreatedByName
        {
            get { return this.GetProperty(CreatedByNameProperty); }
            set { this.LoadProperty(CreatedByNameProperty, value); }
        }

        private static Csla.PropertyInfo<DateTime> CreatedDateProperty =
            RegisterProperty<DateTime>(row => row.CreatedDate, "CreatedDate");
        public DateTime CreatedDate
        {
            get { return this.GetProperty(CreatedDateProperty); }
            set { this.LoadProperty(CreatedDateProperty, value); }
        }

        private static Csla.PropertyInfo<List<FeedSourceMemberInfo>> SourcesProperty =
            RegisterProperty<List<FeedSourceMemberInfo>>(row => row.Sources, "Sources");
        public List<FeedSourceMemberInfo> Sources
        {
            get { return this.GetProperty(SourcesProperty); }
            set { this.LoadProperty(SourcesProperty, value); }
        }
    }
}
