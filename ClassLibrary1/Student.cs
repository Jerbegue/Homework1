﻿namespace ClassLibrary1
{
    public class Student
    {
        public string? Name { get; set; }
        public int Age { get; set; }
        public Address Address { get; set; } = default!;
    }
}
