using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Data;

namespace Epiworx.Business
{
    public partial class FeedSources
    {
        public override string ToString()
        {
            var result = new StringBuilder();

            foreach (var feedSource in this)
            {
                if (result.Length != 0)
                {
                    result.Append(" ");
                }

                result.Append(feedSource.SourceName);
            }

            return result.ToString();
        }

        public FeedSource Add(SourceType sourceType, int sourceId)
        {
            if (this.Contains(sourceType, sourceId))
            {
                throw new ArgumentException("Source already belongs to the collection.");
            }

            var child = FeedSource.NewFeedSource(
                new FeedSourceMemberDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceType
                });

            this.Add(child);

            return child;
        }

        public void Remove(SourceType sourceType, int sourceId)
        {
            foreach (var child in this.Where(child => child.SourceId == sourceId
                && child.SourceTypeId == (int)sourceType))
            {
                this.Remove(child);
                break;
            }
        }

        public bool Contains(SourceType sourceType, int sourceId)
        {
            return this.Any(child => child.SourceId == sourceId
                && child.SourceTypeId == (int)sourceType);
        }
    }
}
