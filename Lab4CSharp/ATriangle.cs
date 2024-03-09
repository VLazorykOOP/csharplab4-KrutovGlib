using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab4CSharp
{
    internal class ATriangle
    {
        private int katetA;
        private int katetB;
        private readonly int gipotenuzaC;
        private readonly string color;

        public ATriangle(int katetA, int katetB, int gipotenuzaC, string color)
        {
            this.katetA = katetA;
            this.katetB = katetB;
            this.gipotenuzaC = gipotenuzaC;
            this.color = color;

        }

        public object this[int index]
        {
            get
            {
                switch (index)
                {
                    case 0: return katetA;
                    case 1: return katetB;
                    case 2: return color;
                    default: throw new IndexOutOfRangeException("Invalid index. Index must be 0, 1 or 2.");    
                }
            }
            set
            {
                switch (index)
                {
                    case 0:
                        katetA = (int)value;
                        break;
                    case 1:
                        katetB = (int)value; 
                        break;
                    case 2:
                        throw new InvalidOperationException("Can't set color value using index.");
                    default:
                        throw new IndexOutOfRangeException("Invalid index. Index must be 0 or 1.");
                }
            }
        }


        public static ATriangle operator ++(ATriangle triangle)
        {
            triangle.katetA++;
            triangle.katetB++;
            return triangle;
        }

        public static ATriangle operator --(ATriangle triangle)
        {
            triangle.katetA--;
            triangle.katetB--;
            return triangle;
        }

        public static bool operator false(ATriangle triangle)
        {
            return triangle.katetA + triangle.katetB > triangle.gipotenuzaC
                   && triangle.katetA + triangle.gipotenuzaC > triangle.katetB
                   && triangle.katetB + triangle.gipotenuzaC > triangle.katetA;
        }

        public static bool operator true(ATriangle triangle)
        {
            return !(triangle.katetA + triangle.katetB > triangle.gipotenuzaC
                   && triangle.katetA + triangle.gipotenuzaC > triangle.katetB
                   && triangle.katetB + triangle.gipotenuzaC > triangle.katetA);
        }


        public static ATriangle operator +(ATriangle triangle, int somevalue)
        {
            triangle.katetA += somevalue;
            triangle.katetB += somevalue;
            return triangle;
        }

        public static explicit operator string(ATriangle triangle)
        {
            return $"Triangle: a={triangle.katetA}, b={triangle.katetB}, gipotenuza={triangle.gipotenuzaC}, color={triangle.color}";
        }

        public static explicit operator ATriangle(string triangleString)
        {
            // Розділити рядок за комами та пробіли
            string[] parts = triangleString.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

            // Значення сторін трикутника
            int a = 0, b = 0, c = 0;

            // Колір трикутника
            string color = "";

            foreach (string part in parts)
            {
                // Розбити частину рядка на ім'я та значення
                string[] pair = part.Split('=');

                // Перевірити ім'я та встановити відповідне значення
                switch (pair[0].Trim().ToLower())
                {
                    case "a":
                        int.TryParse(pair[1], out a);
                        break;
                    case "b":
                        int.TryParse(pair[1], out b);
                        break;
                    case "c":
                        int.TryParse(pair[1], out c);
                        break;
                    case "color":
                        color = pair[1].Trim();
                        break;
                    default:
                        // Обробити невідомі значення, якщо потрібно
                        break;
                }
            }

            // Повернути новий екземпляр класу ATriangle
            return new ATriangle(a, b, c, color);
        }



        public void PrintSides()
        {
            Console.WriteLine($"Sides of triange = \n a = {katetA},\n b = {katetB},\n Gipotenuza = {gipotenuzaC}");
        }

        public int Perimeter()
        {
            return katetA + katetB + gipotenuzaC;
        }

        public double Plosha()
        {
            double p = Perimeter() / 2.0;
            return Math.Sqrt(p * (p - katetA) * (p - katetB) * (p - gipotenuzaC));
        }

        public bool IsIsoscles()
        {
            return katetA == katetB || katetB == gipotenuzaC || gipotenuzaC == katetA;
        }

        public int SideA
        {
            get { return katetA; }
            set { katetA = value; }
        }
        public int SideB
        {
            get { return katetB; }
            set { katetB = value; }
        }
        public int SideC
        {
            get { return gipotenuzaC; }
        }

        public string Color
        {
            get { return color; }
        }
    }
}
