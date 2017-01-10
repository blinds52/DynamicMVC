using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace DynamicLinqExtensions
{
    public static class GeneralExtensions
    {
        public static Type GetTypeFromIQueryable(this IQueryable queryable)
        {
            Type[] genericArguments = queryable.GetType().GetGenericArguments();
            if (!Enumerable.Any<Type>((IEnumerable<Type>)genericArguments))
                throw new DynamicLinqExtensionsException("Could not determine the Type of queryable being passed in as IQueryable");
            return genericArguments[0];
        }

        public static PropertyInfo GetPropertyInfo(this IQueryable queryable, string propertyName)
        {
            Type typeFromIqueryable = GeneralExtensions.GetTypeFromIQueryable(queryable);
            PropertyInfo propertyInfo = Enumerable.SingleOrDefault<PropertyInfo>((IEnumerable<PropertyInfo>)typeFromIqueryable.GetProperties(), (Func<PropertyInfo, bool>)(x => x.Name == propertyName));
            if (propertyInfo == (PropertyInfo)null)
                throw new DynamicLinqExtensionsException("Could not find property " + propertyName + " in type " + typeFromIqueryable.Name);
            return propertyInfo;
        }

        public static object Single(this IQueryable queryable)
        {
            object obj1 = (object)null;
            int num = 0;
            foreach (object obj2 in (IEnumerable)queryable)
            {
                ++num;
                obj1 = obj2;
            }
            if (num > 1)
                throw new DynamicLinqExtensionsException("Sequence contains more than one element.");
            if (num == 0)
                throw new DynamicLinqExtensionsException("Sequence contains no elements.");
            return obj1;
        }

        public static object First(this IQueryable queryable)
        {
            return Enumerable.FirstOrDefault<object>(Enumerable.Cast<object>((IEnumerable)queryable));
        }

        public static int Count(this IQueryable queryable)
        {
            int num = 0;
            foreach (object obj in (IEnumerable)queryable)
                ++num;
            return num;
        }
    }
}