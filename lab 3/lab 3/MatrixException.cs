using System;

namespace Lab3
{
    public class MatrixException : Exception
    {
        public MatrixException(string message) : base(message)
        {
        }
    }

    public class MatrixSizeException : MatrixException
    {
        public MatrixSizeException(string message) : base(message)
        {
        }
    }

    public class MatrixSingularException : MatrixException
    {
        public MatrixSingularException(string message) : base(message)
        {
        }
    }
}