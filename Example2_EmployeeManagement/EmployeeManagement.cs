using System;

// Base class - Employee
public class Employee
{
    protected string name;
    protected int id;
    protected double baseSalary;
    
    public Employee(string name, int id, double baseSalary)
    {
        this.name = name;
        this.id = id;
        this.baseSalary = baseSalary;
    }
    
    // Virtual method to calculate salary (will be overridden)
    public virtual double CalculateSalary()
    {
        return baseSalary;
    }
    
    // Virtual method to display responsibilities
    public virtual void DisplayResponsibilities()
    {
        Console.WriteLine("General employee responsibilities");
    }
    
    // Display employee details
    public void DisplayInfo()
    {
        Console.WriteLine($"Name: {name}");
        Console.WriteLine($"ID: {id}");
        Console.WriteLine($"Salary: ${CalculateSalary():F2}");
        DisplayResponsibilities();
        Console.WriteLine("------------------------");
    }
}

// Manager class - Inherits from Employee
public class Manager : Employee
{
    private double bonus;
    private int teamSize;
    
    public Manager(string name, int id, double baseSalary, double bonus, int teamSize) 
        : base(name, id, baseSalary)
    {
        this.bonus = bonus;
        this.teamSize = teamSize;
    }
    
    public override double CalculateSalary()
    {
        return baseSalary + bonus;
    }
    
    public override void DisplayResponsibilities()
    {
        Console.WriteLine($"Responsibilities: Lead team of {teamSize} members");
        Console.WriteLine("- Project planning and management");
        Console.WriteLine("- Team performance evaluation");
    }
}

// Developer class - Inherits from Employee
public class Developer : Employee
{
    private string programmingLanguage;
    private int projectsCompleted;
    
    public Developer(string name, int id, double baseSalary, string language, int projects) 
        : base(name, id, baseSalary)
    {
        this.programmingLanguage = language;
        this.projectsCompleted = projects;
    }
    
    public override double CalculateSalary()
    {
        // Bonus based on projects completed
        return baseSalary + (projectsCompleted * 500);
    }
    
    public override void DisplayResponsibilities()
    {
        Console.WriteLine("Responsibilities: Software Development");
        Console.WriteLine($"- Primary Language: {programmingLanguage}");
        Console.WriteLine($"- Projects Completed: {projectsCompleted}");
    }
}

// Intern class - Inherits from Employee
public class Intern : Employee
{
    private int monthsRemaining;
    
    public Intern(string name, int id, double baseSalary, int months) 
        : base(name, id, baseSalary)
    {
        this.monthsRemaining = months;
    }
    
    public override double CalculateSalary()
    {
        // Interns get 50% of base salary
        return baseSalary * 0.5;
    }
    
    public override void DisplayResponsibilities()
    {
        Console.WriteLine("Responsibilities: Learning and Assisting");
        Console.WriteLine($"- Internship Duration Remaining: {monthsRemaining} months");
        Console.WriteLine("- Training and skill development");
    }
}

// Main Program
class Program
{
    static void Main(string[] args)
    {
        Console.WriteLine("=== Employee Management System ===\n");
        
        // Creating different types of employees
        Employee manager = new Manager("Ali Khan", 101, 80000, 20000, 10);
        Employee developer = new Developer("Sara Ahmed", 102, 60000, "C#", 15);
        Employee intern = new Intern("Ahmed Raza", 103, 30000, 6);
        
        // Displaying information (Polymorphism in action)
        manager.DisplayInfo();
        developer.DisplayInfo();
        intern.DisplayInfo();
        
        Console.ReadLine();
    }
}
