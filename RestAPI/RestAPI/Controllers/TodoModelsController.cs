﻿using System;
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
    public class TodoModelsController : ControllerBase
    {
        private readonly ITaskBLL taskBLL;

        public TodoModelsController(ITaskBLL taskBLL)
        {
            this.taskBLL = taskBLL;
        }

        // GET: api/TodoModels
        [HttpGet]
       // [ResponseCache(Duration =60,Location =ResponseCacheLocation.Any)]
        public IActionResult GetTodoModels()
        {

            var TasksList = taskBLL.getTasks();
            IList<Task> Result = ModelToDto.DTOToModel(TasksList);

            return Ok( Result);
        }

        //Sorting in Ascending And Descending Order api/TodoModels/{sort}

        [HttpGet("{sort}")]
        public IActionResult Sort(string sort)
        {
            

            var SortedList = taskBLL.getSortedTasks(sort);
            IList<Task> Result = ModelToDto.DTOToModel(SortedList);

            return Ok(Result);
        }
        //Get Deleted Tasks

        [HttpGet("[action]/{filter}")]
        public IActionResult GetFiltered(string filter)
        {


            var FilteredLIstList = taskBLL.getFilteredTasks(filter);
            IList<Task> Result = ModelToDto.DTOToModel(FilteredLIstList);

            return Ok(Result);
        }
       




        //// PUT: api/TodoModels/5
        [HttpPut("{id}")]
        public IActionResult PutTodoModel(int id, Task todoModel)
        {
            SHARED.ViewModals.Task postdata = ModelToDto.ModelToDTO(todoModel);
            SHARED.ViewModals.Task TasksItem = taskBLL.EditTasks(id,postdata);

            return Created("",TasksItem);
        }

        //// POST: api/TodoModels
        [HttpPost]
        public IActionResult PostTodoModels(Task taskItem)
        {
            SHARED.ViewModals.Task postdata1 = ModelToDto.ModelToDTO(taskItem);
            SHARED.ViewModals.Task TasksItemResult = taskBLL.PostTasks(postdata1);

            return Created("" ,TasksItemResult);

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

