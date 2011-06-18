using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business.Helpers;

namespace Epiworx.Business
{
    public partial class FeedSourceInfo
    {
        private static Csla.PropertyInfo<int> FeedSourceMemberIdProperty =
           RegisterProperty<int>(row => row.FeedSourceMemberId, "FeedSourceMemberId");
        public int FeedSourceMemberId
        {
            get { return this.GetProperty(FeedSourceMemberIdProperty); }
            set { this.LoadProperty(FeedSourceMemberIdProperty, value); }
        }

        private static Csla.PropertyInfo<int> FeedIdProperty =
            RegisterProperty<int>(row => row.FeedId, "FeedId");
        public int FeedId
        {
            get { return this.GetProperty(FeedIdProperty); }
            set { this.LoadProperty(FeedIdProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceIdProperty =
            RegisterProperty<int>(row => row.SourceId, "SourceId");
        public int SourceId
        {
            get { return this.GetProperty(SourceIdProperty); }
            set { this.LoadProperty(SourceIdProperty, value); }
        }

        private static Csla.PropertyInfo<string> SourceNameProperty =
            RegisterProperty<string>(row => row.SourceName, "SourceName");
        public string SourceName
        {
            get { return this.GetProperty(SourceNameProperty); }
            set { this.LoadProperty(SourceNameProperty, value); }
        }

        private static Csla.PropertyInfo<int> SourceTypeIdProperty =
            RegisterProperty<int>(row => row.SourceTypeId, "SourceTypeId");
        public int SourceTypeId
        {
            get { return this.GetProperty(SourceTypeIdProperty); }
            set { this.LoadProperty(SourceTypeIdProperty, value); }
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
            set { this.LoadProperty(CreatedByProperty, value); }
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
    }
}
