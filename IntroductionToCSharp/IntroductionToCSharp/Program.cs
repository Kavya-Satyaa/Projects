// See https://aka.ms/new-console-template for more information
//Console.WriteLine("Hello, World!");
using System;

public  class Employee
{
    public string FN;
    public string LN;
    public void printname()
    {
        Console.WriteLine("Name {0} ",FN+LN);
    }
}
public class FTE : Employee
{
    public float yearly_salary;
}
public class PTE : Employee
{
    public float hourly_rate;
}

class Program
{
    public static void Main()
    {
        FTE fulltime = new FTE();
        fulltime.FN = "Kavya";
        fulltime.LN = "Satya";
        fulltime.yearly_salary = 110.2F;
        fulltime.printname();
    }

}
