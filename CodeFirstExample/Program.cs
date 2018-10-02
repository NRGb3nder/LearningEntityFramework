using System;

namespace CodeFirstExample
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var context = new SchoolContext())
            {
                var student1 = new Student { StudentName = "Sam", Height = 180, Weight = 74.6f };
                var student2 = new Student { StudentName = "John", Height = 174, Weight = 67.5f };

                context.Students.Add(student1);
                context.Students.Add(student2);
                context.SaveChanges();

                Console.WriteLine("Done:");
                foreach (var student in context.Students)
                {
                    Console.WriteLine("{0}. Height: {1}, Weight: {2}", student.StudentName, 
                        student.Height, student.Weight);
                }
            }

            Console.ReadLine();
        }
    }
}
