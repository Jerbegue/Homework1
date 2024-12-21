namespace ClassLibrary2
{
    public class Student
    {
        public string Name { get; set; } = default!;
        public string UniversityName { get; set; } = default!;

        public Student(string name, string universityName)
        {
            Name = name;
            UniversityName = universityName;
        }
    }
}
