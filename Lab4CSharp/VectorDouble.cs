using Microsoft.VisualBasic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class VectorDouble
    {
        private double[] FArray; // vector
        private uint num; //size of vector
        private int codeError;
        private static uint num_vd;// quantity of vectors

        public VectorDouble()
        {
            num = 0;
            FArray = new double[num];
            num_vd++;
        }

        public VectorDouble(uint size)
        {
            num = size;
            FArray = new double[num];
            num_vd++;
        }

        public VectorDouble(uint size, double initialValue)
        {
            num = size;
            FArray = new double[num];
            for (int i = 0; i < num; i++)
            {
                FArray[i] = initialValue;
            }
            num_vd++;
        }

        //методи
        public void Input()
        {
            Console.WriteLine($"Enter elements of vector ({num})");
            for (int i = 0; i < num; i++)
            {
                Console.Write($"Element {i + 1} = ");
                if (!double.TryParse(Console.ReadLine(), out FArray[i]))
                {
                    Console.WriteLine("Enter DOUBLE value, please...");
                    i--;
                }
            }
        }

        public void Display()
        {
            Console.WriteLine("Elements of vector:");
            for (int i = 0; i < num; i++)
            {
                Console.Write(FArray[i] + " ");
            }
            Console.WriteLine();
        }

        public void changeValue(double value)
        {
            for (int i = 0; i < num; i++)
            {
                FArray[i] = value;
            }
        }

        public static uint countVectors()
        {
            return num_vd;
        }

        public void changeVectorValues(double[] values)
        {
            if (values.Length != num)
            {
                Console.WriteLine("Length of input values not equal to length of vector.");
            }

            for (int i = 0; i < num; i++)
            {
                FArray[i] = values[i];
            }
        }

        //деструктор
        ~VectorDouble()
        {
            Console.WriteLine("Destructor called. Object destroed.");
        }

        //властивості
        public uint size
        {
            get { return num; }
        }

        public int ErrorCode
        {
            get { return codeError; }
            set { codeError = value; }
        }
        //індексатор
        public double this[int  index]
        {
            get
            {
                if(index < 0 || index >= num)
                {
                    codeError = -1;
                    return 0;
                }
                else
                {
                    return FArray[index];
                }
            }
            set
            {
                if(index < 0 || index >= num)
                {
                    codeError = 1;
                }
                else
                {
                    FArray[index] = value;
                }
            }
        }

        // перевантаження операторів
        public static VectorDouble operator ++(VectorDouble v)
        {
            for(int i = 0; i < v.num; i++)
            {
                v.FArray[i]++;
            }
            return v;
        }


        public static VectorDouble operator --(VectorDouble v)
        {
            for (int i = 0; i < v.num; i++)
            {
                v.FArray[i]--;
            }
            return v;
        }

        public static bool operator true(VectorDouble vector) 
        { 
            if(vector.num == 0)
            {
                return false;
            }
            else
            {
                foreach(double element in vector.FArray)
                {
                    if(element != 0)
                    {
                        return true;
                    }
                }
            }
            return false;
        }

        public static bool operator false(VectorDouble vector)
        {
            if (vector.num == 0)
            {
                return true;
            }
            else
            {
                foreach (double element in vector.FArray)
                {
                    if (element != 0)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public static bool operator !(VectorDouble vector)
        {
            return vector.num != 0;
        }

        public static VectorDouble operator ~(VectorDouble vector)
        {
            for (int i = 0; i < vector.num; i++)
            {
                vector.FArray[i] = ~Convert.ToInt32(vector.FArray[i]);
            }
            return vector;
        }
        //додавання векторів
        public static VectorDouble operator +(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
            {
                Console.WriteLine("Error: Vector sizes do not match.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                result.FArray[i] = vd1.FArray[i] + vd2.FArray[i];
            }
            return result;
        }
        //додавання скаляру

        public static VectorDouble operator +(VectorDouble vd, double scalar)
        {
            VectorDouble result = new VectorDouble(vd.num);
            for (int i = 0; i < vd.num; i++)
            {
                result.FArray[i] = vd.FArray[i] + scalar;
            }
            return result;
        }

        public static VectorDouble operator -(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
            {
                Console.WriteLine("Error: Vector sizes do not match.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                result.FArray[i] = vd1.FArray[i] - vd2.FArray[i];
            }
            return result;
        }

        public static VectorDouble operator -(VectorDouble vd, double scalar)
        {
            VectorDouble result = new VectorDouble(vd.num);
            for (int i = 0; i < vd.num; i++)
            {
                result.FArray[i] = vd.FArray[i] - scalar;
            }
            return result;
        }

        public static VectorDouble operator *(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
            {
                Console.WriteLine("Error: Vector sizes do not match.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
                {
                    result.FArray[i] = vd1.FArray[i] * vd2.FArray[i];
                }
                return result;            
        }

        public static VectorDouble operator *(VectorDouble vd, double scalar)
        {
            VectorDouble result = new VectorDouble(vd.num);
            for (int i = 0; i < vd.num; i++)
            {
                result.FArray[i] = vd.FArray[i] * scalar;
            }
            return result;
        }

        public static VectorDouble operator /(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
            {
                Console.WriteLine("Error: Vector sizes do not match.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                if (vd2.FArray[i] == 0)
                {
                    Console.WriteLine("Error: Division by zero.");
                    return null;
                }
                result.FArray[i] = vd1.FArray[i] / vd2.FArray[i];
            }
            return result;
        }

        public static VectorDouble operator /(VectorDouble vd, double scalar)
        {
            if (scalar == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd.num);
            for (int i = 0; i < vd.num; i++)
            {
                result.FArray[i] = vd.FArray[i] / scalar;
            }
            return result;
        }

        public static VectorDouble operator %(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
            {
                Console.WriteLine("Error: Vector sizes do not match.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                if (vd2.FArray[i] == 0)
                {
                    Console.WriteLine("Error: Division by zero.");
                    return null;
                }
                result.FArray[i] = vd1.FArray[i] % vd2.FArray[i];
            }
            return result;
        }

        public static VectorDouble operator %(VectorDouble vd, double scalar)
        {
            if (scalar == 0)
            {
                Console.WriteLine("Error: Division by zero.");
                return null;
            }

            VectorDouble result = new VectorDouble(vd.num);
            for (int i = 0; i < vd.num; i++)
            {
                result.FArray[i] = vd.FArray[i] % scalar;
            }
            return result;
        }



        public static VectorDouble operator ^(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length.");

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                // Перетворення значень типу double на цілочисельний тип та виконання побітової операції
                long intValue1 = (long)vd1.FArray[i];
                long intValue2 = (long)vd2.FArray[i];
                result.FArray[i] = (double)(intValue1 ^ intValue2);
            }
            return result;
        }

        public static VectorDouble operator &(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length.");

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                // Перетворення значень типу double на цілочисельний тип та виконання побітової операції
                long intValue1 = (long)vd1.FArray[i];
                long intValue2 = (long)vd2.FArray[i];
                result.FArray[i] = (double)(intValue1 & intValue2);
            }
            return result;
        }


        public static VectorDouble operator |(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length.");

            VectorDouble result = new VectorDouble(vd1.num);
            for (int i = 0; i < vd1.num; i++)
            {
                // Перетворення значень типу double на цілочисельний тип та виконання побітової операції
                long intValue1 = (long)vd1.FArray[i];
                long intValue2 = (long)vd2.FArray[i];
                result.FArray[i] = (double)(intValue1 | intValue2);
            }
            return result;
        }

        public static bool operator ==(VectorDouble vd1, VectorDouble vd2)
        {
            if (ReferenceEquals(vd1, vd2))
                return true;
            if (ReferenceEquals(vd1, null) || ReferenceEquals(vd2, null))
                return false;
            if (vd1.num != vd2.num)
                return false;
            for (int i = 0; i < vd1.num; i++)
            {
                if (vd1.FArray[i] != vd2.FArray[i])
                    return false;
            }
            return true;
        }


        public static bool operator !=(VectorDouble vd1, VectorDouble vd2)
        {
            return !(vd1 == vd2);
        }

        public static bool operator >(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (int i = 0; i < vd1.num; i++)
            {
                if (vd1.FArray[i] <= vd2.FArray[i])
                    return false;
            }
            return true;
        }

        public static bool operator >=(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (int i = 0; i < vd1.num; i++)
            {
                if (vd1.FArray[i] < vd2.FArray[i])
                    return false;
            }
            return true;
        }

        public static bool operator <(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (int i = 0; i < vd1.num; i++)
            {
                if (vd1.FArray[i] >= vd2.FArray[i])
                    return false;
            }
            return true;
        }

        public static bool operator <=(VectorDouble vd1, VectorDouble vd2)
        {
            if (vd1.num != vd2.num)
                throw new ArgumentException("Vectors must have the same length for comparison.");

            for (int i = 0; i < vd1.num; i++)
            {
                if (vd1.FArray[i] > vd2.FArray[i])
                    return false;
            }
            return true;
        }
    }
}
