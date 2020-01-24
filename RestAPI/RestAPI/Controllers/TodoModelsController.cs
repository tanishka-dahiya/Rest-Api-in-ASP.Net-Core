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
    public class TodoModelsController : ControllerBase
    {
        private readonly ITaskBLL taskBLL;

        public TodoModelsController(ITaskBLL taskBLL)
        {
            this.taskBLL = taskBLL;
        }

        // GET: api/TodoModels
        [HttpGet]
        public IList<Task> GetTodoModels()
        {
            var TasksList = taskBLL.getTasks();
            IList<Task> Result = ModelToDto.DTOToModel(TasksList);

            return Result;
        }

        //// GET: api/TodoModels/5
        //[HttpGet("{id}")]
        //public async Task<ActionResult<TodoModel>> GetTodoModel(int id)
        //{
        //    var todoModel = await _context.TodoModels.FindAsync(id);

        //    if (todoModel == null)
        //    {
        //        return NotFound();
        //    }

        //    return todoModel;
        //}

        //// PUT: api/TodoModels/5
        //[HttpPut("{id}")]
        //public async Task<IActionResult> PutTodoModel(int id, TodoModel todoModel)
        //{
        //    if (id != todoModel.TaskId)
        //    {
        //        return BadRequest();
        //    }

        //    _context.Entry(todoModel).State = EntityState.Modified;

        //    try
        //    {
        //        await _context.SaveChangesAsync();
        //    }
        //    catch (DbUpdateConcurrencyException)
        //    {
        //        if (!TodoModelExists(id))
        //        {
        //            return NotFound();
        //        }
        //        else
        //        {
        //            throw;
        //        }
        //    }

        //    return NoContent();
        //}

        //// POST: api/TodoModels
        [HttpPost]
        public SHARED.ViewModals.Task PostTodoModels(Task taskItem)
        {
            SHARED.ViewModals.Task postdata = ModelToDto.ModelToDTO(taskItem);
            SHARED.ViewModals.Task TasksItem = taskBLL.PostTasks(postdata);
            
            return TasksItem;

        }

        //// DELETE: api/TodoModels/5
        //[HttpDelete("{id}")]
        //public async Task<ActionResult<TodoModel>> DeleteTodoModel(int id)
        //{
        //    var todoModel = await _context.TodoModels.FindAsync(id);
        //    if (todoModel == null)
        //    {
        //        return NotFound();
        //    }

        //    _context.TodoModels.Remove(todoModel);
        //    await _context.SaveChangesAsync();

        //    return todoModel;
        //}

        //private bool TodoModelExists(int id)
        //{
        //    return _context.TodoModels.Any(e => e.TaskId == id);
        //}
    }
}
