using System;

// Define delegate type
// Complete Step 1:............

class Program
{
    public delegate int Operation (int a, int b);

    // Implement delegate methods
    // Complete Step 2:............
    public static int Add(int a, int b)=> a+b;
    public static int Subtract(int a, int b)=> a-b;
    public static int Multiply(int a, int b)=> a*b;
    public static int Divide(int a, int b)=> a/b;

    // Implement callback mechanism
    // Complete Step 3:............
    public static int PerformOperation(int a, int b, Operation op){
        return op(a,b);
    }

    static void Main(string[] args)
    {
        // Input handling
        // Complete Step 4:............
        Console.WriteLine("Enter first number:");
        int num1=int.Parse(Console.ReadLine());

        Console.WriteLine("Enter second number:");
        int num2=int.Parse(Console.ReadLine());

        Console.WriteLine("Enter operation (add, subtract, multiply, divide):");
        string input = Console.ReadLine().ToLower();
        Operation operation=null;
        // Output handling
        // Complete Step 5:............
        switch(input){
            case "add":
            operation = Add;
            break;
            case "subtract":
            operation = Subtract;
            break;
            case "multiply":
            operation = Multiply;
            break;
            case "divide":
            operation = Divide;
            break;
            default:
            return;
        }

        int result = PerformOperation(num1, num2, operation);
        Console.WriteLine("Result: "+result);
    }
}