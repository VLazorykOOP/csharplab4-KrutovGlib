using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class MatrixDouble
    {
        private double[,] DArray;
        private uint n, m;
        private int codeError;
        public static int num_mf;

        public MatrixDouble()
        {
            n = 1;
            m = 1;
            DArray = new double[n, m]; // виділення пам'яті для одного елемента
            DArray[0, 0] = 0; // ініціалізація значенням нуль
            codeError = 0;
            num_mf++;
        }

        // Конструктор з двома параметрами - розміри вектора
        public MatrixDouble(uint rows, uint columns)
        {
            n = rows;
            m = columns;
            DArray = new double[n, m]; // виділення пам'яті та ініціалізація значенням нуль
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    DArray[i, j] = 0;
                }
            }
            codeError = 0;
            num_mf++;
        }

        public MatrixDouble(uint rows, uint columns, double initValue)
        {
            n = rows;
            m = columns;
            DArray = new double[n, m]; // виділення пам'яті та ініціалізація значенням initValue
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    DArray[i, j] = initValue;
                }
            }
            codeError = 0;
            num_mf++;
        }

        public void InputValuesFromConsole()
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"Enter value for element [{i}, {j}]: ");
                    if (!double.TryParse(Console.ReadLine(), out double value))
                    {
                        Console.WriteLine("Invalid input. Please enter a valid double value.");
                        j--; // Repeat the same element
                        continue;
                    }
                    DArray[i, j] = value;
                }
            }
        }

        public void PrintValues()
        {
            Console.WriteLine("Matrix Values:");
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    Console.Write($"{DArray[i, j]}\t");
                }
                Console.WriteLine();
            }
        }

        public void AssignValue(double value)
        {
            for (uint i = 0; i < n; i++)
            {
                for (uint j = 0; j < m; j++)
                {
                    DArray[i, j] = value;
                }
            }
        }

        public static int GetMatrixCount()
        {
            return num_mf;
        }

        // Властивості
        public uint Rows
        {
            get { return n; }
        }

        public uint Columns
        {
            get { return m; }
        }

        public int ErrorCode
        {
            get { return codeError; }
            set { codeError = value; }
        }

        public double this[uint i, uint j]
        {
            get
            {
                if (i < n && j < m)
                {
                    codeError = 0;
                    return DArray[i, j];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                if (i < n && j < m)
                {
                    DArray[i, j] = value;
                }
                else
                {
                    codeError = -1;
                }
            }
        }

        public double this[uint k]
        {
            get
            {
                uint i = k / m;
                uint j = k % m;
                if (i < n && j < m)
                {
                    codeError = 0;
                    return DArray[i, j];
                }
                else
                {
                    codeError = -1;
                    return 0;
                }
            }
            set
            {
                uint i = k / m;
                uint j = k % m;
                if (i < n && j < m)
                {
                    DArray[i, j] = value;
                }
                else
                {
                    codeError = -1;
                }
            }

        }

        public static MatrixDouble operator ++(MatrixDouble matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.DArray[i, j]++;
                }
            }
            return matrix;
        }

        public static MatrixDouble operator --(MatrixDouble matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.DArray[i, j]--;
                }
            }
            return matrix;
        }

        // Оператори true та false
        public static bool operator true(MatrixDouble matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix.DArray[i, j] == 0)
                        return false;
                }
            }
            return true;
        }

        public static bool operator false(MatrixDouble matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    if (matrix.DArray[i, j] != 0)
                        return false;
                }
            }
            return true;
        }

        // Оператори ! та ~
        public static bool operator !(MatrixDouble matrix)
        {
            return matrix.n != 0 && matrix.m != 0;
        }

        public static MatrixDouble operator ~(MatrixDouble matrix)
        {
            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    matrix.DArray[i, j] = ~Convert.ToInt64(matrix.DArray[i, j]);
                }
            }
            return matrix;
        }

        // Оператор додавання для двох матриць
        public static MatrixDouble operator +(MatrixDouble matrix1, MatrixDouble matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixDouble result = new MatrixDouble(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result.DArray[i, j] = matrix1.DArray[i, j] + matrix2.DArray[i, j];
                }
            }

            return result;
        }

        // Оператор додавання для матриці та скаляра типу double
        public static MatrixDouble operator +(MatrixDouble matrix, double scalar)
        {
            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result.DArray[i, j] = matrix.DArray[i, j] + scalar;
                }
            }

            return result;
        }

        public static MatrixDouble operator -(MatrixDouble matrix1, MatrixDouble matrix2)
        {
            if (matrix1.n != matrix2.n || matrix1.m != matrix2.m)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixDouble result = new MatrixDouble(matrix1.n, matrix1.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix1.m; j++)
                {
                    result.DArray[i, j] = matrix1.DArray[i, j] - matrix2.DArray[i, j];
                }
            }

            return result;
        }

        // Оператор віднімання для матриці та скаляра типу double
        public static MatrixDouble operator -(MatrixDouble matrix, double scalar)
        {
            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result.DArray[i, j] = matrix.DArray[i, j] - scalar;
                }
            }

            return result;
        }

        // Оператор множення для двох матриць
        public static MatrixDouble operator *(MatrixDouble matrix1, MatrixDouble matrix2)
        {
            if (matrix1.m != matrix2.n)
            {
                matrix1.codeError = -1;
                return matrix1;
            }

            MatrixDouble result = new MatrixDouble(matrix1.n, matrix2.m);

            for (uint i = 0; i < matrix1.n; i++)
            {
                for (uint j = 0; j < matrix2.m; j++)
                {
                    for (uint k = 0; k < matrix1.m; k++)
                    {
                        result.DArray[i, j] += matrix1.DArray[i, k] * matrix2.DArray[k, j];
                    }
                }
            }

            return result;
        }

      

        // Оператор множення для матриці та скаляра типу double
        public static MatrixDouble operator *(MatrixDouble matrix, double scalar)
        {
            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);

            for (uint i = 0; i < matrix.n; i++)
            {
                for (uint j = 0; j < matrix.m; j++)
                {
                    result.DArray[i, j] = matrix.DArray[i, j] * scalar;
                }
            }

            return result;
        }

       

        // Оператор множення для матриці та вектора VectorDouble
        public static VectorDouble operator *(MatrixDouble matrix, VectorDouble vector)
        {
            if (matrix.m != vector.size)
            {
                Console.WriteLine("Error: Matrix columns must be equal to vector size.");
                return null;
            }

            VectorDouble result = new VectorDouble(matrix.n);
            for (int i = 0; i < matrix.n; i++)
            {
                double sum = 0;
                for (int j = 0; j < matrix.m; j++)
                {
                    sum += matrix.DArray[i, j] * vector[j];
                }
                result[i] = sum;
            }
            return result;
        }

        public static MatrixDouble operator /(MatrixDouble matrix, double scalar)
        {
            if (scalar == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return null;
            }

            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    result.DArray[i, j] = matrix.DArray[i, j] / scalar;
                }
            }
            return result;
        }

        public static MatrixDouble operator %(MatrixDouble matrix, uint modulo)
        {
            if (modulo == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return null;
            }

            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    result.DArray[i, j] = matrix.DArray[i, j] % modulo;
                }
            }
            return result;
        }

        public static MatrixDouble operator |(MatrixDouble matrix, double scalar)
        {
            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    // Перетворення значень типу double на цілочисельний тип та виконання побітової операції
                    long intValue = (long)matrix.DArray[i, j];
                    result.DArray[i, j] = (double)(intValue | (long)scalar);
                }
            }
            return result;
        }

        public static MatrixDouble operator ^(MatrixDouble matrix, double scalar)
        {
            MatrixDouble result = new MatrixDouble(matrix.n, matrix.m);
            for (int i = 0; i < matrix.n; i++)
            {
                for (int j = 0; j < matrix.m; j++)
                {
                    // Перетворення значень типу double на цілочисельний тип та виконання побітової операції
                    long intValue = (long)matrix.DArray[i, j];
                    result.DArray[i, j] = (double)(intValue ^ (long)scalar);
                }
            }
            return result;
        }


    }
}

