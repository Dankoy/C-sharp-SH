using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Matrix
{
    class Program
    {
        static void Main(string[] args)
        {


            Stopwatch sw = new Stopwatch();

            Console.WriteLine("Enter X-Dimension:");
            // read x-dimension of array
            var xdim = int.Parse(Console.ReadLine());

            Console.WriteLine("Enter Y-Dimension:");
            // ready y-dimension of array
            var ydim = int.Parse(Console.ReadLine());

            // init matrices
            var matrix2D = new Matrix2DArray(xdim, ydim);
            var matrixJagged = new MatrixJaggedArray(xdim, ydim);

            sw.Start();


            var result_2d = matrix2D.RandomMultiplication;
            Console.WriteLine("2D result in: " + sw.ElapsedMilliseconds + " ms");
            sw.Restart();

            var result_jagged = matrixJagged.RandomMultiplication;
            Console.WriteLine("Jagged result in: " + sw.ElapsedMilliseconds + " ms");
            sw.Stop();

            Console.ReadLine();
        }
    }

    public class Matrix2DArray
    {
        private double[,] matrix_a;
        private double[,] matrix_b;
        private double[,] matrix_c;
        private int xdimension;
        private int ydimension;

        public Matrix2DArray(int XDimension, int YDimension)
        {
            this.xdimension = XDimension;
            this.ydimension = YDimension;

            matrix_a = new double[XDimension, YDimension];
            matrix_b = new double[XDimension, YDimension];
            matrix_c = new double[XDimension, YDimension];

            InitializeMatrix(matrix_a, XDimension, YDimension);
            InitializeMatrix(matrix_b, XDimension, YDimension);
            InitializeMatrix(matrix_c, XDimension, YDimension, true);
        }

        private void InitializeMatrix(double[,] matrix, int XDim, int YDim, bool E = false)
        {
            Random rnd = new Random();

            for (int i = 0; i < XDim; ++i)
                for (int j = 0; j < YDim; ++j)
                {
                    matrix[i, j] = E ? 0.00 : rnd.NextDouble();
                }
        }

        // side-effect, not so good approach
        public double[,] RandomMultiplication
        {
            get
            {
                for (int i = 0; i < xdimension; ++i)
                    for (int j = 0; j < ydimension; ++j)
                        for (int k = 0; k < xdimension; ++k)
                        {
                            matrix_c[i, j] += matrix_a[i, k] * matrix_b[k, j];
                        }
                return matrix_c;
            }
        }
    }

    public class MatrixJaggedArray
    {
        private double[][] matrix_a;
        private double[][] matrix_b;
        private double[][] matrix_c;
        private int xdimension;
        private int ydimension;

        public MatrixJaggedArray(int XDimension, int YDimension)
        {
            this.xdimension = XDimension;
            this.ydimension = YDimension;

            matrix_a = new double[XDimension][];
            matrix_b = new double[XDimension][];
            matrix_c = new double[XDimension][];

            InitializeMatrix(matrix_a, XDimension, YDimension);
            InitializeMatrix(matrix_b, XDimension, YDimension);
            InitializeMatrix(matrix_c, XDimension, YDimension);
        }

        private void InitializeMatrix(double[][] matrix, int XDim, int YDim, bool E = false)
        {
            Random rnd = new Random();

            for (int i = 0; i < XDim; ++i)
            {
                matrix[i] = new double[YDim];

                for (int j = 0; j < YDim; ++j)
                {
                    matrix[i][j] = E ? 0.00 : rnd.NextDouble();
                }
            }
        }

        public double[][] RandomMultiplication
        {
            get
            {
                for (int i = 0; i < xdimension; ++i)
                    for (int j = 0; j < ydimension; ++j)
                        for (int k = 0; k < xdimension; ++k)
                        {
                            matrix_c[i][j] += matrix_a[i][k] * matrix_b[k][j];
                        }
                return matrix_c;
            }
        }
    }
}
