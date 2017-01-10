using System;
using DynamicMVC.Data.Interfaces;
using Microsoft.EntityFrameworkCore;

namespace DynamicMVC.Data
{
    public class CreateDbContextManager : ICreateDbContextManager
    {
        public CreateDbContextManager(Func<DbContext> createDbContextFunction)
        {
            CreateDbContextFunction = createDbContextFunction;
        }

        public Func<DbContext> CreateDbContextFunction { get; set; }
    }
}
