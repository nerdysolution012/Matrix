using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class operation
    {
        private static double determinant(double[,] matrix, int size)
        {
            double[] diviser = new double[size];// this will be used to make 0 all the elements of a row except (i,i)th value.
            double[] temp = new double[size]; // this will hold the modified ith row after divided by (i,i)th value.
            Boolean flag = false; // this will limit the operation to be performed only when loop n != loop i
            double determinant = 1;

            if (varifyRowsAndColumns(matrix, size)) // verifies that no rows or columns are similar or multiple of another row or column
                for (int i = 0; i < size; i++)
                {
                    int count = 0;
                    //this will hold the values to be multiplied by temp matrix
                    double[] multiplier = new double[size - 1];
                    diviser[i] = matrix[i, i];
                    //if(i,i)th value is 0, determinant shall be 0
                    if (diviser[i] == 0)
                    {
                        determinant = 0;
                        break;
                    }
                    /*
                     * whole ith row will be divided by (i,i)th value and result will be stored in temp matrix.
                     * this will generate 1 at (i,i)th position in temp matrix i.e. ith row of matrix
                     */
                    for (int j = 0; j < size; j++)
                    {
                        temp[j] = matrix[i, j] / diviser[i];
                    }
                    //setting up multiplier to be used for multiplying the ith row of temp matrix
                    for (int o = 0; o < size; o++)
                        if (o != i)
                            multiplier[count++] = matrix[o, i];

                    count = 0;
                    //for creating 0s at every other position than (i,i)th
                    for (int n = 0; n < size; n++)
                    {
                        for (int k = 0; k < size; k++)
                        {
                            if (n != i)
                            {
                                flag = true;
                                matrix[n, k] -= (temp[k] * multiplier[count]);
                            }
                        }
                        if (flag)
                            count++;
                        flag = false;
                    }

                }
            else determinant = 0;
            //if determinant is not 0, (i,i)th element will be multiplied and the result will be determinant
            if (determinant != 0)
                for (int i = 0; i < size; i++)
                {
                    determinant *= matrix[i, i];
                }
            return determinant;
        }


        private static Boolean varifyRowsAndColumns(double[,] matrix, int size)
        {
            List<double[]> rows = new List<double[]>();
            List<double[]> columns = new List<double[]>();


            for (int j = 0; j < size; j++)
            {
                double[] temp = new double[size];
                for (int k = 0; k < size; k++)
                {
                    temp[j] = matrix[j, k];
                }
                rows.Add(temp);
            }

            for (int j = 0; j < size; j++)
            {
                double[] temp = new double[size];
                for (int k = 0; k < size; k++)
                {
                    temp[j] = matrix[k, j];
                }
                columns.Add(temp);
            }

            if (!RowsAndColumnsComparison(rows, size))
                return false;
            if (!RowsAndColumnsComparison(columns, size))
                return false;
            return true;
        }
        private static Boolean RowsAndColumnsComparison(List<double[]> rows, int size)
        {
            int countEquals = 0;
            int countMod = 0;
            int countMod2 = 0;

            for (int i = 0; i < rows.Count; i++)
            {
                for (int j = 0; j < rows.Count; j++)
                {
                    if (i != j)
                    {
                        double min = returnMin(rows.ElementAt(i), rows.ElementAt(j));
                        double max = returnMax(rows.ElementAt(i), rows.ElementAt(j));

                        for (int l = 0; l < size; l++)
                        {
                            if (rows.ElementAt(i)[l] == rows.ElementAt(j)[l])
                                countEquals++;

                            for (int m = (int)min; m <= max; m++)
                            {
                                if (rows.ElementAt(i)[l] % m == 0 && rows.ElementAt(j)[l] % m == 0)
                                    countMod++;

                                if (rows.ElementAt(j)[l] % m == 0 && rows.ElementAt(i)[l] % m == 0)
                                    countMod2++;
                            }
                        }

                        if (countEquals == size)
                        {
                            return false;
                            // one row is equal to another row. determinant is zero
                        }

                        if (countMod == size)
                        {
                            return false;
                        }

                        if (countMod2 == size)
                        {
                            return false;
                        }
                    }
                }
            }
            return true;
        }
        private static double returnMin(double[] row1, double[] row2)
        {
            double min1 = row1[0];
            double min2 = row2[0];

            for (int i = 1; i < row1.Length; i++)
                if (min1 > row1[i])
                    min1 = row1[i];

            for (int i = 1; i < row2.Length; i++)
                if (min2 > row2[i])
                    min2 = row2[i];

            if (min1 < min2)
                return min1;
            else return min2;
        }
        private static double returnMax(double[] col1, double[] col2)
        {
            double max1 = col1[0];
            double max2 = col2[0];

            for (int i = 1; i < col1.Length; i++)
                if (max1 < col1[i])
                    max1 = col1[i];

            for (int i = 1; i < col2.Length; i++)
                if (max2 < col2[i])
                    max2 = col2[i];

            if (max1 > max2)
                return max1;
            else return max2;
        }
    }
}
