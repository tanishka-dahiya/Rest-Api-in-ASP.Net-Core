using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Builder;

using System.Linq;
using System.Threading.Tasks;
using DAL.Entities;

namespace DAL
{
    public class SeedData
    {

        public static void Initialize(IApplicationBuilder app)
        {
            using (var serviceScope = app.ApplicationServices.GetService<IServiceScopeFactory>().CreateScope())
            {
                var context = serviceScope.ServiceProvider.GetService<TaskManagerContext>();
                context.Database.EnsureCreated();
                //context.Database.Migrate();

                // Look for any ailments
                if (context.TodoModels != null && context.TodoModels.Any())
                    return;   // DB has already been seeded

                var TaskData = GetTasks().ToArray();
                context.TodoModels.AddRange(TaskData);
                context.SaveChanges();

              
            }
        }

        public static List<TodoModel> GetTasks()
        {
          
            List<TodoModel> TodoModels = new List<TodoModel>() {
                new TodoModel {Title="Study" ,TimeLeft=  TimeSpan.ParseExact("0:0:0", "c", null)
        }
   
            };
            return TodoModels;
        }

        

        
    }
}
