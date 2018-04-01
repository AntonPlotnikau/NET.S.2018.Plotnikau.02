using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NumberOperations
{
    /// <summary>
    /// interface for check if source is match filter
    /// </summary>
    /// <typeparam name="T">type of source</typeparam>
    public interface IFilter<T>
    {
        /// <summary>
        /// Determines whether the specified source is match filter.
        /// </summary>
        /// <param name="source">The source.</param>
        /// <returns>
        ///   <c>true</c> if the specified source is match filter; otherwise, <c>false</c>.
        /// </returns>
        bool IsMatch(T source);
    }
}
