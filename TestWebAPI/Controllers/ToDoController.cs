using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Linq;
using TestWebAPI.Entities;
using AutoMapper;
using TestWebAPI.Services;
using TestWebAPI.ViewModels;
using TestWebAPI.Models;

namespace TodoApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TodoController : ControllerBase
    {
        private readonly TodoContext _context; // DI
        private readonly IMapper _mapper;
        private readonly IToDoService _toDoService;
        


        public TodoController(TodoContext context, IMapper mapper, IToDoService toDoService) // DI
        {
            _context = context;
            _mapper = mapper;
            _toDoService = toDoService;
            


        }


        [HttpGet]
        public ActionResult<object> GetAll()   //get svih itema iz baze
        {

            return _toDoService.GetAllToDo();
        }



        //[HttpGet("{id}", Name = "GetTodo")]
        //public ActionResult<TodoItem> GetById(long id)   //vraca item za izabrani id
        //{
        //    var item = _context.TodoItems.Find(id);
        //    if (item == null)
        //    {
        //        return NotFound();
        //    }
        //    return item;
        //}


        [HttpGet("{id}", Name = "GetTodo")]

        public ActionResult<object> GetById(long id)
        {
            return _toDoService.GetToDoById(id);
        }

        [HttpPost]
        public IActionResult Create(ToDoView item)  //kreiranje novog itema( podeljeno na kontroler,service, repos)
        {
            var pom = _mapper.Map<ToDoModel>(item);
            var res = _toDoService.Add(pom);


            return CreatedAtRoute("GetTodo", new { id = item.Id }, item);
        }

        [HttpPut("{id}")]
        public IActionResult Update(long id, TodoItem item)  //update postojeceg itema
        {
            var todo = _context.TodoItems.Find(id);
            
            if (todo == null)
            {
                return NotFound();
            }

            todo.Task = item.Task;
            todo.Time = item.Time;
            todo.Description = item.Description;
            todo.Type = item.Type;
            todo.Date = item.Date;

            _context.TodoItems.Update(todo);
            _context.SaveChanges();
            return NoContent();
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(long id)
        {
            var todo = _context.TodoItems.Find(id);
            if (todo == null)
            {
                return NotFound();
            }

            _context.TodoItems.Remove(todo);
            _context.SaveChanges();
            return NoContent();
        }

    }
}