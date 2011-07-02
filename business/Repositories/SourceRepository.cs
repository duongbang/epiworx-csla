using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Business;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class SourceRepository
    {
        public static Source SourceAdd(ISource source)
        {
            return SourceRepository.SourceAdd(source.SourceId, source.SourceType, source.SourceName);
        }

        public static Source SourceAdd(int sourceId, SourceType sourceType, string name)
        {
            var source = SourceRepository.SourceNew(sourceId, sourceType, name);

            source = SourceRepository.SourceSave(source);

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
            if (!source.IsDirty)
            {
                return source;
            }

            source = source.Save();

            return source;
        }

        public static Source SourceUpdate(ISource source)
        {
            return SourceRepository.SourceUpdate(source.SourceId, source.SourceType, source.SourceName);
        }

        public static Source SourceUpdate(int sourceId, SourceType sourceType, string name)
        {
            Source source;

            try
            {
                source = SourceRepository.SourceFetch(sourceId, sourceType);

                source.Name = name;

                source = SourceRepository.SourceSave(source);
            }
            catch
            {
                source = SourceRepository.SourceAdd(sourceId, sourceType, name);
            }

            return source;
        }

        public static Source SourceNew(int sourceId, SourceType sourceType, string name)
        {
            var source = Source.NewSource(sourceId, sourceType);

            if (name.Length > 100)
            {
                source.Name = name.Substring(0, 100);
            }
            else
            {
                source.Name = name;
            }

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
            return SourceRepository.SourceDelete(
                SourceRepository.SourceFetch(sourceId, sourceType));
        }
    }
}
