using ClassLibrary1;
using System.Text.Json;
using System.Text.Json.Serialization;

class Program
{
    static void Main(string[] args)
    {
        Console.Title = "Homework1";
        List<Student> students = new List<Student>();
        var studentFile = "students.json";

        while (true)
        {
            Console.WriteLine("Choose option:");
            Console.WriteLine("1. Add student");
            Console.WriteLine("2. Show stundents list");
            Console.WriteLine("3. Save students to the file");
            Console.WriteLine("4. Get students from the file");
            Console.WriteLine("5. Quit");

            Console.Write("Your choice: ");
            var choice = Console.ReadLine();

            switch (choice)
            {
                case "1":
                    Student student = new Student();

                    Console.Write("Name of student: ");
                    student.Name = Console.ReadLine();

                    Console.Write("Age of student: ");
                    if (int.TryParse(Console.ReadLine(), out int age))
                    {
                        student.Age = age;
                    }

                    student.Address = new Address();
                    Console.Write("Street: ");
                    student.Address.Street = Console.ReadLine();

                    Console.Write("City: ");
                    student.Address.City = Console.ReadLine();

                    students.Add(student);
                    Console.WriteLine("Student was added");

                    Thread.Sleep(2000);
                    Console.Clear();
                    break;

                case "2":
                    if (students.Count < 1)
                    {
                        Console.WriteLine("There is no students to display");
                        Thread.Sleep(2000);
                        Console.Clear();
                        break;
                    }

                    foreach (var student1 in students)
                    {
                        Console.WriteLine($"\nName: {student1.Name}\nAge: {student1.Age}\nStreet: {student1.Address.Street}\nCity: {student1.Address.City}\n");
                    }
                    break;

                case "3":
                    JsonHelper.SaveToJson(students, studentFile);
                    Console.WriteLine("Students saved to the file.\n");
                    break;

                case "4":
                    students = JsonHelper.LoadFromJson<Student>(studentFile);
                    Console.WriteLine("Students loaded from the file.");

                    foreach (var student1 in students)
                    {
                        Console.WriteLine();
                        Console.WriteLine($"Name: {student1.Name}\nAge: {student1.Age}\nStreet: {student1.Address.Street}\nCity: {student1.Address.City}\n");
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Incorrect choice, please try again");
                    break;
            }
        }
    }
}