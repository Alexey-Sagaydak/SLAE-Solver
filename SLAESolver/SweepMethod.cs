namespace SLAESolver;

public class SweepMethod
{
    public float[] Solve(Matrix matrix)
    {
        float[] alpha = new float[matrix.Rows], beta = new float[matrix.Rows];
        FindCoefficients(matrix, alpha, beta);
        return FindSolution(matrix, alpha, beta);
    }

    private void FindCoefficients(Matrix matrix, float[] alpha, float[] beta)
    {
        alpha[0] = -GetC(matrix, 0) / GetB(matrix, 0);
        beta[0] = GetD(matrix, 0) / GetB(matrix, 0);

        for (int i = 1; i < matrix.Rows - 1; i++)
        {
            float gamma = GetB(matrix, i) + GetA(matrix, i) * alpha[i - 1];
            alpha[i] = -GetC(matrix, i) / gamma;
            beta[i] = (GetD(matrix, i) - GetA(matrix, i) * beta[i - 1]) / gamma;
        }

        int m = matrix.Rows - 1;
        beta[m] = (GetD(matrix, m) - GetA(matrix, m) * beta[m - 1]) /
                  (GetB(matrix, m) + GetA(matrix, m) * alpha[m - 1]);
    }

    private float[] FindSolution(Matrix matrix, float[] alpha, float[] beta)
    {
        float[] solutions = new float[matrix.Rows];
        
        solutions[matrix.Rows - 1] = beta[matrix.Rows - 1];
        for (int i = matrix.Rows - 2; i >= 0; i--)
            solutions[i] = alpha[i] * solutions[i + 1] + beta[i];
        
        return solutions;
    }
    
    private float GetA(Matrix matrix, int i) => matrix[i, i - 1];
    private float GetB(Matrix matrix, int i) => matrix[i, i];
    private float GetC(Matrix matrix, int i) => matrix[i, i + 1];
    private float GetD(Matrix matrix, int i) => matrix[i, matrix.Cols - 1];
}