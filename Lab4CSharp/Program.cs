
using Lab4CSharp;
using System.Net.Http.Headers;
void main()
{
    Console.WriteLine("Enter a choise (1/2): ");
    int choice = int.Parse(Console.ReadLine());
    switch (choice)
    {
        case 1:
            first();
            break;
        case 2:
            second();
            break;
        case 3:
            third();
            break;
        default:
            throw new Exception("Wrong answer(((");
    }
}
main();
static void first()
{
    Console.WriteLine("Enter the triangle: ");
    Console.Write("Side A = ");
    int a = int.Parse(Console.ReadLine());
    Console.Write("Side B = ");
    int b = int.Parse(Console.ReadLine());
    Console.Write("Side C = ");
    int c = int.Parse(Console.ReadLine());
    Console.Write("Color = ");
    string color = Console.ReadLine();
    Console.WriteLine();
    ATriangle triangle = new ATriangle(a, b, c, color);

    triangle.PrintSides();
    Console.WriteLine($"P = : {triangle.Perimeter()}");
    Console.WriteLine($"S = : {triangle.Plosha()}");
    Console.WriteLine($"Or isosceles triangle: {triangle.IsIsoscles()}");
    Console.WriteLine($"Color: {triangle.Color}");
    Console.WriteLine();

    Console.WriteLine("You want to change sides or check color?");
    Console.Write("Yes (y) or ");
    Console.WriteLine("No (n)");
    Console.Write("Choise = ");
    string choise = Console.ReadLine();

    if (choise == "y")
    {
        Console.WriteLine("What side do you want to change?(0 - a, 1 - b, 2 - check color) ");
        int secChoise = int.Parse(Console.ReadLine());
        switch (secChoise)
        {
            case 0:
                Console.Write("Enter new value of A = ");
                int newA = int.Parse(Console.ReadLine());
                int katetA = (int)triangle[0];
                triangle[0] = newA;
                Console.WriteLine("Triangle with new A: ");
                triangle.PrintSides();
                Console.WriteLine($"P = : {triangle.Perimeter()}");
                Console.WriteLine($"S = : {triangle.Plosha()}");
                Console.WriteLine($"Or isosceles triangle: {triangle.IsIsoscles()}");
                Console.WriteLine($"Color: {triangle.Color}");
                Console.WriteLine();
                break;

            case 1:
                Console.Write("Enter new value of B = ");
                int newB = int.Parse(Console.ReadLine());
                Console.WriteLine("Triangle with new B: ");
                triangle[1] = newB;
                triangle.PrintSides();
                Console.WriteLine($"P = : {triangle.Perimeter()}");
                Console.WriteLine($"S = : {triangle.Plosha()}");
                Console.WriteLine($"Or isosceles triangle: {triangle.IsIsoscles()}");
                Console.WriteLine($"Color: {triangle.Color}");
                Console.WriteLine();
                break;

            case 2:
                Console.WriteLine($"Color: {triangle.Color}");
                break;

        }
    }
    else if (choise == "n")
    {
        Console.WriteLine("You want to check Overload Operations? ");
        Console.Write("Yes (y) or ");
        Console.WriteLine("No (n)");
        string choice0 = Console.ReadLine();
        if (choice0 == "y")
        {
            if (triangle)
            {
                Console.WriteLine("Triagle exist.");
            }
            else
            {
                Console.WriteLine("Triangle not exist.");
            }

            triangle++;
            Console.WriteLine($"Triangle after increment: a={triangle.SideA}, b={triangle.SideB}");

            triangle--;
            Console.WriteLine($"Triangle after decrement: a={triangle.SideA}, b={triangle.SideB}");

            triangle += 2;
            Console.WriteLine($"Triangle after adding 2 to each side: a={triangle.SideA}, b={triangle.SideB}");
            Console.WriteLine();

            Console.WriteLine("You wont to convert Atriangle to string end back? (y/n)");
            string choiceToString = Console.ReadLine();

            if (choiceToString == "y")
            {
                Console.WriteLine();

                Console.WriteLine("Enter triangle data (a, b, c, color):");
                string input = Console.ReadLine();
                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("No input provided. Continuing...");
                }
                else
                {
                    // Розділити введений рядок за комами
                    string[] parts = input.Split(',');

                    // Перевірка, чи є усі необхідні поля
                    if (parts.Length >= 4)
                    {
                        // Витягти значення сторін та кольору з рядка
                        int a2, b2, c2;
                        if (int.TryParse(parts[0], out a2) && int.TryParse(parts[1], out b2) && int.TryParse(parts[2], out c2))
                        {
                            string color2 = parts[3].Trim(); // Видалити зайві пробіли

                            // Створення об'єкта ATriangle з введеними значеннями
                            ATriangle triangle2 = new ATriangle(a2, b2, c2, color2);

                            // Вивести об'єкт ATriangle у вигляді рядка
                            string ATriangleToString = (string)triangle2;
                            Console.WriteLine(ATriangleToString);
                        }
                        else
                        {
                            Console.WriteLine("Invalid input format. Exiting...");
                            return;
                        }
                    }
                }
            }
            else
            {
                return;
            }
        }
        else
        {
            throw new Exception("Error input.");
        }



    }
}

