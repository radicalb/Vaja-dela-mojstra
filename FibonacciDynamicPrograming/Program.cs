using System;
using System.Linq;
/// <summary>Treniranje različnih pristopov pri implementaciji fibonaccija
/// </summary>
namespace FibonaciDynamicPrograming
{
    class Program
    {
        static int[] fibRes;
        static int korakov1 = 0, korakov2 = 0;
        static void Main(string[] args)
        {
            Console.WriteLine("Vnesite n: ");
            int n;
            int.TryParse(Console.ReadLine(), out n);
            fibRes = new int[n+1];
            for (int i = 0; i < fibRes.Length; i++)
                fibRes[i] = -1;

            Console.WriteLine("(dinamicno prog.)Fib od n je: {0} v {1} korakih",fibDin(n),korakov1);
            Console.WriteLine("Fib(rec) od n je: {0} v {1} korakih", fibR(n), korakov2);
            Console.WriteLine("Fib(iter) od n je: {0}", fibI(n));
            Console.WriteLine("Fib(linq) od n je: {0}", fibL(n));
        }
        /// <summary>
        /// Statična metoda fibDin. Vrača 
        /// fibonači z uporabo dinamičnega programiranja.
        /// Shrani izračunane vrednosti, tako da jih ni potrebno
        /// po nepotrebnem spet računati.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int fibDin(int n)
        {
            korakov1++;
            'Console.WriteLine("f({0}) ", n);
            if (n <= 1)
            {
                fibRes[n] = n;
                return n;
            }
            else if (fibRes[n] >= 0)
            {
                return fibRes[n];
            }
            else
            {
                fibRes[n] = fibDin(n - 2) + fibDin(n - 1);
                return fibRes[n];
            }
        }

        /// <summary>
        /// Statična metoda fibR. Vrača fibonači z uporabo rekurzije.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int fibR(int n)
        {
            korakov2++;
            if (n <= 1)
            {
                return n;
            }

            return fibR(n - 2) + fibR(n - 1);
        }

        /// <summary>
        /// Statična metoda fibI. Vrača fibonači z uporabo iteracije.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int fibI(int n)
        {
            int nm2=0, nm1=1;

            for (int i = 0; i < n; i++)
            {
                int temp = nm2;
                nm2 = nm1;
                nm1 +=temp;
                
            }

            return nm2;

        }

        /// <summary>
        /// Statična metoda fibL. Vrača fibonači z uporabo rekurzije
        /// in lambda operatorja.
        /// </summary>
        /// <param name="n"></param>
        /// <returns></returns>
        static int FibL(int n) => n <= 1 ? n:FibL(n-2)+FibL(n-1);
    }
    
}
