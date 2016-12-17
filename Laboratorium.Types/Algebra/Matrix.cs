using System.Text;

namespace Laboratorium.Types.Algebra
{
    class Matrix
    {
        int[,] _matrix;
        int _n;
        int _m;

        public int M { get { return _m; } }
        public int N { get { return _n; } }

        public int ElementAt(int i, int j)
        {
            return _matrix[i, j];
        }
        public Matrix(int[,] matrix)
        {
            _n = matrix.GetLength(1);
            _m = matrix.GetLength(0);
            _matrix = new int[_m, _n];
            for (int i = 0; i < _m; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    _matrix[i, j] = matrix[i, j];
                }
            }
        }
        public override string ToString()
        {
            var strb = new StringBuilder();
            for (int i = 0; i < _m; i++)
            {
                for (int j = 0; j < _n; j++)
                {
                    strb.Append(_matrix[i, j] + " ");
                }
                strb.AppendLine();
            }
            return strb.ToString();
        }
    }
}
