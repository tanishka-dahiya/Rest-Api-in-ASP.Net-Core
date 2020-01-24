using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL.Entities
{
    public class TaskManagerContext: DbContext
    {
       
        public TaskManagerContext(DbContextOptions options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder builder)
    {
        base.OnModelCreating(builder);
    }

    public DbSet<TodoModel> TodoModels { get; set; }
   
}
}
