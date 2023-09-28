using System;

public class Program
{
    static void Main()
    {
        Console.WriteLine(Environment.GetFolderPath(Environment.SpecialFolder.System));
        bool exit = false;
        while (!exit)
        {
            Console.WriteLine("----- Select an Option -----");
            Console.WriteLine("1. CRUD");
            Console.WriteLine("2. XML Example");
            Console.WriteLine("9. Exit");
            Console.WriteLine("----------------------------");
            Console.Write("Select an option: ");

            string option = Console.ReadLine();
            Console.WriteLine();
            switch (option)
            {
                case "1":
                    CRUD.CRUDMain();
                    break;  
                case "2":
                    Books.SaveLogics();
                    break;
                case "9":
                    exit = true;
                    break;
                default:
                    break;
            }
        }
    }
}
