using labb1Entity.Models;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System;

namespace labb1Entity
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int input = 0;
            bool menu = true;
            string name = "";

            //Körde första gången..
            //AddSomePeople();



            while (menu)
            {
                Console.Clear();
                Console.WriteLine("***********************************");
                Console.WriteLine("*                                 *");
                Console.WriteLine("*     Application For Leave       *");
                Console.WriteLine("*   Enter choice for ur purpose   *");
                Console.WriteLine("* 1  User                         *");
                Console.WriteLine("* 2  Admin                        *");
                Console.WriteLine("* 3  Search person                *");
                Console.WriteLine("* 4  End program                  *");
                Console.WriteLine("***********************************");

                try
                {
                    input = Convert.ToInt32(Console.ReadLine());
                }
                catch 
                {
                    input = 4;
                    Console.Clear();
                }
                switch (input)
                {
                    case 1:
                        Console.Clear();
                        CreateAppUser();
                        break;
                    case 2:
                        Console.Clear();
                        AdminSearch();
                        break;
                    case 3:
                        SearchPerson(name);
                        break;
                    case 4:
                        Console.WriteLine("Ending program..");
                        menu = false;
                        break;

                    default:
                        ErrorMessage();
                        Console.ReadLine();
                        Console.Clear();
                        break;
                }
            }
            
            Console.ReadLine();
        }
        public static void CreateAppUser()
        {
            Console.Clear();
            string name = "", leave = "";
            string phone = ""; 
            int startYear = 0, startMonth = 0, startDay = 0;
            int endYear = 0, endMonth = 0, endDay = 0;

            Console.Write("Enter ur name:");
            name = Console.ReadLine();

            Console.Write("Enter type of leave:");
            leave = Console.ReadLine();

            try
            {
                Console.Write("Enter ur phone number:");
                phone = Console.ReadLine();

                Console.WriteLine("Start date for leave:");
                Console.Write("Enter year:");
                startYear = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter month:");
                startMonth = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter day:");
                startDay = Convert.ToInt32(Console.ReadLine());

                Console.WriteLine("End date for leave:");
                Console.Write("Enter year:");
                endYear = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter month:");
                endMonth = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter day:");
                endDay = Convert.ToInt32(Console.ReadLine());


            }
            catch
            {
                ErrorMessage();
                CreateAppUser();
            }
            


            using (var context = new PeopleContext())
            {
                var App = new ApplicationForLeave()
                {
                    EmployeeName = name,
                    EployeePhone = phone,
                    TypeOFLeave = leave,
                    DateStartForLeave = new DateTime(startYear, startMonth, startDay),
                    DateEndForLeave = new DateTime(endYear, endMonth, endDay),
                    
                };
                context.Entry(App).State = EntityState.Added;
                context.SaveChanges();
            }
            SearchPerson(name);


        }
        public static void SearchPerson(string name)
        {
            
            PeopleContext context = new PeopleContext();

            if (name.Length == 0)
            {
                Console.Write("Enter name u want to search for:");
                name = Console.ReadLine();
            }
            var emp = from p in context.ApplicationForLeaves
                      where p.EmployeeName == name
                      orderby p.EmployeeName
                      select p;

            Console.Clear(); 
            if (emp.Count() > 0)
            {
                foreach (var item in emp)
                {
                    Console.WriteLine($"ID: {item.Id} | Name: {item.EmployeeName} | Phone: {item.EployeePhone} | Type of leave: {item.TypeOFLeave} | Start date: {item.DateStartForLeave} | End date: {item.DateEndForLeave}");
                    Console.WriteLine(new string('-', (150)));
                    Console.WriteLine();
                }
            }
            else
            {
                Console.WriteLine("Couldnt find a person with that name...");
            }

            Console.ReadKey();
        }
        public static void AdminSearch()
        {
            int month = 0;
            PeopleContext context = new PeopleContext();

            

            Console.WriteLine("Which month ? (1-12)");
            try
            {
                month = Convert.ToInt32(Console.ReadLine());
            }
            catch
            {
                ErrorMessage();
            }
            Console.Clear();
                
                var empMonth = from p in context.ApplicationForLeaves
                             where p.DateStartForLeave.Month == month
                             orderby p.EmployeeName
                             select p;

                if (empMonth.Count() > 0)
                {
                    foreach (var item in empMonth)
                    {
                        Console.WriteLine($"Name: {item.EmployeeName} | Type of leave: {item.TypeOFLeave} | Start date: {item.DateStartForLeave} " +
                            $"| End date: {item.DateEndForLeave} | Days: {item.DateEndForLeave.Day - item.DateStartForLeave.Day} | Date for app: {item.DateOfApplication}");
                        Console.WriteLine(new string('-', (150)));
                        Console.WriteLine();
                    }
                }
                else
                {
                    Console.WriteLine("Found no application for that month...");
                }

                Console.ReadLine();

                          
      
         
        }
        public static void ErrorMessage()
        {
            Console.WriteLine("Wrong input, try again...");
            Console.ReadLine();
        }
        public static void AddSomePeople()
        {


            using (var context = new PeopleContext())
            {
                var App = new ApplicationForLeave()
                {
                    EmployeeName = "Greta thunberg",
                    EployeePhone = "0703425678",
                    TypeOFLeave = "Vab",
                    DateStartForLeave = new DateTime(2022, 2, 3),
                    DateEndForLeave = new DateTime(2022, 2, 5),

                };

                var App2 = new ApplicationForLeave()
                {
                    EmployeeName = "Göran Person",
                    EployeePhone = "0701337143",
                    TypeOFLeave = "Semester",
                    DateStartForLeave = new DateTime(2022, 2, 6),
                    DateEndForLeave = new DateTime(2022, 3, 15),

                };

                var App3 = new ApplicationForLeave()
                {
                    EmployeeName = "John Doe",
                    EployeePhone = "0735411337",
                    TypeOFLeave = "Semester",
                    DateStartForLeave = new DateTime(2022, 3, 3),
                    DateEndForLeave = new DateTime(2022, 3, 13),

                };

                var App4 = new ApplicationForLeave()
                {
                    EmployeeName = "Snurre Sprätt",
                    EployeePhone = "0709998877",
                    TypeOFLeave = "Vab",
                    DateStartForLeave = new DateTime(2022, 4, 3),
                    DateEndForLeave = new DateTime(2022, 4, 5),

                };
                context.Entry(App).State = EntityState.Added;
                context.Entry(App2).State = EntityState.Added;
                context.Entry(App3).State = EntityState.Added;
                context.Entry(App4).State = EntityState.Added;
                context.SaveChanges();
            }
        }
    }
}
