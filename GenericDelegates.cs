using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestDelegate
{
    static class GenericDelegates
    {
        delegate T Operation<T, K>(K val);
        delegate T Operations<T, K1, K2>(K1 val1,K2 val2);
        public static void Method() {
            int x = 6;
            int y = 7;
            Operation<decimal, int> squareOperation = Square;
            decimal result1 = squareOperation(x);
            Console.WriteLine($"{x} {nameof(Square) } {result1}");  // 25

            Operation<int, int> doubleOperation = Double;
            int result2 = doubleOperation(x);
            Console.WriteLine($"{x} {nameof(Double)} {result2}");  // 10

            //Operations<float?, int, int> divisionOperation = Division;
            var divisionOperation =new Operations<float?, int, int>(Division);

            var res = divisionOperation(x, y);
            Console.WriteLine($"{x} / {y} = {res:F2}");  



            decimal Square(int n) => n * n;
            int Double(int n) => n + n;
            float? Division(int x, int y) => y != 0 ? (float)x / (float)y : null;

           
        }
    }
}
