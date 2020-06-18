using System;

namespace lab10
{
    class Program
    {
        static void Main(string[] args)
        {
            Developer groupDeveloper = new GroupDeveloper("Lastname Firtsname");
            Object group = groupDeveloper.Create("TO DO");

            Developer taskDeveloper = new TaskDeveloper("Lastname Firstname");
            Object task = taskDeveloper.Create("do laboratory work");

        }
    }
    // абстрактный класс создателя групп и задач
    abstract class Developer
    {
        public string Fullname { get; set; }

        // фабричный метод
        abstract public MySystem Create(string name);
    }
    // создает группы
    class GroupDeveloper : Developer
    {
        public GroupDeveloper(string fullname)
        {
            Fullname = fullname;
        }
        public override MySystem Create(string name)
        {
            return new Group(name);
        }
    }
    // создает задачи
    class TaskDeveloper : Developer
    {
        public TaskDeveloper(string fullname)
        {
            Fullname = fullname;
        }
        public override MySystem Create(string name)
        {
            return new Task(name);
        }
    }

    abstract class MySystem
    { }

    class Group : MySystem
    {
        public string Name { get; set; }
        public Group(string name)
        {
            Name = name;
            string output = String.Format("Группа создана - {0}", Name);
            Console.WriteLine(output);
        }
    }
    class Task : MySystem
    {
        public string Name { get; set; }
        public Task(string name)
        {
            Name = name;
            string output = String.Format("Задача создана - {0}", Name);
            Console.WriteLine(output);
        }
    }
}