using System;
using System.Data.Common;

namespace DbDataReaderExtension
{
    /// <summary>
    /// Extension methods to DbDataReader
    /// </summary>
    public static class DbDataReaderExtension
    {
        /// <summary>
        ///  Gets a value that indicates whether the column contains nonexistent or missing values.
        /// </summary>
        /// <param name="reader">The DbDataReader</param>
        /// <param name="name">The column name</param>
        /// <returns>true if the specified column is equivalent to DBNull; otherwise false.</returns>
        /// <exception cref="System.InvalidOperationException">The column name is not valid.</exception>
        public static bool IsDBNull(this DbDataReader reader, string name)
        {
            return reader.IsDBNull(reader.Ordinal(name));
        }

        /// <summary>
        /// Gets the value of the specified column as a type.
        /// </summary>
        /// <param name="reader">The DbDataReader</param>
        /// <param name="name">The column name</param>
        /// <typeparam name="T">The column type</typeparam>
        /// <returns>The value of the specified column as a type.</returns>
        /// <exception cref="System.InvalidOperationException">The column name is not valid.</exception>
        public static T GetFieldValue<T>(this DbDataReader reader, string name)
        {
            return reader.GetFieldValue<T>(reader.Ordinal(name));
        }

        private static int Ordinal(this DbDataReader reader, string name)
        {
            try
            {
                return reader.GetOrdinal(name);
            }
            catch(ArgumentOutOfRangeException ex)
            {
                throw new InvalidOperationException($"The name '{name}' is not a valid column name.", ex);
            }
        }
    }
}
