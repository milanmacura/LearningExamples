using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using AutoMapper;
using TestWebAPI.Entities;
using TestWebAPI.Models;
using TestWebAPI.ViewModels;

namespace TestWebAPI.Automapper
{
    public class ApplicationProfile: Profile
    {

        public ApplicationProfile()
        {
            CreateMap<ToDoModel, ToDoView>().ReverseMap();// iz todoViewa u toDoModel
            CreateMap<TodoItem, ToDoModel>().ReverseMap();// iz todoModel u toDoEntietet
            CreateMap<ToDoView, ToDoModel>().ReverseMap();// iz toDoModel u todoView

            CreateMap<ToDoModel, TodoItem>().ReverseMap();// iz todoViewa u toDoModel
            CreateMap<ToDoView, ToDoModel>().ReverseMap();// iz todoModel u toDoEntietet
        }
        
    }
}
