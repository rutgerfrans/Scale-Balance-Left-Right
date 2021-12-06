using System;
using System.Collections.Generic;
using System.Linq;

namespace PI7Gewichten
{
    class Program
    {
        static void Main(string[] args)
        {
            List<int> gewichten = new List<int>() {1, 67, 54, 28, 4, 84, 6, 53, 18, 76, 98, 32, 15 };
            List<int> Left = new List<int>((1+gewichten.Count)/2);
            List<int> Right = new List<int>((1+gewichten.Count)/2);

            string Lijst = Print(gewichten);
            Console.WriteLine("Alle gewichten:\n" + Lijst + "\n");
            balance(gewichten, Left, Right);

            Lijst = Print(Left);
            Console.WriteLine("Alle gewichten:\n" + Lijst + "\n" + "Totaal:" + Left.Sum());

            Lijst = Print(Right);
            Console.WriteLine("Alle gewichten:\n" + Lijst + "\n" + "Totaal:" + Right.Sum());
        }

        private static string Print(List<int> List)
        {
            string ListText = "";
            foreach (var item in List)
            {
                ListText += item + " ";
            }
            return ListText;
        }

        private static void balance(List<int> gewichten, List<int> Left, List<int> Right)
        {
            //V2
            while (gewichten.Count > 0)
            {
                if (Left.Sum() == Right.Sum())
                {
                    Left.Add(gewichten.First());
                    gewichten.Remove(gewichten.First());
                }
                int Diff = 0;
                int Index = 0;

                for (int i = 0; i < gewichten.Count; i++)
                {
                    if (gewichten[i] > Diff)
                    {
                        Diff = gewichten[i];
                        Index = i;
                    }
                }

                if (Left.Sum() > Right.Sum())
                {
                    Right.Add(gewichten[Index]);
                    gewichten.RemoveAt(Index);
                }
                else if (Left.Sum() < Right.Sum())
                {
                    Left.Add(gewichten[Index]);
                    gewichten.RemoveAt(Index);
                }
                balance(gewichten, Left, Right);
            }     
                /* Oud
                while (gewichten.Count > 0)
                {
                    if (Left.Sum() == Right.Sum())
                    {
                        Left.Add(gewichten.First());
                        gewichten.Remove(gewichten.First());
                    }

                    int Diff = Math.Abs(Left.Sum() - Right.Sum());
                    int Offset = Diff;
                    int Index = 0;

                    for (int i = 0; i < gewichten.Count; i++)
                    {
                        if (gewichten[i] - Diff <= Offset)
                        {
                            Offset = gewichten[i] - Diff;
                            Index = i;
                        }
                    }

                    if (Left.Sum() > Right.Sum())
                    {
                        Right.Add(gewichten[Index]);
                        gewichten.RemoveAt(Index);
                    }
                    else if (Left.Sum() < Right.Sum())
                    {
                        Left.Add(gewichten[Index]);
                        gewichten.RemoveAt(Index);
                    }


                    balance(gewichten, Left, Right);
                }
                */
            }

    }
}
