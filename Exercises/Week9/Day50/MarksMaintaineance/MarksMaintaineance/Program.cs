using System;
using System.Collections.Generic;

class Student
{
    public int StuID { get; set; }
    public string SName { get; set; }

    public static Dictionary<Student, int> studentMarks = new Dictionary<Student, int>();

    public Student(int id, string name)
    {
        StuID = id;
        SName = name;
    }

    public override bool Equals(object obj)
    {
        Student s = obj as Student;
        return this.StuID == s.StuID && this.SName== s.SName;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(StuID, SName);
    }

    public static void AddOrUpdate(Student s, int marks)
    {
        if (studentMarks.ContainsKey(s))
        {
            if (marks > studentMarks[s])
            {
                studentMarks[s] = marks;
            }
        }
        else
        {
            studentMarks.Add(s, marks);
        }
    }

    public static void Display()
    {
        foreach (var item in studentMarks)
        {
            Console.WriteLine(item.Key.StuID + " " + item.Key.SName + " Marks: " + item.Value);
        }
    }
}

class Program
{
    static void Main()
    {
        Student.AddOrUpdate(new Student(1, "Shreya"), 70);
        Student.AddOrUpdate(new Student(2, "Sweta"), 80);
        Student.AddOrUpdate(new Student(1, "Shreya"), 85);
        Student.AddOrUpdate(new Student(2, "Sweta"), 75);

        Console.WriteLine("Latest Data:");
        Student.Display();
    }
}