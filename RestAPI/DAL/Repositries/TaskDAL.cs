using DAL.Entities;
using DAL.Interfaces;
using DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.EntityFrameworkCore;

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
        public SHARED.ViewModals.Task EditTasks(int id,SHARED.ViewModals.Task item)
        {
            if (id != item.TaskId)
            {
                return null;
            }
            TodoModel Data = EntityDTOConversion.DTOToEntity(item);
            _context.Entry(Data).State = EntityState.Modified;

            try
            {
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
              
                
                    throw;
               
            }

            return item;




        }


        //Sorting In Tasks
        public IList<SHARED.ViewModals.Task> getSortedTasks(string sort)
        {
            IList<TodoModel> Tasks;
            switch (sort)
            {
                case "desc":
                    Tasks = _context.TodoModels.OrderByDescending(q=>q.Title).ToList();
                    break;
                case "asc":
                    Tasks = _context.TodoModels.OrderBy(q => q.Title).ToList();
                    break;
                default:
                    Tasks = _context.TodoModels.ToList();
                    break;

            }

           
            return EntityDTOConversion.EntityToDTO(Tasks);

        }


        //Filter In Tasks
        public IList<SHARED.ViewModals.Task> getFilteredTasks(string filter)
        {
            IList<TodoModel> Tasks;
            switch (filter)
            {
                case "IsCompleted":
                    Tasks = _context.TodoModels.Where(s => s.IsCompleted == 1)
                                      .ToList();
                    break;
                case "IsExpired":
                    Tasks = _context.TodoModels.Where(q => q.IsExpired==1).ToList();
                    break;
                case "IsDeleted":
                    Tasks = _context.TodoModels.Where(q => q.IsDeleted==1).ToList();
                    break;
                case "IsOnGoing":
                    Tasks = _context.TodoModels.Where(q => q.IsExpired==0&& q.IsDeleted == 0&& q.IsCompleted == 0).ToList();
                    break;
                default:
                    Tasks = _context.TodoModels.ToList();
                    break;

            }


            return EntityDTOConversion.EntityToDTO(Tasks);

        }




        public IEnumerable<SHARED.ViewModals.Task> getPagination(int? pageNumber, int? pageSize)
        {
            IEnumerable<SHARED.ViewModals.Task> Tasks = EntityDTOConversion.EntityToDTO(_context.TodoModels.ToList());
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;
            return Tasks.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize);
        }

        public IEnumerable<SHARED.ViewModals.Task> getSearchResult(string searchString)
        {
            
                IEnumerable<SHARED.ViewModals.Task> Tasks = EntityDTOConversion.EntityToDTO(_context.TodoModels.Where(q=>q.Title.Contains(searchString)).ToList());

            return Tasks;
        }




    }
}
