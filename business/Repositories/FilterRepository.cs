using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Epiworx.Core;
using Epiworx.Data;

namespace Epiworx.Business
{
    [Serializable]
    public class FilterRepository
    {
        public static Filter FilterFetch(int filterId)
        {
            return Filter.FetchFilter(
                new FilterDataCriteria
                {
                    FilterId = filterId
                });
        }

        public static FilterInfoList FilterFetchInfoList(FilterDataCriteria criteria)
        {
            return FilterInfoList.FetchFilterInfoList(criteria);
        }

        public static Filter FilterSave(Filter filter)
        {
            if (!filter.IsValid)
            {
                return filter;
            }

            Filter result;

            if (filter.IsNew)
            {
                result = FilterRepository.FilterInsert(filter);
            }
            else
            {
                result = FilterRepository.FilterUpdate(filter);
            }

            return result;
        }

        public static Filter FilterInsert(Filter filter)
        {
            filter = filter.Save();

            return filter;
        }

        public static Filter FilterUpdate(Filter filter)
        {
            filter = filter.Save();

            return filter;
        }

        public static Filter FilterNew()
        {
            var filter = Filter.NewFilter();

            return filter;
        }

        public static bool FilterDelete(Filter filter)
        {
            Filter.DeleteFilter(
                new FilterDataCriteria
                {
                    FilterId = filter.FilterId
                });

            return true;
        }

        public static bool FilterDelete(int filterId)
        {
            return FilterRepository.FilterDelete(
                FilterRepository.FilterFetch(filterId));
        }
    }
}
