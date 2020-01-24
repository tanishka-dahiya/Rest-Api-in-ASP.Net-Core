using DAL.Entities;
using DAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL.Repositries
{
   public class TaskDAL: ITaskDAL
    {
        
        private readonly TaskManagerContext _context;

        public TaskDAL(TaskManagerContext context)
        {
           this._context = context;
        }

        public IList<SHARED.ViewModals.Task>  getTasks()
        {
            IList<TodoModel> Tasks =  _context.TodoModels.ToList();
            return EntityDTOConversion.EntityToDTO(Tasks);

        }
        public SHARED.ViewModals.Task PostTasks(SHARED.ViewModals.Task item)
        {
            TodoModel Data = EntityDTOConversion.DTOToEntity(item);
            _context.TodoModels.Add(Data);
             _context.SaveChangesAsync();
            return item;
           
        }
    }
}
