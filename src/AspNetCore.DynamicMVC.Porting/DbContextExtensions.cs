using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace DynamicMVC.Data
{
    public static class DbContextExtensions
    {
        interface IDbSetBuilder
        {
            IQueryable Set();
        }

        class DbSetBuilder<TEntity> : IDbSetBuilder
            where TEntity : class 
        {
            private readonly DbContext _context;

            public DbSetBuilder(DbContext context)
            {
                _context = context;
            }

            public IQueryable Set()
            {
                return _context.Set<TEntity>();
            }
        }

        interface IQueryEntensionBuilder
        {
            IQueryable Include(string navigationPropertyPath);

            void Add(object entity);
            void Remove(object entity);
        }

        class QueryEntensionBuilder<TEntity> : IQueryEntensionBuilder
            where TEntity : class

        {
            private readonly DbSet<TEntity> _dbSet;

            public QueryEntensionBuilder(DbSet<TEntity> dbSet)
            {
                _dbSet = dbSet;
            }

            public IQueryable Include(string navigationPropertyPath)
            {
                return _dbSet.Include(navigationPropertyPath);
            }

            public void Add(object entity)
            {
                _dbSet.Add(entity);
            }
            public void Remove(object entity)
            {
                _dbSet.Remove(entity);
            }
        }

        public static IQueryable Set(this DbContext context, Type entityType)
        {
            if (context == null) throw new ArgumentNullException(nameof(context));
            if (entityType == null) throw new ArgumentNullException(nameof(entityType));

            var builder = (IDbSetBuilder)Activator.CreateInstance((typeof (DbSetBuilder<>).MakeGenericType(entityType)), context);

            return builder.Set();
        }

        private static IQueryEntensionBuilder GetBuilder(IQueryable queryable)
        {
            if (queryable == null) throw new ArgumentNullException(nameof(queryable));

            return (IQueryEntensionBuilder)Activator.CreateInstance((typeof (QueryEntensionBuilder<>).MakeGenericType(queryable.ElementType)), queryable);
        }

        public static IQueryable Include(this IQueryable dbSet, string navigationPropertyPath)
        {
            return GetBuilder(dbSet).Include(navigationPropertyPath);
        }

        public static void Add(this IQueryable dbSet, object entity)
        {
            GetBuilder(dbSet).Add(entity);
        }
        public static void Remove(this IQueryable dbSet, object entity)
        {
            GetBuilder(dbSet).Remove(entity);
        }
    }
}
