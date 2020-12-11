using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    public class Matric
    {
        static void Main(string[] args)
        {
            try
            { 
                Console.WriteLine("Enter the first dimension ");
                int a = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the second dimension");
                int b = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the third dimension");
                int c = int.Parse(Console.ReadLine());

                Console.WriteLine("Enter the forth dimension ");
                int d = int.Parse(Console.ReadLine());
                if (c != d)
                {
                    Console.WriteLine("Error:The third and forth size must be the same to calculate determinant and square correctly");
                    Console.ReadLine();
                }

                else
                {
                    int[,,,] myarray = new int[a, b, c, d];
                    // Reading the array to the console
                    for (int i = 0; i < a; i++)
                    {
                        for (int j = 0; j < b; j++)
                        {
                            for (int k = 0; k < c; k++)
                            {
                                for (int l = 0; l < d; l++)
                                {
                                    Console.WriteLine("Please enter matrix[{0},{1},{2},{3}]", i, j, k, l);
                                    myarray[i, j, k, l] = int.Parse(Console.ReadLine());
                                }
                            }
                        }

                    }
                    // Displaying the array to the console
                    int det1 = 0;
                    Console.WriteLine();
                    Console.WriteLine("The matrices formed is displayed below");
                    Console.WriteLine();
                    for (int i = 0; i < myarray.GetLength(0); i++)
                    {
                        for (int j = 0; j < myarray.GetLength(1); j++)
                        {
                            for (int k = 0; k < myarray.GetLength(2); k++)
                            {

                                for (int l = 0; l < myarray.GetLength(3); l++)
                                {

                                    Console.Write(myarray[i, j, k, l] + "\t");
                                }
                                Console.WriteLine();
                            }
                            Console.WriteLine();
                        }

                        Console.WriteLine();
                    }
                    // Calculating determinant: Using Crammers Rule/sarrus rule
                    if (c == 3 && d == 3)
                    {
                        for (int k = 0; k < c; k++)
                        {
                            det1 += myarray[0, 0, 0, k] * (myarray[0, 0, 1, (k + 1) % c] * myarray[0, 0, 2, (k + 2) % c] - myarray[0, 0, 1, (k + 2) % c] * myarray[0, 0, 2, (k + 1) % c]);
                        }
                        Console.WriteLine($"The determinant  of the matrix is {det1 }  and the square of the matrix is");
                        Console.WriteLine();

                    }

                    if (c == 4 && d == 4)
                    {

                        int w = myarray[0, 0, 0, 0] * (((myarray[0, 0, 1, 3] * myarray[0, 0, 2, 1] * myarray[0, 0, 3, 2] + myarray[0, 0, 1, 2] * myarray[0, 0, 2, 3] * myarray[0, 0, 3, 1] + myarray[0, 0, 1, 1] * myarray[0, 0, 2, 2] * myarray[0, 0, 3, 3]) -
                            (myarray[0, 0, 1, 2] * myarray[0, 0, 2, 1] * myarray[0, 0, 3, 3] + myarray[0, 0, 1, 1] * myarray[0, 0, 2, 3] * myarray[0, 0, 3, 2] + myarray[0, 0, 1, 3] * myarray[0, 0, 2, 2] * myarray[0, 0, 3, 1])));

                        int x = myarray[0, 0, 0, 1] * (((myarray[0, 0, 1, 3] * myarray[0, 0, 2, 0] * myarray[0, 0, 3, 2] + myarray[0, 0, 1, 2] * myarray[0, 0, 2, 3] * myarray[0, 0, 3, 0] + myarray[0, 0, 1, 0] * myarray[0, 0, 2, 2] * myarray[0, 0, 3, 3]) -
                            (myarray[0, 0, 1, 2] * myarray[0, 0, 2, 0] * myarray[0, 0, 3, 3] + myarray[0, 0, 1, 0] * myarray[0, 0, 2, 3] * myarray[0, 0, 3, 2] + myarray[0, 0, 1, 3] * myarray[0, 0, 2, 2] * myarray[0, 0, 3, 0])));

                        int y = myarray[0, 0, 0, 2] * (((myarray[0, 0, 1, 3] * myarray[0, 0, 2, 0] * myarray[0, 0, 3, 1] + myarray[0, 0, 1, 1] * myarray[0, 0, 2, 3] * myarray[0, 0, 3, 0] + myarray[0, 0, 1, 0] * myarray[0, 0, 2, 1] * myarray[0, 0, 3, 3]) -
                           (myarray[0, 0, 1, 1] * myarray[0, 0, 2, 0] * myarray[0, 0, 3, 3] + myarray[0, 0, 1, 0] * myarray[0, 0, 2, 3] * myarray[0, 0, 3, 1] + myarray[0, 0, 1, 3] * myarray[0, 0, 2, 1] * myarray[0, 0, 3, 0])));

                        int z = myarray[0, 0, 0, 3] * (((myarray[0, 0, 1, 2] * myarray[0, 0, 2, 0] * myarray[0, 0, 3, 1] + myarray[0, 0, 1, 1] * myarray[0, 0, 2, 2] * myarray[0, 0, 3, 0] + myarray[0, 0, 1, 0] * myarray[0, 0, 2, 1] * myarray[0, 0, 3, 2]) -
                            (myarray[0, 0, 1, 2] * myarray[0, 0, 2, 1] * myarray[0, 0, 3, 0] + myarray[0, 0, 1, 0] * myarray[0, 0, 2, 2] * myarray[0, 0, 3, 1] + myarray[0, 0, 1, 1] * myarray[0, 0, 2, 0] * myarray[0, 0, 3, 2])));

                        int result = w - x + y - z;
                        Console.WriteLine($"The determinant of the matrix is {result} and the square is given below");
                        Console.WriteLine();


                    }
                    //To calculate the square of the matrix

                    if (c == 3 && d == 3 || c == 4 && d == 4)
                    {
                        int[,,,] squareResult = new int[a, b, c, d];
                        for (int i = 0; i < myarray.GetLength(0); i++)
                        {
                            for (int j = 0; j < myarray.GetLength(1); j++)
                            {
                                for (int k = 0; k < myarray.GetLength(2); k++)
                                {

                                    for (int l = 0; l < myarray.GetLength(3); l++)
                                    {
                                        squareResult[i, j, k, l] = 0;
                                        for (int m = 0; m < c; m++)
                                        {
                                            squareResult[i, j, k, l] += myarray[i, j, k, m] * myarray[i, j, m, l];

                                        }
                                    }

                                }

                            }


                        }

                        // Displaying the square of the Matrix

                        for (int i = 0; i < myarray.GetLength(0); i++)
                        {
                            for (int j = 0; j < myarray.GetLength(1); j++)
                            {
                                for (int k = 0; k < myarray.GetLength(2); k++)
                                {

                                    for (int l = 0; l < myarray.GetLength(3); l++)
                                    {

                                        Console.Write(squareResult[i, j, k, l] + "\t");
                                    }
                                    Console.WriteLine();
                                }
                                Console.WriteLine();
                            }

                            Console.WriteLine();
                        }

                    }

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

            }
        }
    }
}
