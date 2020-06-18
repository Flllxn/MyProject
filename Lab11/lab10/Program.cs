using System;

namespace lab11
{
    class Program
    {
        static void Main(string[] args)
        {
            Facade facade = new Facade("Haidamaka Daniil");
            facade.AddGroup("Group1");
            facade.AddTask("New one", "Group1");
        }
    }

    public class Facade
    {
        public DB Obj = new DB();
        public string Fullname { get; set; }

        public Facade(string fullname)
        {
            if(fullname != null)
            {
                Fullname = fullname;
            }
        }

        public Task AddTask(string name, string groupName)
        {
            Obj.Write();
            return new Task(name, groupName);
        }

        public Group AddGroup(string name)
        {
            Obj.Write();
            return new Group(name);
        }
    }

    public class Task
    {
        public string Name { get; set; }
        public string GroupName { get; set; }

        public Task(string name, string groupName)
        {
            if(name != null)
            {
                Name = name;
            }

            if(groupName != null)
            {
                GroupName = groupName;
            }

            Console.WriteLine("Задача создана");
        }

    }

    public class Group
    {
        public string Name { get; set; }

        public Group(string name)
        {
            if(name != null)
            {
                Name = name;
            }

            Console.WriteLine("Группа создана");
        }
    }

    public class DB
    {
        public string Name { get; set; }
        public string Password { get; set; }
        public string TableName { get; set; }

        public DB()
        { }

        public string Select()
        {
            return "tasks";
        }

        public void Write()
        {
            Console.WriteLine("Writing to DB");
        }
    }
    
}
