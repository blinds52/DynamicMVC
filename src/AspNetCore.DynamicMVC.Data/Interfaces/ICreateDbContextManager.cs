using System;
using Microsoft.EntityFrameworkCore;

namespace DynamicMVC.Data.Interfaces
{
    public interface ICreateDbContextManager
    {
        Func<DbContext> CreateDbContextFunction { get; set; }
    }
}
