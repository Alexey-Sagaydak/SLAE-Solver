namespace SLAE_Solver;

public class Matrix
{
    private float[,] _matrix;
    public int Rows { get; }
    public int Cols { get; }

    public float this[int i, int j]
    {
        get
        {
            CheckIndexes(i, j);
            return _matrix[i, j];
        }
        set
        {
            CheckIndexes(i, j);
            _matrix[i, j] = value;
        }
    }


    public Matrix(float[,] matrix, int rows, int cols)
    {
        if (rows != cols - 1)
            throw new ArgumentException("Matrix should be a square");
        if (rows <= 0)
            throw new ArgumentException(nameof(rows));
        if (cols <= 0)
            throw new ArgumentException(nameof(cols));
        
        Rows = rows;
        Cols = cols;
        _matrix = matrix;
    }

    public void SwapRows(int firstRowIndex, int secondRowIndex)
    {
        CheckRow(firstRowIndex);
        CheckRow(secondRowIndex);

        for (int i = 0; i < Cols; i++)
            (_matrix[firstRowIndex, i], _matrix[secondRowIndex, i]) 
                = (_matrix[secondRowIndex, i], _matrix[firstRowIndex, i]);
    }
    
    public void GetMainElement(int row, int col)
    {
        float maxValue = _matrix[row, col];
        int maxValueRow = row;
        
        CheckIndexes(row, col);
        
        for (int i = row + 1; i < Rows; i++)
        {
            if (_matrix[i, col] > maxValue)
            {
                maxValue = _matrix[i, col];
                maxValueRow = i;
            } 
        }
        SwapRows(maxValueRow, row);
    }

    private void CheckRow(int row)
    {
        if (row < 0 || row >= Rows)
            throw new IndexOutOfRangeException(nameof(row));
    }

    private void CheckCol(int col)
    {
        if (col < 0 || col >= Cols) 
            throw new IndexOutOfRangeException(nameof(col));
    }
    
    private void CheckIndexes(int row, int col)
    {
        CheckRow(row);
        CheckCol(col);
    }
}