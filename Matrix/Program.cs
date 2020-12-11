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
            int k, p;
            int[,] aar1 = new int[10, 10];
            int de = 0;


            Console.Write("\n The determinant of 3 by 3 matrix \n");
            Console.Write("*************************");

            Console.Write("Enter the elements of the array\n");
            for (k =0;k<3;k++)
            {
                for (p = 0; p<3; p++)
                {
                    Console.Write("The element [{0}],[{1}] : ",k,p);
                    aar1[k, p] = int.Parse(Console.ReadLine());
                }
            }
            Console.Write("The matrix is stated below : \n");
            for (k = 0; k< 3; k++)
            {
                for(p = 0; p <3; p++)
                
                    Console.Write("{0}",aar1[k,p]);
                 Console.Write("\n");
                
            }

            for (k = 0; k<3; k++)
            {
                de = de + (aar1[0, k] * (aar1[1,(k + 1) % 3] * aar1[2,(k+2)%3] - aar1[1,(k+2)%3]* aar1[2,(k+1)%3]));
                Console.Write("\n\n Determinant of the 3by 3 matrix is {0} \n\n",de);
            }


            Console.ReadLine();
        }
    }
}
