using SLAESolver;

public static class Program
{
    public static void Main()
    {
        //RunGauss();
        //Console.WriteLine("\n");
        //RunSweep();
        RunSeidel();
        RunSimpleIterationMethod();
        //RunSeidelTest1();
        //RunSeidelTest1();
    }

    private static void RunGauss()
    {
        float[,] matrixValues =
        {
            { 2.83333f, 5, 1, 11.66666f },
            { 1.7f, 3, 7, 13.4f },
            { 8, 1, 1, 18 }
        };
        Matrix matrix = new Matrix(matrixValues, 3, 4);
        GaussMethod gaussMethod = new GaussMethod();
        float[] solution = gaussMethod.Solve(matrix, false);

        Console.WriteLine("Gauss method\nExpected values: x1 = 2, x2 = 1, x3 = 1");
        Console.WriteLine("Without selecting main element");

        Console.Write("Solution: ");
        for (int i = 0; i < solution.Length; i++)
            Console.Write($"x{i + 1} = {solution[i]} ");

        Console.WriteLine("\nWith selecting main element");
        solution = gaussMethod.Solve(matrix, true);

        Console.Write("Solution: ");
        for (int i = 0; i < solution.Length; i++)
            Console.Write($"x{i + 1} = {solution[i]} ");
    }

    private static void RunSweep()
    {
        float[,] matrixValues =
        {
            { 5, -1, 0, 0, 2 },
            { 2, 4.6f, -1, 0, 3.3f },
            { 0, 2, 3.6f, -0.8f, 2.6f },
            { 0, 0, 3, 4.4f, 7.2f }
        };

        Matrix matrix = new Matrix(matrixValues, 4, 5);
        SweepMethod sweepMethod = new SweepMethod();

        Console.WriteLine("Sweep method");
        Console.WriteLine("Expected values: x1 = 0.5256 x2 = 0.628 x3 = 0.64 x4 = 1.2");

        float[] solution = sweepMethod.Solve(matrix);

        Console.Write("Solution: ");
        for (int i = 0; i < solution.Length; i++)
            Console.Write($"x{i + 1} = {solution[i]} ");
    }

    private static void RunSeidel()
    {
        try
        {
            float[,] matrixValues =
            {
                { 0, -0.2f, -0.1f, 1.4f },
                { -0.1111f, 0, -0.1111f, 1.3333f },
                { -0.1818f, -0.1818f, 0, 2.3636f }
            };

            float epsilon = 0.001f;
            Matrix matrix = new Matrix(matrixValues, 3, 4);
            SeidelMethod seidelMethod = new SeidelMethod();
            float[] solution = seidelMethod.Solve(matrix, epsilon, true);

            foreach (var val in solution)
            {
                Console.Write($"{val} ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RunSimpleIterationMethod()
    {
        try
        {
            float[,] matrixValues =
            {
                { 0, -0.2f, -0.1f, 1.4f },
                { -0.1111f, 0, -0.1111f, 1.3333f },
                { -0.1818f, -0.1818f, 0, 2.3636f }
            };

            float epsilon = 0.0001f;
            Matrix matrix = new Matrix(matrixValues, 3, 4);
            SimpleIterationMethod seidelMethod = new SimpleIterationMethod();
            float[] solution = seidelMethod.Solve(matrix, epsilon, true);
            Console.WriteLine();
            foreach (var val in solution)
            {
                Console.Write($"{val} ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RunSeidelTest1()
    {
        try
        {
            float[,] matrixValues =
            {
                { 0, -0.5f, -7.5f, -0.5f, 10.5f },
                { 3, 0, 2, 20, -27 },
                { -1, -10, 0, -1, 14 },
                { 1.5f, 1, 7, 0, -10 }
            };

            float epsilon = 0.001f;
            Matrix matrix = new Matrix(matrixValues, 4, 5);
            SeidelMethod seidelMethod = new SeidelMethod();
            float[] solution = seidelMethod.Solve(matrix, epsilon, true);
            
            foreach (var val in solution)
            {
                Console.Write($"{val} ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }

    private static void RunSeidelTest2()
    {
        try
        {
            float[,] matrixValues =
            {
                { 0, -1f, 1f, 3f, -1f },
                { -0.1f, 0, -0.1f, -0.1f, 1.4f },
                { -0.1113f, -0.0667f, 0, -0.0667f, 1.4f },
                { -0.15f, 0.05f, -0.1f, 0, 1.35f }
            };

            float epsilon = 0.001f;
            Matrix matrix = new Matrix(matrixValues, 4, 5);
            SeidelMethod seidelMethod = new SeidelMethod();
            float[] solution = seidelMethod.Solve(matrix, epsilon, true);

            foreach (var val in solution)
            {
                Console.Write($"{val} ");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
    }
}