using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BLL;
using BLL.Interfaces;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SHARED;


namespace RestAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    //[Microsoft.AspNetCore.Authorization.Authorize]
    public class TodoModelsController : ControllerBase
    {

        private readonly ITaskBLL taskBLL;
       
        public TodoModelsController(ITaskBLL taskBLL)
        {
            this.taskBLL = taskBLL;
        } 

        // GET: api/TodoModels
        // [ResponseCache(Duration =60,Location =ResponseCacheLocation.Any)]
        [HttpGet]
        public IActionResult GetTodoModels()
        {

            var tasksList = taskBLL.getTasks();
            IList<Task> Result = ModelToDto.DTOToModel(tasksList);

            return Ok( Result);
        }




        //Sorting in Ascending And Descending Order api/TodoModels/{sort}
         [HttpGet("{sort}")]
        public IActionResult Sort(string sort)
        {
            var sortedList = taskBLL.getSortedTasks(sort);
            IList<Task> Result = ModelToDto.DTOToModel(sortedList);

            return Ok(Result);
        }




        //Get filtered Tasks

        [HttpGet("[action]/{filter}")]
        public IActionResult GetFiltered(string filter)
        {
            var filteredList = taskBLL.getFilteredTasks(filter);
            IList<Task> Result = ModelToDto.DTOToModel(filteredList);

            return Ok(Result);
        }
       




        //// PUT: api/TodoModels/5
        [HttpPut("{id}")]
        public IActionResult PutTodoModel(int id, taskViewModel todoModel)
        {
            Task editedTask = new Task()
            {   TaskId=todoModel.TaskId,
                Title = todoModel.Title,
                TimeLeft = TimeSpan.Parse(todoModel.TimeLeft),
                IsCompleted= todoModel.IsCompleted,
                IsDeleted= todoModel.IsDeleted,
                IsExpired= todoModel.IsExpired

            };
            SHARED.ViewModals.Task editdata = ModelToDto.ModelToDTO(editedTask);
            SHARED.ViewModals.Task tasksItem = taskBLL.EditTasks(id, editdata);

            return Created("", tasksItem);
        }



        //// POST: api/TodoModels
        [HttpPost]
        public IActionResult PostTodoModels(taskViewModel taskItem)
        {
            Task postedTask = new Task()
            {
                Title = taskItem.Title,
                TimeLeft = TimeSpan.Parse(taskItem.TimeLeft)

        };
            SHARED.ViewModals.Task postData = ModelToDto.ModelToDTO(postedTask);
            SHARED.ViewModals.Task result = taskBLL.PostTasks(postData);

            return Created("" , result);

        }



        //Get Pagination from Task Table
        [HttpGet("[action]")]
        public IActionResult getPagination(int pageNumber,int pageSize)
        {
            var FilteredLIstList = taskBLL.getPagination(pageNumber, pageSize);
            IEnumerable<Task> Result = ModelToDto.DTOToModel(FilteredLIstList);

            return Ok(Result);
        }




        //Get Search Results from Task Table
        [HttpGet("[action]")]
        public IActionResult getSearchResult(string searchString)
        {
            var FilteredLIstList = taskBLL.getSearchResult(searchString);
            IEnumerable<Task> Result = ModelToDto.DTOToModel(FilteredLIstList);

            return Ok(Result);
        }
    }
   

    


}

