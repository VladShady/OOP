using System;

class Person
{
    protected int age;

    public void Greet()
    {
        Console.WriteLine("Hello!");
    }

    public void SetAge(int age)
    {
        this.age = age;
    }
}

class Student : Person
{
    public void Study()
    {
        Console.WriteLine("I'm studying");
    }

    public void ShowAge()
    {
        Console.WriteLine($"My age is: {age} years old");
    }
}

class Professor : Person
{
    public void Explain()
    {
        Console.WriteLine("I'm explaining");
    }
}

class StudentProfessorTest
{
    static void Main()
    {
        Person person = new Person();
        person.Greet();

        Student student = new Student();
        Console.Write("Enter student's age: ");
        int studentAge = Convert.ToInt32(Console.ReadLine());
        student.SetAge(studentAge);
        student.Greet();
        student.ShowAge();

        Professor professor = new Professor();
        Console.Write("Enter professor's age: ");
        int professorAge = Convert.ToInt32(Console.ReadLine());
        professor.SetAge(professorAge);
        professor.Greet();
        professor.Explain();
    }
}
