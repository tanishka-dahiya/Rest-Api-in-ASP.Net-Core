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



        //returns list of all tasks
        public IList<SHARED.ViewModals.Task>  getTasks()
        {
            IList<TodoModel> tasks =  _context.TodoModels.ToList();
            return EntityDTOConversion.EntityToDTO(tasks);
        }



        //to add a task
        public SHARED.ViewModals.Task PostTasks(SHARED.ViewModals.Task item)
        {
            TodoModel postedTask = EntityDTOConversion.DTOToEntity(item);
            _context.TodoModels.Add(postedTask);
             _context.SaveChangesAsync();
            return item;
           
        }



        //to edit a task
        public SHARED.ViewModals.Task EditTasks(int id,SHARED.ViewModals.Task item)
        {
            if (id != item.TaskId)
            {
                return null;
            }
            TodoModel editedData = EntityDTOConversion.DTOToEntity(item);
            _context.Entry(editedData).State = EntityState.Modified;

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

   


        //get sorted data list
        public IList<SHARED.ViewModals.Task> getSortedTasks(string sort)
        {
            IList<TodoModel> sortedTaskList;
            switch (sort)
            {
                case "desc":
                    sortedTaskList = _context.TodoModels.OrderByDescending(q=>q.Title).ToList();
                    break;
                case "asc":
                    sortedTaskList = _context.TodoModels.OrderBy(q => q.Title).ToList();
                    break;
                default:
                    sortedTaskList = _context.TodoModels.ToList();
                    break;
            }
            return EntityDTOConversion.EntityToDTO(sortedTaskList);

        }




        //get filtered data list
        public IList<SHARED.ViewModals.Task> getFilteredTasks(string filter)
        {
            IList<TodoModel> filteredDataList;
            switch (filter)
            {
                case "IsCompleted":
                    filteredDataList = _context.TodoModels.Where(s => s.IsCompleted == 1)
                                      .ToList();
                    break;
                case "IsExpired":
                    filteredDataList = _context.TodoModels.Where(q => q.IsExpired==1).ToList();
                    break;
                case "IsDeleted":
                    filteredDataList = _context.TodoModels.Where(q => q.IsDeleted==1).ToList();
                    break;
                case "IsOnGoing":
                    filteredDataList = _context.TodoModels.Where(q => q.IsExpired==0&& q.IsDeleted == 0&& q.IsCompleted == 0).ToList();
                    break;
                default:
                    filteredDataList = _context.TodoModels.ToList();
                    break;

            }

            return EntityDTOConversion.EntityToDTO(filteredDataList);

        }





        //get pagination TaskList
        public IEnumerable<SHARED.ViewModals.Task> getPagination(int? pageNumber, int? pageSize)
        {
            IEnumerable<SHARED.ViewModals.Task> Tasks = EntityDTOConversion.EntityToDTO(_context.TodoModels.ToList());
            var currentPageNumber = pageNumber ?? 1;
            var currentPageSize = pageSize ?? 5;
            return Tasks.Skip((currentPageNumber - 1) * currentPageSize).Take(currentPageSize);
        }





        //get Search Result
        public IEnumerable<SHARED.ViewModals.Task> getSearchResult(string searchString)
        {
                IEnumerable<SHARED.ViewModals.Task> searchList = EntityDTOConversion.EntityToDTO(_context.TodoModels.Where(q=>q.Title.Contains(searchString)).ToList());

            return searchList;
        }




    }
}
