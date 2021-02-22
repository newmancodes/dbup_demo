namespace DbUpDemo.Infrastructure.Postgres
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    public static class EnumerableExtensions
    {
        public static T Penultimate<T>(this IEnumerable<T> source)
        {
            if (source == null)
            {
                throw new ArgumentNullException(nameof(source));
            }

            return source.Reverse().Skip(1).FirstOrDefault();
        }
    }
}
