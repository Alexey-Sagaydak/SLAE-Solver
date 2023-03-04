namespace SLAESolver;

public class GaussMethod
{
    public float[] Solve(Matrix _matrix, bool selectMainElement)
    {
        if (_matrix == null) throw new ArgumentNullException(nameof(_matrix));

        Matrix matrix = DeepCloneMatrix(_matrix);
        MakeUpperTriMatrix(matrix, selectMainElement);
        return FindSolution(matrix);
    }

    private float[] FindSolution(Matrix matrix)
    {
        float[] solution = new float[matrix.Rows];

        for (int i = matrix.Rows - 1; i >= 0; i--)
        {
            float sum = 0;

            for (int j = i + 1; j < matrix.Rows; j++)
                sum += matrix[i, j] * solution[j];

            solution[i] = (matrix[i, matrix.Cols - 1] - sum) / matrix[i, i];
        }

        return solution;
    }

    private void MakeUpperTriMatrix(Matrix matrix, bool selectMainElement)
    {
        for (int i = 0; i < matrix.Rows - 1; i++)
        {
            if (selectMainElement)
                matrix.GetMainElement(i, i);

            for (int k = i + 1; k < matrix.Rows; k++)
            {
                float coefficient = -matrix[k, i] / matrix[i, i];
                for (int j = i; j < matrix.Cols; j++)
                    matrix[k, j] += matrix[i, j] * coefficient;
            }
        }
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