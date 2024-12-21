using ClassLibrary2;

internal class Program2
{
    private static void Main(string[] args)
    {
        Console.Title = "Homework2";
        List<University> universities = new List<University>();
        List<Student> students = new List<Student>();

        while (true)
        {
            Console.WriteLine("Choose option.");
            Console.WriteLine("1. Add university");
            Console.WriteLine("2. Add student");
            Console.WriteLine("3. Find students by university");
            Console.WriteLine("4. Get university of student");
            Console.WriteLine("5. Quit");

            Console.Write("Your choice: ");
            string? choice = Console.ReadLine();
            switch (choice)
            {
                case "1":
                    Console.Write("Write the name of university: ");
                    string? universityName = Console.ReadLine();
                    if (universityName != null)
                    {
                        universities.Add(new University(universityName!));
                        Console.WriteLine("University was added");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect university name");
                    }
                    break;

                case "2":
                    Console.Write("Write the students name: ");
                    string? studentName = Console.ReadLine();

                    if (!universities.Any())
                    {
                        Console.WriteLine("You need to add some university first");
                        break;
                    }

                    Console.WriteLine("Available universities:");
                    for (int i = 0; i < universities.Count; i++)
                    {
                        Console.WriteLine($"{i + 1}. {universities[i].Name}");
                    }

                    Console.Write("Choose university (write number): ");
                    if (int.TryParse(Console.ReadLine(), out int universityIndex) && universityIndex > 0 && universityIndex <= universities.Count)
                    {
                        students.Add(new Student(studentName, universities[universityIndex - 1].Name));
                        Console.WriteLine("Student was added");
                    }
                    else
                    {
                        Console.WriteLine("Incorrect choice");
                    }
                    break;

                case "3":
                    Console.Write("Write the name of university for students search: ");
                    string? searchUniversity = Console.ReadLine();

                    var foundStudents = students.Where(s => s.UniversityName == searchUniversity).ToList();
                    if (foundStudents.Any())
                    {
                        Console.WriteLine($"Students of university {searchUniversity}:");
                        foreach (var student in foundStudents)
                        {
                            Console.WriteLine($"- {student.Name}");
                        }
                    }
                    else
                    {
                        Console.WriteLine("Students not found.");
                    }
                    break;

                case "4":
                    Console.Write("Write the name of student: ");
                    string searchStudent = Console.ReadLine();

                    var studentInfo = students.FirstOrDefault(s => s.Name == searchStudent);
                    if (studentInfo != null)
                    {
                        Console.WriteLine($"{studentInfo.Name} is at university {studentInfo.UniversityName}.");
                    }
                    else
                    {
                        Console.WriteLine("Student not found");
                    }
                    break;

                case "5":
                    return;

                default:
                    Console.WriteLine("Incorrect choice");
                    break;
            }
        }
    }
}