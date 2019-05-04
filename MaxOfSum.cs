using System;
using System.Collections.Generic;



namespace final_assignment
{
    public class Program
    {
        static List<List<int>> a = new List<List<int>>
        {
            new List<int>{1,   0 ,  0,  0  },
            new List<int> {10, 24,   0,  0  },    //1>10>100>8  =119
            new List<int>{100, 1,   200, 0  },
            new List<int>{8,   5,   7,  7  },

        };
        static List<List<int>> b = new List<List<int>>
        {
           new List<int> {1,   0 ,  0,  0  },
            new List<int>{8, 4,   0,  0  },
            new List<int>{2, 6,   9, 0  },       //1>8>6>9  =24   //the given example
            new List<int>{8,   5,   9,  3 },
        };

        static List<List<int>> c = new List<List<int>>
        {
            new List<int>{0,   0 ,  0,  0  },
            new List<int>{7, 7,   0,  0  },
            new List<int>{5, 5,   5, 0  },       //0         //all  numbers are no non prime
            new List<int>{3,   5,   11,  3 },
        };


        static List<List<int>> d = new List<List<int>>
        {
            new List<int>{1,  0 },     //1>1   =2
            new List<int>{1, 2, },

        };
        public static void Main(string[] args)
        {

            Console.WriteLine("The Maxmium path (string original) Is : {0}", MaxPath(AddZerosRow(StringToList(readTxt())), 0,0 )); //8186
            Console.WriteLine();
            Console.WriteLine("The Maxmium path (test a) Is: {0}", MaxPath(AddZerosRow(a), 0, 0));
            Console.WriteLine();
            Console.WriteLine("The Maxmium path (test b) Is: {0}", MaxPath(AddZerosRow(b), 0, 0));
            Console.WriteLine();
            Console.WriteLine("The Maxmium path (test c) Is : {0}", MaxPath(AddZerosRow(c), 0, 0));
            Console.WriteLine();
            Console.WriteLine("The Maxmium path (test c) Is : {0}", MaxPath(AddZerosRow(d), 0, 0));
            Console.WriteLine();
            Console.ReadLine();

        }

        //function to read the string that contain the numbers
        static public string readTxt()
        {
            const string x = @"     215
                                   193 124
                                  117 237 442
                                218 935 347 235
                              320 804 522 417 345
                            229 601 723 835 133 124
                          248 202 277 433 207 263 257
                        359 464 504 528 516 716 871 182
                      461 441 426 656 863 560 380 171 923
                     381 348 573 533 447 632 387 176 975 449
                   223 711 445 645 245 543 931 532 937 541 444
                 330 131 333 928 377 733 017 778 839 168 197 197
                131 171 522 137 217 224 291 413 528 520 227 229 928
              223 626 034 683 839 053 627 310 713 999 629 817 410 121
            924 622 911 233 325 139 721 218 253 223 107 233 230 124 233";

            return x;
        }
        

        //function to convert the string text into list of list<int>
        static public List<List<int>> StringToList(string txt)
        {
            var charArray = txt.Split('\n');
            int rows = charArray.Length;
            int[,] list = new int[rows, rows];

            for (int i = 0; i < charArray.Length; i++)
            {
                var numArr = charArray[i].Trim().Split(' ');

                for (int j = 0; j < numArr.Length; j++)
                {
                    int number = Convert.ToInt32(numArr[j]);
                    list[i, j] = number;
                }
            }

            //convert array to list
            List<List<int>> b = new List<List<int>>();
            for (int i = 0; i < list.GetLength(0); i++)
            {
                List<int> aa = new List<int>();
                for (int j = 0; j < list.GetLength(1); j++)
                {
                    aa.Add(list[i, j]);
                }
                b.Insert(i, aa);
            }


            return b;
        }

        //function to add row of zeros(list) at the end of the list
        static public List<List<int>> AddZerosRow(List<List<int>> b)
        {
            int Rows = b.Count;
            //create zeros list (row)
            List<int> zerosRow = new List<int>();
            for (int i = 0; i <= Rows; i++)
            {
                zerosRow.Add(0);
            }

            //we add this row to deal with the last row in the orignal list
            b.Add(zerosRow);

            //complete every row to (Number of Rows) values by adding zero
            for (int i = 0; i < Rows; i++)
            {
                if (b[i].Count <= Rows)
                {
                    for (int j = i + 1; j < Rows; j++)
                    {
                        b[i].Add(0);
                    }

                }

            }

            return b;
        }
        //function to check if the number is prime or not and return boolean value
        static public bool PrimeChecker(int num)
        {
            if (num == 0 || num == 1)
            {
                return false;
            }
            else
            {
                for (int a = 2; a <= (int)Math.Floor(Math.Sqrt(num)); a++)
                {
                    if (num % a == 0)
                    {
                        return false;
                    }

                }
                return true;
            }
        }

        //function to calculate the maximum path to the bottom with nonprime numbers
        public static int MaxPath(List<List<int>> arr, int x, int y)
        {
            if (x >= arr.Count - 1)
                return 0;
            if (PrimeChecker(arr[x][y]))
                return 0;

            if (!PrimeChecker(arr[x + 1][y]) || !PrimeChecker(arr[x + 1][y + 1]))
            {
                return arr[x][y] + Math.Max(MaxPath(arr, x + 1, y), MaxPath(arr, x + 1, y + 1));

            }
           
            else return 0;


        }

    }
}
