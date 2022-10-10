using System.Diagnostics;
using TestDelegate;

class Programm 
{
    int Add(int x, int y) => x + y;
    static int Subtract(int x, int y) => x - y;
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