using System;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Task task = new Task("Do lab 11", new ToDoGroup());
            task.ShowGroup();
            task.Group = new InProcessGroup();
            task.ShowGroup();
            task.Group = new DoneGroup();
            task.ShowGroup();

        }
    }
    interface IGroup
    {
        void ShowGroup();
    }

    class ToDoGroup : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine("Группа: TO DO");
        }
    }

    class InProcessGroup : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine("Группа: В разработке");
        }
    }

    class DoneGroup : IGroup
    {
        public void ShowGroup()
        {
            Console.WriteLine("Группа: Сделано");
        }
    }
    class Task
    {
        protected string Name;

        public Task(string name, IGroup mov)
        {
            Name = name;
            Group = mov;
        }

        public IGroup Group { private get; set; }
        public void ShowGroup()
        {
            Group.ShowGroup();
        }
    }

}
