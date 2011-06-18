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

        public FeedSource Add(ISource source)
        {
            return this.Add(source.SourceId, source.SourceType);
        }

        public FeedSource Add(int sourceId, SourceType sourceTypeId)
        {
            if (this.Contains(sourceId, sourceTypeId))
            {
                throw new ArgumentException("Source already belongs to the collection.");
            }

            var child = FeedSource.NewFeedSource(
                new FeedSourceMemberDataCriteria
                {
                    SourceId = sourceId,
                    SourceTypeId = (int)sourceTypeId
                });

            this.Add(child);

            return child;
        }

        public void Remove(int sourceId, SourceType sourceTypeId)
        {
            foreach (var child in this.Where(child => child.SourceId == sourceId
                && child.SourceTypeId == (int)sourceTypeId))
            {
                this.Remove(child);
                break;
            }
        }

        public bool Contains(int sourceId, SourceType sourceTypeId)
        {
            return this.Any(child => child.SourceId == sourceId
                && child.SourceTypeId == (int)sourceTypeId);
        }
    }
}
