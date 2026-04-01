using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using taskTracker.Models;
using taskTracker.Utilities;
using static System.Net.Mime.MediaTypeNames;

namespace taskTracker.Services
{
    public class TaskService
    {
        private string currentDirectory = Path.Combine(Directory.GetCurrentDirectory(),"Tasks.json");
        private List<TaskO>? tasks = new List<TaskO>();

        public string Add(string Description)
        {
          
            if (!File.Exists(currentDirectory))
            {
                File.Create(currentDirectory);
            }

            string json =  File.ReadAllText(currentDirectory);
                     
            if (!string.IsNullOrEmpty(json)) 
               tasks = JsonSerializer.Deserialize<List<TaskO>>(json);

            EnumStatusType EnumStatusType = EnumStatusType.ToDo;
            TaskO Tasko = new TaskO
            {
                Id = tasks.Count + 1,
                Description = Description,
                Status = EnumStatusType.ToString(),
                CreatedAt = DateTime.Now,
                UpdatedAt = DateTime.Now
            };

            tasks.Add(Tasko);
            json = JsonSerializer.Serialize<List<TaskO>>(tasks);
            File.WriteAllText(currentDirectory,json);
            return $"Task added successfully (ID: {Tasko.Id}).";

        }


        public string Update(int Id, string description, int status)
        {

            if (!File.Exists(currentDirectory))
            {
                File.Create(currentDirectory);
            }

            string text = File.ReadAllText(currentDirectory);

            if (!string.IsNullOrEmpty(text))
                tasks = JsonSerializer.Deserialize<List<TaskO>>(text);
            else 
            {
                return "No existen tareas para actualizar";
                
            }
            TaskO? task = tasks.FirstOrDefault(t => t.Id == Id);
            if (task != null) 
            {
                task.Description = description;
                task.UpdatedAt = DateTime.Now;
                switch (status)
                {
                    case 1:
                        task.Status = EnumStatusType.ToDo.ToString();
                        break;
                        case 2:
                        task.Status = EnumStatusType.InProgress.ToString();
                        break;
                        case 3:
                        task.Status = EnumStatusType.Done.ToString();
                        break;
                }

            }

            string json = JsonSerializer.Serialize<List<TaskO>>(tasks);
            File.WriteAllText(currentDirectory, json);
            return $"Task updated successfully (ID: {task.Id}).";

        }

        public string Delete(int Id)
        {
            if (!File.Exists(currentDirectory))
            {
                File.Create(currentDirectory);
            }
            string text = File.ReadAllText(currentDirectory);
            if (!string.IsNullOrEmpty(text))
                tasks = JsonSerializer.Deserialize<List<TaskO>>(text);
            else
            {
                return "No existen tareas para borrar";
            }

            TaskO task = tasks.FirstOrDefault(t => t.Id == Id);

            tasks.Remove(task);

            string json = JsonSerializer.Serialize<List<TaskO>>(tasks);
            File.WriteAllText(currentDirectory, json);
            return $"Task deleted successfully (ID: {task.Id}).";
        }

        public string ShowTasks()
        {
            if (!File.Exists(currentDirectory))
            {
                File.Create(currentDirectory);
            }
            string text = File.ReadAllText(currentDirectory);
            if (!string.IsNullOrEmpty(text))
                tasks = JsonSerializer.Deserialize<List<TaskO>>(text);
            else
            {
                return "No existen tareas para mostrar";
            }
            
            string result = "ID | Description | Status | Created At | Updated At\n";
            foreach (var task in tasks)
            {
                result += $"{task.Id} | {task.Description} | {task.Status} | {task.CreatedAt} | {task.UpdatedAt}\n";
            }
            return result;


        }


    }

}
