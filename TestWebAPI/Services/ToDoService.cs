using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestWebAPI.Entities;
using TestWebAPI.Models;
using TestWebAPI.Repository;
using TestWebAPI.ViewModels;

namespace TestWebAPI.Services
{

    
    public interface IToDoService
    {
        string Add(ToDoModel toDoModel);
        Object GetAllToDo();

        Object GetToDoById(long id);
    }

    
    public class ToDoService : IToDoService
    {
        private readonly IToDoRepository _todoRepository;
        private readonly IMapper _mapper;

        List<ToDoModel> model;

        public ToDoService(IToDoRepository toDoRepository, IMapper mapper)
        {
            _todoRepository = toDoRepository;
            _mapper = mapper;
        }
        public string Add(ToDoModel toDoModel)
        {
            var pom = _mapper.Map<TodoItem>(toDoModel);

            _todoRepository.AddToDb(pom);
            return "ok";
        }

        public Object GetAllToDo()
        {

            Object pom = _todoRepository.GetAllFromDb(); 

            return pom;
            
        }

        public Object GetToDoById(long id)
        {

            Object pom = _todoRepository.GetToDoFromDbById(id);

            return pom;

        }
    }
}
