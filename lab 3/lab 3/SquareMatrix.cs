using System;
using System.Text;

namespace Lab3
{
    public class SquareMatrix : IComparable<SquareMatrix>
    {
        int size;
        double[,] data;

        // Конструктор с размером — заполняет случайными числами
        public SquareMatrix(int size)
        {
            if (size <= 0)
            {
                throw new MatrixSizeException("Размер матрицы должен быть больше нуля.");
            }
            this.size = size;
            data = new double[size, size];
            Random random = new Random();
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    data[rowIndex, columnIndex] = random.Next(-10, 11);
                }
            }
        }

        // Конструктор с готовым массивом
        public SquareMatrix(double[,] data)
        {
            if (data.GetLength(0) != data.GetLength(1))
            {
                throw new MatrixSizeException("Матрица должна быть квадратной.");
            }
            this.size = data.GetLength(0);
            this.data = (double[,])data.Clone();
        }

        public int Size
        {
            get { return size; }
        }

        public double GetElement(int row, int column)
        {
            return data[row, column];
        }

        public void SetElement(int row, int column, double value)
        {
            data[row, column] = value;
        }

        // Глубокое копирование (Прототип)
        public SquareMatrix Clone()
        {
            return new SquareMatrix((double[,])data.Clone());
        }

        // Определитель (рекурсивный метод)
        public double Determinant()
        {
            return CalculateDeterminant(data, size);
        }

        double CalculateDeterminant(double[,] matrix, int matrixSize)
        {
            if (matrixSize == 1)
            {
                return matrix[0, 0];
            }
            if (matrixSize == 2)
            {
                return matrix[0, 0] * matrix[1, 1] - matrix[0, 1] * matrix[1, 0];
            }

            double determinantValue = 0;
            for (int columnIndex = 0; columnIndex < matrixSize; ++columnIndex)
            {
                double[,] subMatrix = GetSubMatrix(matrix, 0, columnIndex, matrixSize);
                double sign = (columnIndex % 2 == 0) ? 1 : -1;
                determinantValue += sign * matrix[0, columnIndex] * CalculateDeterminant(subMatrix, matrixSize - 1);
            }
            return determinantValue;
        }

        double[,] GetSubMatrix(double[,] matrix, int excludeRow, int excludeColumn, int matrixSize)
        {
            double[,] subMatrix = new double[matrixSize - 1, matrixSize - 1];
            int subRowIndex = 0;
            for (int rowIndex = 0; rowIndex < matrixSize; ++rowIndex)
            {
                if (rowIndex == excludeRow)
                {
                    continue;
                }
                int subColumnIndex = 0;
                for (int columnIndex = 0; columnIndex < matrixSize; ++columnIndex)
                {
                    if (columnIndex == excludeColumn)
                    {
                        continue;
                    }
                    subMatrix[subRowIndex, subColumnIndex] = matrix[rowIndex, columnIndex];
                    ++subColumnIndex;
                }
                ++subRowIndex;
            }
            return subMatrix;
        }

        // Обратная матрица
        public SquareMatrix Inverse()
        {
            double determinantValue = Determinant();
            if (Math.Abs(determinantValue) < 1e-10)
            {
                throw new MatrixSingularException("Обратная матрица не существует: определитель равен нулю.");
            }

            double[,] inverseData = new double[size, size];
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    double[,] subMatrix = GetSubMatrix(data, rowIndex, columnIndex, size);
                    double sign = ((rowIndex + columnIndex) % 2 == 0) ? 1 : -1;
                    inverseData[columnIndex, rowIndex] = sign * CalculateDeterminant(subMatrix, size - 1) / determinantValue;
                }
            }
            return new SquareMatrix(inverseData);
        }

        // Сложение
        public static SquareMatrix operator +(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new MatrixSizeException("Размеры матриц должны совпадать для сложения.");
            }
            double[,] resultData = new double[firstMatrix.size, firstMatrix.size];
            for (int rowIndex = 0; rowIndex < firstMatrix.size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < firstMatrix.size; ++columnIndex)
                {
                    resultData[rowIndex, columnIndex] = firstMatrix.data[rowIndex, columnIndex] + secondMatrix.data[rowIndex, columnIndex];
                }
            }
            return new SquareMatrix(resultData);
        }

        // Умножение
        public static SquareMatrix operator *(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (firstMatrix.size != secondMatrix.size)
            {
                throw new MatrixSizeException("Размеры матриц должны совпадать для умножения.");
            }
            double[,] resultData = new double[firstMatrix.size, firstMatrix.size];
            for (int rowIndex = 0; rowIndex < firstMatrix.size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < firstMatrix.size; ++columnIndex)
                {
                    double sum = 0;
                    for (int innerIndex = 0; innerIndex < firstMatrix.size; ++innerIndex)
                    {
                        sum += firstMatrix.data[rowIndex, innerIndex] * secondMatrix.data[innerIndex, columnIndex];
                    }
                    resultData[rowIndex, columnIndex] = sum;
                }
            }
            return new SquareMatrix(resultData);
        }

        // Операторы сравнения — сравниваем по определителю
        public static bool operator >(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            return firstMatrix.Determinant() > secondMatrix.Determinant();
        }

        public static bool operator <(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            return firstMatrix.Determinant() < secondMatrix.Determinant();
        }

        public static bool operator >=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            return firstMatrix.Determinant() >= secondMatrix.Determinant();
        }

        public static bool operator <=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            return firstMatrix.Determinant() <= secondMatrix.Determinant();
        }

        public static bool operator ==(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            if (ReferenceEquals(firstMatrix, null) && ReferenceEquals(secondMatrix, null))
            {
                return true;
            }
            if (ReferenceEquals(firstMatrix, null) || ReferenceEquals(secondMatrix, null))
            {
                return false;
            }
            return firstMatrix.Determinant() == secondMatrix.Determinant();
        }

        public static bool operator !=(SquareMatrix firstMatrix, SquareMatrix secondMatrix)
        {
            return !(firstMatrix == secondMatrix);
        }

        // Приведение типов: матрица -> double (определитель)
        public static explicit operator double(SquareMatrix matrix)
        {
            return matrix.Determinant();
        }

        // true/false по определителю
        public static bool operator true(SquareMatrix matrix)
        {
            return Math.Abs(matrix.Determinant()) > 1e-10;
        }

        public static bool operator false(SquareMatrix matrix)
        {
            return Math.Abs(matrix.Determinant()) <= 1e-10;
        }

        // Equals и GetHashCode
        public override bool Equals(object obj)
        {
            if (obj == null || !(obj is SquareMatrix))
            {
                return false;
            }
            SquareMatrix other = (SquareMatrix)obj;
            if (size != other.size)
            {
                return false;
            }
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    if (Math.Abs(data[rowIndex, columnIndex] - other.data[rowIndex, columnIndex]) > 1e-10)
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        public override int GetHashCode()
        {
            return Determinant().GetHashCode();
        }

        // CompareTo
        public int CompareTo(SquareMatrix other)
        {
            double firstDeterminant = Determinant();
            double secondDeterminant = other.Determinant();
            if (firstDeterminant < secondDeterminant)
            {
                return -1;
            }
            if (firstDeterminant > secondDeterminant)
            {
                return 1;
            }
            return 0;
        }

        // ToString
        public override string ToString()
        {
            StringBuilder stringBuilder = new StringBuilder();
            for (int rowIndex = 0; rowIndex < size; ++rowIndex)
            {
                for (int columnIndex = 0; columnIndex < size; ++columnIndex)
                {
                    stringBuilder.Append(string.Format("{0,8:F2}", data[rowIndex, columnIndex]));
                }
                stringBuilder.AppendLine();
            }
            return stringBuilder.ToString();
        }
    }
}