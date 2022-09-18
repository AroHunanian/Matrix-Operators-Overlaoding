using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.ExceptionServices;
using System.Text;
using System.Threading.Tasks;

namespace Matrix_overlaoding_operators
{
    internal struct Matrix
    {
        public int Rows { get; set; }
        public int Columns { get; set; }
        public int[,] matrix;
        //initialization of properties
        public Matrix(int rows, int columns)
        {

            Rows = rows;
            Columns = columns;
            matrix = new int[rows, columns];

        }
        /// <summary>
        /// This method will create matrix with given length and width.
        /// </summary>
        /// <param name="matrix"></param>
        /// <returns> Matrix with entered values</returns>
        public static int[,] CreateMatrix(Matrix matrix)
        {
            Console.WriteLine("Enter Matrix");
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    try
                    {
                        Console.Write($"matrix[{i}][{j}] = ");
                        matrix.matrix[i, j] = int.Parse(Console.ReadLine());
                    }
                    catch (FormatException)
                    {
                        Console.WriteLine("Invalid value,please enter number");
                        
                    }
                    catch(OverflowException)
                    {
                        Console.WriteLine("Out of ranges integer please enter integer numbers");
                        CreateMatrix(matrix);
                    }
                    
                }
            }
            return matrix.matrix;
        }
        /// <summary>
        /// This method will Print given matrix
        /// </summary>
        /// <param name="matrix"></param>
        public static void PrintMatrix(Matrix matrix)
        {
            for (int i = 0; i < matrix.Rows; i++)
            {
                for (int j = 0; j < matrix.Columns; j++)
                {
                    Console.Write($"{matrix.matrix[i, j]} ");
                }
                Console.WriteLine();
            }
        }
        /// <summary>
        /// This method will add matrices together
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>
        public static Matrix operator +(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns == matrix2.Columns && matrix1.Rows == matrix2.Rows)
            {
                Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);
                result.matrix = new int[matrix1.Rows, matrix1.Columns];

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        result.matrix[i, j] = matrix1.matrix[i, j] + matrix2.matrix[i, j];
                    }
                }
                return result;
            }
            else
                throw new ArgumentException("matrices cant be added");

        }
        /// <summary>
        /// This method will substract matrices together
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public static Matrix operator -(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns == matrix2.Columns && matrix1.Rows == matrix2.Rows)
            {
                Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);
                result.matrix = new int[matrix1.Rows, matrix1.Columns];

                for (int i = 0; i < matrix1.Rows; i++)
                {
                    for (int j = 0; j < matrix1.Columns; j++)
                    {
                        result.matrix[i, j] = matrix1.matrix[i, j] - matrix2.matrix[i, j];
                    }
                }
                return result;
            }
            else
                throw new ArgumentException("matrices cant be substracted");

        }
        /// <summary>
        /// This method will multiply matrices together
        /// </summary>
        /// <param name="matrix1"></param>
        /// <param name="matrix2"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentException"></exception>

        public static Matrix operator *(Matrix matrix1, Matrix matrix2)
        {
            if (matrix1.Columns == matrix2.Rows)
            {
                Matrix result = new Matrix(matrix1.Rows, matrix2.Columns);

                for (int i = 0; i < matrix1.Rows; i++)
                {

                    for (int j = 0; j < matrix2.Columns; j++)
                    {
                        result.matrix[i, j] = 0;
                        for (int k = 0; k < matrix2.Rows; k++)
                        {
                            result.matrix[i, j] += matrix1.matrix[i, k] * matrix2.matrix[k, j];
                        }

                    }

                }

                return result;
            }
            else
                throw new ArgumentException("matrices cant be multiplied");
        }

    }
}