static void second()
{
    Console.Write("Enter size of vector: ");
    uint size = uint.Parse(Console.ReadLine());
    VectorDouble vector = new VectorDouble(size);
    vector.Input();
    Console.WriteLine();

    Console.WriteLine("Initialise vector by some value:");
    double initialase = double.Parse(Console.ReadLine());
    vector.changeValue(initialase);
    vector.Display();
    Console.WriteLine();

    Console.WriteLine("Initialise vector by constructor and some value:");
    double value = double.Parse(Console.ReadLine());
    VectorDouble vector1 = new VectorDouble(size, value);
    vector1.Display();
    Console.WriteLine();

    Console.WriteLine("Change vector values:");
    double[] someVector = new double[size];
    Console.WriteLine("Enter new elements: ");
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Element {i + 1} = ");
        someVector[i] = double.Parse(Console.ReadLine());
    }
    vector.changeVectorValues(someVector);
    vector.Display();
    Console.WriteLine();


    Console.WriteLine("Size of vector: " + vector.size);
    Console.WriteLine();

    Console.WriteLine("Changing code error: ");
    int c_Errror = int.Parse(Console.ReadLine());
    vector.ErrorCode = c_Errror;
    Console.WriteLine("Now code error = " + vector.ErrorCode);
    Console.WriteLine();

    Console.WriteLine("Treatment to elements of vector by indexator:");
    Console.WriteLine("What`s element you want to change? ");
    int changeElementVector = int.Parse(Console.ReadLine());
    Console.WriteLine("What new value of this element?");
    double newChangeElement = double.Parse(Console.ReadLine());
    vector[changeElementVector] = newChangeElement;
    vector.Display();
    Console.WriteLine();

    Console.WriteLine("What element you want to check using indexator?");
    int checkElementByIndexator = int.Parse(Console.ReadLine());
    Console.WriteLine($"Element of vector on position {checkElementByIndexator} = {vector[checkElementByIndexator]}");
    Console.WriteLine();

    Console.WriteLine("Using operator ++:");
    vector++;
    vector.Display();
    Console.WriteLine();

    Console.WriteLine("Using operator -- (2x)");
    vector--;
    vector--;
    vector.Display();
    Console.WriteLine();

    Console.WriteLine("Using operator true/false:");
    if (vector)
    {
        Console.WriteLine("Elements of vector not equal null.");
    }
    else
    {
        Console.WriteLine("Elements of vector are equal null.");
    }
    Console.WriteLine();

    Console.WriteLine("Using operator ! :");
    if (!vector)
    {
        Console.WriteLine("Size of vector != 0.");
    }
    else
    {
        Console.WriteLine("Size of vector = 0.");
    }
    Console.WriteLine();

    Console.WriteLine("Using operator ~ :");
    vector = ~vector;
    vector.Display();
    Console.WriteLine();

    Console.WriteLine("Using operator + :");
    Console.WriteLine("Enter array you want to plus: ");
    VectorDouble anothervector = new VectorDouble(size);
    anothervector.Input();
    VectorDouble onePlusTwo = vector + anothervector;
    onePlusTwo.Display();
    Console.WriteLine();

    Console.WriteLine("Elemnts of vector + scalar. Enter value: ");
    double scalar = double.Parse(Console.ReadLine());
    VectorDouble someVector2 = vector + scalar;
    vector.Display();
    Console.WriteLine();


    Console.WriteLine("Using operator * :");
    Console.WriteLine("Enter elements of second arr:");
    VectorDouble somevector2 = new VectorDouble(size);
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Element {i + 1} = ");
        someVector2[i] = double.Parse(Console.ReadLine());
    }
    VectorDouble MultiplyVectors = vector * somevector2;
    MultiplyVectors.Display();
    Console.WriteLine();

    Console.WriteLine("Multiply vector on scalar: ");
    Console.Write("Enter scalar: ");
    double scalar2 = double.Parse(Console.ReadLine());
    VectorDouble someanother = new VectorDouble(size);
    VectorDouble MultyplyScalar = someanother * scalar2;
    MultyplyScalar.Display();
    Console.WriteLine();

    Console.WriteLine("Using operator /: ");
    Console.WriteLine("Enter elements of arr: ");
    VectorDouble somevector3 = new VectorDouble(size);
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Element {i + 1} = ");
        somevector3[i] = double.Parse(Console.ReadLine());
    }
    VectorDouble divideVecors = vector / somevector3;
    divideVecors.Display();
    Console.WriteLine();
    Console.WriteLine("Divide vector on scalar: ");
    Console.Write("Enter scalar: ");
    double scalar3 = double.Parse(Console.ReadLine());
    VectorDouble somevector4 = new VectorDouble(size);
    VectorDouble DivideScalar = vector / scalar3;
    DivideScalar.Display();
    Console.WriteLine();

    Console.WriteLine("Using operator % : ");
    Console.WriteLine("Enter elements of arr: ");
    VectorDouble somevector5 = new VectorDouble(size);
    for (int i = 0; i < size; i++)
    {
        Console.Write($"Element {i + 1} = ");
        somevector5[i] = double.Parse(Console.ReadLine());
    }
    VectorDouble Procent = vector / somevector3;
    Procent.Display();
    Console.WriteLine();

    VectorDouble vector5 = new VectorDouble(5);

    // Встановлення значень елементів першого вектора
    vector5[0] = 10.5;
    vector5[1] = 20.7;
    vector5[2] = 30.2;
    vector5[3] = 40.9;
    vector5[4] = 50.3;

    // Створення другого вектора з розмірністю 5
    VectorDouble vector6 = new VectorDouble(5);

    // Встановлення значень елементів другого вектора
    vector6[0] = 3.0;
    vector6[1] = 4.0;
    vector6[2] = 5.0;
    vector6[3] = 6.0;
    vector6[4] = 7.0;

    // Виконання операцій побітового "або" та "виключне або" для двох векторів
    VectorDouble orResult = vector5 | vector6;
    VectorDouble xorResult = vector5 ^ vector6;

    // Виведення результату на екран
    Console.WriteLine("Bitwise OR result:");
    orResult.Display();
    Console.WriteLine();

    Console.WriteLine("Bitwise XOR result:");
    xorResult.Display();
    Console.WriteLine();

    VectorDouble vector7 = new VectorDouble(3);
    vector7[0] = 10.5;
    vector7[1] = 20.7;
    vector7[2] = 30.2;

    VectorDouble vector8 = new VectorDouble(3);
    vector8[0] = 10.5;
    vector8[1] = 20.7;
    vector8[2] = 30.2;

    // Порівняння векторів за допомогою операторів рівності та нерівності
    bool areEqual = vector7 == vector8;
    bool areNotEqual = vector7 != vector8;

    // Виведення результату порівняння на екран
    Console.WriteLine("Are vectors equal? " + areEqual);
    Console.WriteLine("Are vectors not equal? " + areNotEqual);
    Console.WriteLine();

    VectorDouble vector9 = new VectorDouble(3);
    vector9[0] = 10.5;
    vector9[1] = 20.7;
    vector9[2] = 30.2;

    VectorDouble vector10 = new VectorDouble(3);
    vector10[0] = 5.5;
    vector10[1] = 15.7;
    vector10[2] = 25.2;

    // Перевірка умов за допомогою операторів більше, більше або рівне, менше та менше або рівне
    bool greaterThan = vector9 > vector10;
    bool greaterThanOrEqual = vector9 >= vector10;
    bool lessThan = vector9 < vector10;
    bool lessThanOrEqual = vector9 <= vector10;

    // Виведення результатів на консоль
    Console.WriteLine($"Vector9 is greater than vector10: {greaterThan}");
    Console.WriteLine($"Vector9 is greater than or equal to vector10: {greaterThanOrEqual}");
    Console.WriteLine($"Vector9 is less than vector10: {lessThan}");
    Console.WriteLine($"Vector9 is less than or equal to vector10: {lessThanOrEqual}");


}

