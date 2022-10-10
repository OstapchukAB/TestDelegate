using System.Diagnostics;
using TestDelegate;

class Programm 
{
    delegate T Operations<T, K1, K2>(K1 val1, K2 val2);
    //*
    enum OperationType { addition,substraction,multiplation,division};
    static int Add(int x, int y) => x + y;
    static int Subtract(int x, int y) => x - y;
    static int Mult(int x, int y) => x * y;
    static float? Division(int x, int y) => y != 0 ? (float)x / (float)y : null;

    static int Multiply(int x, int y, out string NameOperation)
    {
        NameOperation = "*";
        return x * y;
    }
    static int  StaticAdd(int x, int y) => x + y;
    static void Mess(string s) => Console.WriteLine(s);
    static void Ms(string s) => Console.WriteLine("HELLO WORLD!");
    
    delegate int Operation(int x, int y);
    delegate int Operationn(int x, int y, out string _NameOperation);

    delegate void Message(string x);
    delegate void Mes();

    static void DoOperation(int x, int y, Operationn op)
    {
        string typeOperation;
        var res = op(x, y, out typeOperation);
        Console.WriteLine($"{x} {typeOperation} {y} = {res}");
    }

    static Operation SelectOperations(OperationType opType)
    {
        switch (opType)
        {
            case OperationType.addition:
                return Add;
            case OperationType.substraction:
                return Subtract;
            case OperationType.multiplation:
                return Mult;
            //case OperationType.division: 
            //    return new Operations<float?, int, int> (Division);
            default: return null;

        }
    }

    public static void Main() 
    {


        int x, y;
        x = 2;y = 3;
        Operation oper =StaticAdd;    
       // var result = oper(x, y);
       // Console.WriteLine($" result={ result}");
       // foreach (var ls in oper.GetInvocationList())
          //  Console.WriteLine(ls.Method);

        oper += Subtract;
       //result = oper(x, y);
       // Console.WriteLine($" result={result}");
      //  foreach (var ls in oper.GetInvocationList())
         //   Console.WriteLine(ls.Method);

       // oper += new Operation(new Programm().Multiply);
        // result = oper(x, y);
        Console.WriteLine($"{x} {oper.Method.Name} {y} = {oper(x, y)}");

        Console.WriteLine("");
        foreach (var deleg in oper.GetInvocationList())
        {
            Operation op = (Operation)deleg;
            var s = "";
            //if (deleg.Method.Name.Contains(nameof(Subtract)))
            //    s = "substruct";
            Console.WriteLine($"{x} {deleg.Method.Name} {y} = {op(x,y)}");
        }

        //Message mess = Mess;
        //mess += Ms;
        //mess("Hi!");
        Console.WriteLine("");

        Mes ms = Welcome.Print;
        ms += new Hello().Display;

        ms();

       DoOperation(x,y,Multiply);

        GenericDelegates.Method();

        Console.WriteLine("-------------------");

        Operation operation = SelectOperations(opType: OperationType.addition);
        Console.WriteLine($"{x} {OperationType.addition.ToString()} {y} = {operation(x, y)}");

        Console.ReadKey();
        Environment.Exit(0);    

    }
    class Welcome
    {
        public static void Print() => Console.WriteLine("Welcome");
    }
    class Hello
    {
        public void Display() => Console.WriteLine("Привет");
    }


}