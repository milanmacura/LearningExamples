using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Entities;
using TestWebAPI.Models;


namespace TestWebAPI.Repository
{
    public interface IToDoRepository
    {
        string AddToDb(TodoItem todoItem);
        //List<TodoItem> GetAllFromDb();
        Object GetAllFromDb();
        Object GetToDoFromDbById(long id);
    }
    public class ToDoRepository : IToDoRepository
    {
        private readonly TodoContext _context;
        private readonly IMapper _mapper;


        public ToDoRepository(TodoContext todoContext, IMapper mapper)
        {
            _context = todoContext;
            _mapper = mapper;
        }
        public string AddToDb(TodoItem todoItem)
        {
            _context.TodoItems.Add(todoItem);
            _context.SaveChanges();
            return "ok";
        }

        public Object GetAllFromDb()
        {
            return _context.TodoItems.ToList();
       
        }

        public Object GetToDoFromDbById(long id)
        {
            var item = _context.TodoItems.Find(id);
            if (item == null)
            {
                return 404;
            }
            return item;
        }


    }
}
