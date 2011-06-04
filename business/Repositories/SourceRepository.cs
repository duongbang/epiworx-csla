using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class SourceRepository
    {
        public static Source SourceAdd(int sourceId, SourceType sourceTypeId, string name)
        {
            var result = SourceRepository.SourceNew(sourceId, sourceTypeId);

            result.Name = name;

            result = SourceRepository.SourceSave(result);

            return result;
        }

        private static Source SourceFetch(int sourceId, SourceType sourceTypeId)
        {
            return Source.FetchSource(sourceId, sourceTypeId);
        }

        public static SourceInfoList SourceFetchInfoList(SourceDataCriteria criteria)
        {
            return SourceInfoList.FetchSourceInfoList(criteria);
        }

        private static Source SourceSave(Source source)
        {
            if (!source.IsValid)
            {
                return source;
            }

            Source result;

            if (source.IsNew)
            {
                result = SourceRepository.SourceInsert(source);
            }
            else
            {
                result = SourceRepository.SourceUpdate(source);
            }

            return result;
        }

        private static Source SourceInsert(Source source)
        {
            source = source.Save();

            return source;
        }

        private static Source SourceUpdate(Source source)
        {
            source = source.Save();

            return source;
        }

        public static Source SourceUpdate(int sourceId, SourceType sourceTypeId, string name)
        {
            var result = SourceRepository.SourceFetch(sourceId, sourceTypeId);

            result.Name = name;

            result = SourceRepository.SourceSave(result);

            return result;
        }

        private static Source SourceNew(int sourceId, SourceType sourceTypeId)
        {
            var source = Source.NewSource(sourceId, sourceTypeId);

            return source;
        }

        private static bool SourceDelete(Source source)
        {
            Source.DeleteSource(source.SourceId, (SourceType)source.SourceTypeId);

            return true;
        }

        public static bool SourceDelete(int sourceId, SourceType sourceTypeId)
        {
            return SourceRepository.SourceDelete(
                SourceRepository.SourceFetch(sourceId, sourceTypeId));
        }
    }
}
