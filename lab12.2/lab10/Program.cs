using System;
using System.Collections.Generic;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            User user = new User("Haidamaka Danil");
            user.AddTask("TO DO smth");

            TaskHistory history = new TaskHistory();
            history.History.Push(user.SaveState());
            user.ShowTasks();

            user.AddTask("TO DO smth 2.0");
            user.ShowTasks();

            user.RestoreState(history.GetLast());
            user.ShowTasks();


        }
    }

    // Originator
    
    class User
    {
        public string Fullname { get; set; }
        public List<string> Tasks = new List<string>();

        public User(string fullname)
        {
            Fullname = fullname;
        }

        public void AddTask(string name)
        {
            this.Tasks.Add(name);
        }

        public void ShowTasks()
        {
            foreach (string i in this.Tasks)
            {
                Console.WriteLine(i);
            }
        }

        public TaskMemento SaveState()
        {
            Console.WriteLine("Сохранение.");
            List<string> backup = new List<string>();
            foreach (string task in Tasks)
            {
                backup.Add(task);
            }
            return new TaskMemento(backup);
        }

        public void RestoreState(TaskMemento memento)
        {
            this.Tasks = memento.Tasks;
            
            Console.WriteLine("Восстановление");
        }
    }

    class TaskMemento
    {
        public List<string> Tasks { get; set; }

        public TaskMemento(List<string> tasks)
        {
            this.Tasks = tasks;
        }
    }


    // Caretaker
    class TaskHistory
    {
        public Stack<TaskMemento> History;
        public TaskHistory()
        {
            History = new Stack<TaskMemento>();
        }

        public TaskMemento GetLast()
        {
            return History.Pop();
        }

    }

}
