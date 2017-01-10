using System;
using System.Linq;
using System.Reflection;

namespace DynamicLinqExtensions
{
    public static class DynamicWhereExtensions
    {
        public static IQueryable DynamicWhere(this IQueryable qry, string propertyName, object criteria)
        {
            PropertyInfo propertyInfo = qry.GetPropertyInfo(propertyName);
            return qry.DynamicWhere(propertyInfo, criteria);
        }

        public static IQueryable DynamicWhere(this IQueryable qry, PropertyInfo propertyInfo, object criteria)
        {
            string name = propertyInfo.Name;
            if (propertyInfo.PropertyType == typeof(Guid))
                return DynamicQueryable.Where(qry, name + ".Equals(@0)", new object[1]
                {
                    criteria
                });
            if (propertyInfo.PropertyType == typeof(Guid?))
                return DynamicQueryable.Where(qry, name + ".Value.Equals(@0)", new object[1]
                {
                    criteria
                });
            if (propertyInfo.PropertyType == typeof(int))
                return DynamicQueryable.Where(qry, propertyInfo.Name + " = @0", new object[1]
                {
                    (object) int.Parse(criteria.ToString())
                });
            return DynamicQueryable.Where(qry, name + " = @0", new object[1]
            {
                criteria
            });
        }

        public static IQueryable DynamicWhereGreaterThanEqualTo(this IQueryable qry, PropertyInfo propertyInfo, object criteria)
        {
            string name = propertyInfo.Name;
            return DynamicQueryable.Where(qry, $"{(object) name} >= @0", new object[1]
            {
                criteria
            });
        }

        public static IQueryable DynamicWhereGreaterThanEqualTo(this IQueryable qry, string propertyName, object criteria)
        {
            PropertyInfo propertyInfo = qry.GetPropertyInfo(propertyName);
            return qry.DynamicWhereGreaterThanEqualTo(propertyInfo, criteria);
        }

        public static IQueryable DynamicWhereLessThanEqualTo(this IQueryable qry, PropertyInfo propertyInfo, object criteria)
        {
            string name = propertyInfo.Name;
            return DynamicQueryable.Where(qry, $"{(object) name} <= @0", new object[1]
            {
                criteria
            });
        }

        public static IQueryable DynamicWhereLessThanEqualTo(this IQueryable qry, string propertyName, object criteria)
        {
            PropertyInfo propertyInfo = qry.GetPropertyInfo(propertyName);
            return qry.DynamicWhereLessThanEqualTo(propertyInfo, criteria);
        }

        public static IQueryable DynamicWhereContains(this IQueryable qry, string propertyName, object criteria)
        {
            PropertyInfo propertyInfo = qry.GetPropertyInfo(propertyName);
            return qry.DynamicWhereContains(propertyInfo, criteria);
        }

        public static IQueryable DynamicWhereContains(this IQueryable qry, PropertyInfo propertyInfo, object criteria)
        {
            string name = propertyInfo.Name;
            return DynamicQueryable.Where(qry, name + ".Contains(@0)", new object[1]
            {
                criteria
            });
        }
    }
}