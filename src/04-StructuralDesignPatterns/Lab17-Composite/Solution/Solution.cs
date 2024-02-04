using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab17_Composite.Solution
{
    public interface ITask
    {
        public string Title { get; set; }
        void Display();
    }

    public class SimpleTask : ITask
    {
        public SimpleTask(string title)
        {
            this.Title = title;
        }
        public string Title { get; set; }

        public void Display() { 
            Console.WriteLine($"Simple Task {Title}");
        }
    }

    public class TaskList : ITask{
        private List<ITask> _tasks;
        public string Title { get; set; }
        public TaskList(string title)
        {
            this.Title = title;
            this._tasks = new List<ITask>();
        }
        public void Display(){
            Console.WriteLine($"Task List: {Title}");
            foreach(var t in _tasks){
                t.Display();
            }
        }
        public void AddTask(ITask task){
            _tasks.Add(task);
        }
        public void RemoveTask(ITask task){
            _tasks.Remove(task);
        }
    }


    public class Application{
        public void Test(){
        //    Programming Technologies
        //    |__ Frontend
        //    |______ Javascript
        //    |______ HTML
        //    |______ Typescript
        //    |______ CSS
        //    |__ Backend
        //    |______ C#
        //    |______ SQL Server
        //    |______ RabbitMq
        //    |______ NServiceBus

            var taskList = new TaskList("Programming Technologies");

            var frontendList = new TaskList("Frontend");
            frontendList.AddTask(new SimpleTask("Javascript"));
            frontendList.AddTask(new SimpleTask("HTML"));
            frontendList.AddTask(new SimpleTask("Typescript"));
            frontendList.AddTask(new SimpleTask("CSS"));

            var backendList = new TaskList("Backend");
            backendList.AddTask(new SimpleTask("C#"));
            backendList.AddTask(new SimpleTask("SQL Server"));
            backendList.AddTask(new SimpleTask("RabbitMq"));
            backendList.AddTask(new SimpleTask("NServiceBus"));

            taskList.AddTask(frontendList);
            taskList.AddTask(backendList);

            taskList.Display();
        }
    }
}
