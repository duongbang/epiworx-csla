using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class TimelineRepository
    {
        public static Timeline TimelineFetch(int timelineId)
        {
            return Timeline.FetchTimeline(
                new TimelineDataCriteria
                {
                    TimelineId = timelineId
                });
        }

        public static TimelineInfoList TimelineFetchInfoList(IProject project)
        {
            return
                TimelineRepository.TimelineFetchInfoList(
                    new TimelineDataCriteria
                    {
                        SourceId = new[] { project.ProjectId },
                        SourceTypeId = (int)SourceType.Project
                    });
        }

        public static TimelineInfoList TimelineFetchInfoList(IUser user)
        {
            return
                TimelineRepository.TimelineFetchInfoList(
                    new TimelineDataCriteria
                    {
                        SourceId = new[] { user.UserId },
                        SourceTypeId = (int)SourceType.User
                    });
        }

        public static TimelineInfoList TimelineFetchInfoList(int[] sourceId, SourceType sourceType)
        {
            return
                TimelineRepository.TimelineFetchInfoList(
                    new TimelineDataCriteria
                    {
                        SourceId = sourceId,
                        SourceTypeId = (int)sourceType
                    });
        }

        public static TimelineInfoList TimelineFetchInfoList(int sourceId, SourceType sourceType)
        {
            return
                TimelineRepository.TimelineFetchInfoList(
                    new TimelineDataCriteria
                        {
                            SourceId = new[] { sourceId },
                            SourceTypeId = (int)sourceType
                        });
        }

        public static TimelineInfoList TimelineFetchInfoList(TimelineDataCriteria criteria)
        {
            return TimelineInfoList.FetchTimelineInfoList(criteria);
        }

        public static Timeline TimelineSave(Timeline timeline)
        {
            if (!timeline.IsValid)
            {
                return timeline;
            }

            Timeline result;

            if (timeline.IsNew)
            {
                result = TimelineRepository.TimelineInsert(timeline);
            }
            else
            {
                result = TimelineRepository.TimelineUpdate(timeline);
            }

            return result;
        }

        public static Timeline TimelineInsert(Timeline timeline)
        {
            timeline = timeline.Save();

            return timeline;
        }

        public static Timeline TimelineUpdate(Timeline timeline)
        {
            if (!timeline.IsDirty)
            {
                return timeline;
            }

            timeline = timeline.Save();

            return timeline;
        }

        public static Timeline TimelineNew()
        {
            var timeline = Timeline.NewTimeline();

            return timeline;
        }

        public static Timeline TimelineNew(int sourceId, SourceType sourceType)
        {
            var timeline = Timeline.NewTimeline();

            timeline.SourceId = sourceId;
            timeline.SourceTypeId = (int)sourceType;

            return timeline;
        }

        public static bool TimelineDelete(Timeline timeline)
        {
            Timeline.DeleteTimeline(
                new TimelineDataCriteria
                {
                    TimelineId = timeline.TimelineId
                });

            return true;
        }

        public static bool TimelineDelete(int timelineId)
        {
            return TimelineRepository.TimelineDelete(
                TimelineRepository.TimelineFetch(timelineId));
        }
    }
}
