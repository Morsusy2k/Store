using System;
using System.Data;
using System.Reflection;

namespace Store.Utilities.Common.Extensions
{
    /// <summary>
    /// DBAccess extension methods.
    /// </summary>
    public static class DBAccessExtensions
    {
        /// <summary>
		/// Return mapped model from sql data reader.
		/// </summary>
		/// <typeparam name="record">The record from database</typeparam>
		/// <returns></returns>
		public static T MapTableEntityTo<T>(IDataRecord record) where T : class
        {
            T result = (T)Activator.CreateInstance(typeof(T));
            PropertyInfo[] properties = typeof(T).GetProperties();

            foreach (PropertyInfo property in properties)
            {
                object defaultType = property.PropertyType.GetDefault();

                property.SetValue(result, record[property.Name].DBNullTo(defaultType));
            }

            return result;
        }

        /// <summary>
        /// If value is null return value equal to database nullable object
        /// </summary>
        /// <typeparam name="value">Value that's being converted</typeparam>
        /// <typeparam name="optionalValue">Optional value to convert to</typeparam>
        /// <returns></returns>
        public static object ToDBNullable<T>(this T value, T optionalValue = default(T))
        {
            return Equals(value, optionalValue) ? DBNull.Value : (object)value;
        }

        public static T DBNullTo<T>(this object value, T substitutionValue = default(T))
        {
            return Convert.IsDBNull(value) ? substitutionValue : (T)value;
        }

        public static object GetDefault(this Type type)
        {
            if (type.IsValueType)
            {
                return Activator.CreateInstance(type);
            }

            return null;
        }
    }
}
