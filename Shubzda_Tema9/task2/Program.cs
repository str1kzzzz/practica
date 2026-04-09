using System;
using System.IO;
using System.Collections.Generic;
class Student
{
    public string Name;
    public int Score;
    public Student(string name, int score)
    {
        Name = name;
        Score = score;
    }
}
class StudentFileWriter
{
    public void WriteSortedStudents(List<Student> students)
    {
        students.Sort((a, b) => a.Score.CompareTo(b.Score));
        StreamWriter sw = new StreamWriter("file.data");
        for (int i = 0; i < students.Count; i++)
        {
            sw.WriteLine(students[i].Name + " " + students[i].Score);
        }
        sw.Close();
    }
}
class Program
{
    static void Main()
    {
        List<Student> students = new List<Student>();
        students.Add(new Student("Иван", 78));
        students.Add(new Student("Анна", 95));
        students.Add(new Student("Олег", 84));
        students.Add(new Student("Мария", 67));
        StudentFileWriter writer = new StudentFileWriter();
        writer.WriteSortedStudents(students);
        Console.WriteLine("Данные записаны в file.data");
    }
}