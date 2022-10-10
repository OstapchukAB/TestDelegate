using System.Diagnostics;
using TestDelegate;

class Programm 
{
    delegate T Operation<T>(int x, int y, out string _nameOperation);

    //enum OperationType { addition,substraction,multiplation,division};

    static int Multiply(int x, int y, out string _nameOperation)
    {
        _nameOperation = "*";
        return x * y;
    }

    static int Addition(int x, int y, out string _nameOperation)
    {
        _nameOperation = "+";
        return x + y;
    }


    static int Substraction(int x, int y, out string _nameOperation)
    {
        _nameOperation = "-";
        return x - y;
    }

    static float? Division(int x, int y, out string _nameOperation)
    {
        _nameOperation = "/";
        return y != 0 ? (float)x / (float)y : null;
    }

    public static void Main() 
    {
        int x = 3;
        int y = 4;
        Operation<int> ops = Addition;
        ops += Substraction;
        ops += Multiply;
        Operation<float?> op = Division;
        
        string nameOperation = "";
        foreach (Operation<int> deleg in ops.GetInvocationList())
        {
            
            int res= deleg(x,y,out nameOperation); 
            Console.WriteLine($"{x} {nameOperation} {y} = {res}");
        }

        float? result = op(x, y, out nameOperation);
        Console.WriteLine($"{x} {nameOperation} {y} = {result:F2}");

        Console.ReadKey();
        Environment.Exit(0);    

    }
   


}