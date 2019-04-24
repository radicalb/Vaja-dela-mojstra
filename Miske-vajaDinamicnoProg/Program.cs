using System;


//vaja miška dinamično programiranje -> miška se lahko premika samo desno ali dol
// v koliko korakih pride do luknje, brez da jo poje muca
namespace Miske1
{
    class Program
    {
        static void Main(string[] args)
        {
            int x = 5;
            int y = 6;

            string[,] polja = new string[x, y];
            for (int i = 0; i < x; i++)
            {
                for (int j = 0; j < y; j++)
                {
                    polja[i, j] = "prazno";
                }
            }

            //dodamo muce
            int stMuc = 2;
            Random rand = new Random();
            for (int k = 0; k < stMuc;k++)
            {
                polja[rand.Next(1, x), rand.Next(1, y)] = "muca";
            }

            polja[x-1, y-1] = "luknja";

            izpisiTabelo(polja);

            int[,] rez = new int[x, y];

            VrniStMoznihPoti(polja, ref rez);

            izpisiTabelo(rez);

            //Console.WriteLine("Hello World!");
        }

        static void izpisiTabelo(string[,] tabela)
        {
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write(("" + tabela[i, j]).PadRight(7));
                }
                Console.WriteLine();
            }
        }

        static void izpisiTabelo(int[,] tabela)
        {
            for (int i = 0; i < tabela.GetLength(0); i++)
            {
                for (int j = 0; j < tabela.GetLength(1); j++)
                {
                    Console.Write((""+tabela[i, j]).PadRight(4));
                }
                Console.WriteLine();
            }
        }

        static void VrniStMoznihPoti(string[,] tabela, ref int[,] rez)
        {
            for (int i = tabela.GetLength(0)-1; i>=0; i--)
            {
                for (int j = tabela.GetLength(1)-1; j>=0 ; j--)
                {
                    rez[i, j] = 0;

                    if (tabela[i, j] == "luknja") {
                        rez[i, j] = 1;
                    }
                    else if (tabela[i, j] == "muca")
                    {
                        rez[i, j] = 0;
                    }
                    else if (j==tabela.GetLength(1)-1 && i < tabela.GetLength(0) - 1)
                    {
                        rez[i, j] = rez[i+1, j];
                    }
                    else if (i == tabela.GetLength(0) - 1 && j < tabela.GetLength(1) - 1)
                    {
                        rez[i, j] = rez[i, j+1];
                    }
                    else
                    {
                        rez[i, j] = rez[i + 1, j] + rez[i, j+1];
                    }
                }



                }
            }
        }
}

