using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Web.Core.Extentions
{
    public static class CollectionExtensions
    {
        public static IEnumerable<TOutput> Map<TInput, TOutput>(this IEnumerable<TInput> collection)
            => collection.Select(e => e.ToDataObject<TOutput>());
    }
}
