using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace final_assignment
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("=================== Before resetting the prime numbers ===============");

            foreach (var item in ConvertSArrngToListOfIntList(readTxt()))
            {
                foreach (var i in item)
                {
                    Console.Write(i + " \t");
                }
                Console.WriteLine();
            }
            Console.WriteLine();
            Console.WriteLine("=================== After resetting the prime numbers ===============");
            Console.WriteLine();
            foreach (var item in ConvertPrimeToZero(ConvertSArrngToListOfIntList(readTxt())))
            {
                foreach (var i in item)
                {
                    Console.Write(i + " \t");
                }
                Console.WriteLine();
            }

            Console.WriteLine();
            Console.WriteLine("the maxmium sum is : {0}", MaxPathSum(ConvertPrimeToZero(ConvertSArrngToListOfIntList(readTxt()))));



            Console.ReadLine();
        }

        //function to read the sArrng that contain the numbers
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

        //function to convert the sArrng text into list of list<int>
        static public List<List<int>> ConvertSArrngToListOfIntList(string txt)
        {
            //calculate the number of rows inside the sArrng
            int Rows = 1;
            foreach (var item in txt)
            {
                if (item == '\n') Rows++;
            }
            //create an array by line characters
            string[] arr = txt.Split('\n');
            List<List<int>> b = new List<List<int>>();
            for (int i = 0; i < Rows; i++)
            {

                MatchCollection mc = Regex.Matches(arr[i], @"\d{3}");
                List<int> aa = new List<int>();
                foreach (Match item in mc)
                {
                    int y = int.Parse(item.Value);
                    aa.Add(y);
                }

                b.Insert(i, aa);
            }
            //complete every row to 15 values by adding zero
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
        //function to convert  ALL the prime numbers inside the list into zeros
        public static List<List<int>> ConvertPrimeToZero(List<List<int>> Arr)
        {
            var length = Arr.Count;
            for (var i = 0; i < length; i++)
            {
                for (var j = 0; j < length; j++)
                {
                    if (Arr[i][j] == 0) continue;
                    if (PrimeChecker(Arr[i][j]))
                        Arr[i][j] = 0;
                }
            }
            return Arr;
        }
        //function to calculate the maximum sum of the numbers
        public static int MaxPathSum(List<List<int>> Arr)
                       
        {
            int m = Arr.Count-1;
            int n = Arr.Count - 1;
            // loop for bottom-up calculation 
            for (int i = m - 1; i >= 0; i--)
            {
                for (int j = 0; j <= i; j++)
                {
                    // for each element, 
                    // check both elements 
                    // just below the number 
                    // and below right to 
                    // the number add the 
                    // maximum of them to it 
                    if (Arr[i + 1][j] >
                    Arr[i + 1][j + 1])
                        Arr[i][j] +=
                            Arr[i + 1][j];
                    else
                        Arr[i][j] +=
                        Arr[i + 1][j + 1];
                }
            }


            // return the top element 
            // which stores the maximum sum 
            return Arr[0][0];
        }

    }
}
