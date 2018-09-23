using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;

namespace WebParser.Models
{
    public class StatementContext: DbContext
    {
        // Отримуємо із бази всі обєкти-речення
        public DbSet <Statement> Statements { get; set; }
    }
}