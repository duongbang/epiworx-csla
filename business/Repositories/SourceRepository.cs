using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    internal class SourceService
    {
        public static Source SourceAdd(ISource source)
        {
            return SourceService.SourceAdd(source.SourceId, source.SourceType, source.SourceName);
        }

        public static Source SourceAdd(int sourceId, SourceType sourceType, string name)
        {
            var source = SourceService.SourceNew(sourceId, sourceType);

            source.Name = name;

            source = SourceService.SourceSave(source);

            return source;
        }

        public static Source SourceFetch(int sourceId, SourceType sourceType)
        {
            return Source.FetchSource(sourceId, sourceType);
        }

        public static Source SourceSave(Source source)
        {
            if (!source.IsValid)
            {
                return source;
            }

            Source result;

            if (source.IsNew)
            {
                result = SourceService.SourceInsert(source);
            }
            else
            {
                result = SourceService.SourceUpdate(source);
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

        public static Source SourceUpdate(ISource source)
        {
            return SourceService.SourceUpdate(source.SourceId, source.SourceType, source.SourceName);
        }

        public static Source SourceUpdate(int sourceId, SourceType sourceType, string name)
        {
            Source source;

            try
            {
                source = SourceService.SourceFetch(sourceId, sourceType);

                source.Name = name;

                source = SourceService.SourceSave(source);
            }
            catch
            {
                source = SourceService.SourceAdd(sourceId, sourceType, name);
            }

            return source;
        }

        public static Source SourceNew(int sourceId, SourceType sourceType)
        {
            var source = Source.NewSource(sourceId, sourceType);

            return source;
        }

        public static bool SourceDelete(ISource source)
        {
            Source.DeleteSource(source.SourceId, source.SourceType);

            return true;
        }

        public static bool SourceDelete(Source source)
        {
            Source.DeleteSource(source.SourceId, (SourceType)source.SourceTypeId);

            return true;
        }

        public static bool SourceDelete(int sourceId, SourceType sourceType)
        {
            return SourceService.SourceDelete(
                SourceService.SourceFetch(sourceId, sourceType));
        }
    }
}