static void third()
{
    // Приклад використання класу MatrixDouble
    MatrixDouble matrix1 = new MatrixDouble(2, 2, 1.5);
    MatrixDouble matrix2 = new MatrixDouble(2, 2, 2.5);

    // Перевірка розмірності матриць
    Console.WriteLine($"Matrix 1 size: {matrix1.Rows}x{matrix1.Columns}");
    Console.WriteLine($"Matrix 2 size: {matrix2.Rows}x{matrix2.Columns}");

    // Виведення елементів матриць
    Console.WriteLine("Matrix 1:");
    matrix1.PrintValues();
    Console.WriteLine("Matrix 2:");
    matrix2.PrintValues();

    // Введення нових значень елементів матриці
    Console.WriteLine("Enter new elements for Matrix 1:");
    MatrixDouble matrix3 = new MatrixDouble(2, 2);
    matrix3.InputValuesFromConsole();
    matrix3.PrintValues();
    matrix3.AssignValue(0);

    Console.WriteLine("New elements of Matrix 3:");
    matrix3.PrintValues();

    // Оператор ++ та --
    Console.WriteLine("Incrementing Matrix 1 elements:");
    ++matrix1;
    matrix1.PrintValues();
    Console.WriteLine("Decrementing Matrix 1 elements:");
    --matrix1;
    matrix1.PrintValues();

    // Оператори true та false
    if (matrix1)
        Console.WriteLine("Matrix 1 contains non-zero elements.");
    else
        Console.WriteLine("Matrix 1 contains all zero elements.");

    // Оператори ! та ~
    Console.WriteLine("Negating Matrix 2 elements:");
    matrix2 = ~matrix2;
    matrix2.PrintValues();

    // Оператор додавання для двох матриць
    MatrixDouble sumMatrix = matrix1 + matrix2;
    Console.WriteLine("Sum of Matrix 1 and Matrix 2:");
    sumMatrix.PrintValues();

    // Оператор додавання для матриці та скаляра
    MatrixDouble matrixPlusScalar = matrix1 + 5.0;
    Console.WriteLine("Matrix 1 plus scalar (5.0):");
    matrixPlusScalar.PrintValues();

    // Підрахунок кількості матриць даного типу
    Console.WriteLine($"Number of MatrixDouble instances: {MatrixDouble.num_mf}");


    MatrixDouble matrix4 = new MatrixDouble(2, 3);
    VectorDouble vector = new VectorDouble(3);
    matrix4.InputValuesFromConsole();
    vector.Input();
    Console.WriteLine("Initial Matrix:");
    matrix4.PrintValues();
    Console.WriteLine("Initial Vector:");
    vector.Display();

    // Використання оператору множення для матриці та вектора
    VectorDouble resultVector = matrix4 * vector;

    // Вивід результату множення
    Console.WriteLine("Result Vector after matrix-vector multiplication:");
    resultVector.Display();

    // Використання оператору побітового додавання для матриці та скаляра типу double
    double scalar = 5.0;
    MatrixDouble resultMatrix = matrix4 + scalar;

    // Вивід результату побітового додавання
    Console.WriteLine($"Result Matrix after adding scalar {scalar}:");
    resultMatrix.PrintValues();


    MatrixDouble matrix5 = new MatrixDouble(2, 3);
    matrix5.InputValuesFromConsole();
    // Заповнення матриці
    

    // Вивід початкової матриці
    Console.WriteLine("Initial Matrix:");
    matrix5.PrintValues();

    // Використання оператору ділення для матриці та скаляра типу double
    double scalar2 = 2.0;
    MatrixDouble divisionResult = matrix5 / scalar2;

    // Вивід результату ділення
    Console.WriteLine($"Matrix after division by {scalar2}:");
    divisionResult.PrintValues();

    // Використання оператору остачі від ділення для матриці та скаляра типу uint
    uint modulo = 3;
    MatrixDouble moduloResult = matrix5 % modulo;

    // Вивід результату остачі від ділення
    Console.WriteLine($"Matrix after taking modulo {modulo}:");
    moduloResult.PrintValues();

    // Використання оператору побітового додавання для матриці та скаляра типу double
    MatrixDouble bitwiseOrResult = matrix5 | 5.0;

    // Вивід результату побітового додавання
    Console.WriteLine("Matrix after bitwise OR operation with scalar:");
    bitwiseOrResult.PrintValues();

    // Використання оператору побітового додавання за модулем 2 для матриці та скаляра типу double
    MatrixDouble bitwiseXorResult = matrix5 ^ 3.0;

    // Вивід результату побітового додавання за модулем 2
    Console.WriteLine("Matrix after bitwise XOR operation with scalar:");
    bitwiseXorResult.PrintValues();


}
