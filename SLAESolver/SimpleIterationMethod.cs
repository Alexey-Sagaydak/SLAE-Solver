namespace SLAESolver;

public class SimpleIterationMethod
{
    public float[] Solve(Matrix matrix, float epsilon, bool calculateNorm)
    {
        if (calculateNorm && matrix.GetMatrixNorm() > 1)
            throw new ApplicationException("Matrix norm greater than one!");

        bool recalculateSolutions = true;
        float[] solution = new float[matrix.Cols - 1];
        float epsilon2 = GetEpsilon2(matrix, epsilon);
        
        FillSolutionWithC(matrix, solution);

        while (recalculateSolutions)
        {
            float[] prevSolution = new float[solution.Length];
            solution.CopyTo(prevSolution, 0);
            
            for (int i = 0; i < matrix.Rows; i++)
            {
                CalculateNewSolution(matrix, solution, prevSolution, i);
                recalculateSolutions = Math.Abs(solution[i] - prevSolution[i]) < epsilon2 ? false : true;
            }
        }

        return solution;
    }

    private void FillSolutionWithC(Matrix matrix, float[] solution)
    {
        for (int i = 0; i < matrix.Rows; i++)
            solution[i] = matrix[i, matrix.Cols - 1];
    }

    private void CalculateNewSolution(Matrix matrix, float[] solution, float[] prevSolution, int i)
    {
        float sum = 0;

        for (int j = 0; j < matrix.Cols - 1; j++)
            sum += matrix[i, j] * prevSolution[j];
        sum += matrix[i, matrix.Cols - 1];

        solution[i] = sum;
    }

    private float GetEpsilon2(Matrix _sourceMatrix, float epsilon)
    {
        float sourceMatrixNorm = _sourceMatrix.GetMatrixNorm();
        return (1 - sourceMatrixNorm) * epsilon / sourceMatrixNorm;
    }

    private void MakeUpperTriMatrix(Matrix _matrix)
    {
        for (int i = 0; i < _matrix.Rows; i++)
        for (int j = 0; j <= i; j++)
            _matrix[i, j] = 0;
    }

    private Matrix DeepCloneMatrix(Matrix sourceMatrix)
    {
        float[,] matrix = new float[sourceMatrix.Rows, sourceMatrix.Cols];

        for (int i = 0; i < sourceMatrix.Rows; i++)
        for (int j = 0; j < sourceMatrix.Cols; j++)
            matrix[i, j] = sourceMatrix[i, j];

        return new Matrix(matrix, sourceMatrix.Rows, sourceMatrix.Cols);
    }
}