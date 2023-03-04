using SLAESolver;

public static class Program
{
    public static void Main()
    {
        RunGauss();
        Console.WriteLine("\n");
        RunSweep();
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
}