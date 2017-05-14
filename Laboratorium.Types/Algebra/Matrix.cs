
namespace Laboratorium.Types.Algebra
{
    public class Matrix
    {
        readonly int[,] _matrix;
        int[] _rowOrder;

        public int RowsCount => _matrix.GetLength(0);
        public int ColumnsCount => _matrix.GetLength(1);

        public Matrix(int[,] matrix)
        {
            _rowOrder = new int[matrix.GetLength(0)];
            for (int i = 0; i < _rowOrder.Length; i++)
            {
                _rowOrder[i] = i;
            }
            _matrix = matrix;

        }

        public int this[int row, int column]
        {
            get { return _matrix[_rowOrder[row], column]; }
            set { _matrix[_rowOrder[row], column] = value; }
        }



   

   
    }
}
