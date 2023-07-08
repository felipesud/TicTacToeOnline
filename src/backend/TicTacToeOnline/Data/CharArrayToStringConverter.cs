using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using System;
using System.Linq;

namespace TicTacToeOnline.Data
{
    public class CharArrayToStringConverter : ValueConverter<char[,], string>
    {
        public CharArrayToStringConverter() : base(
            v => ConvertToString(v),
            v => ConvertToCharArray(v))
        {
        }

        private static string ConvertToString(char[,] value)
        {
            if (value == null)
                return null;

            int rows = value.GetLength(0);
            int cols = value.GetLength(1);

            return string.Join(",", Enumerable.Range(0, rows)
                .Select(row => string.Join("", Enumerable.Range(0, cols)
                    .Select(col => value[row, col].ToString()))));
        }

        private static char[,] ConvertToCharArray(string value)
        {
            if (string.IsNullOrEmpty(value))
                return null;

            string[] rows = value.Split(',');
            int numRows = rows.Length;
            int numCols = rows[0].Length;

            char[,] result = new char[numRows, numCols];
            for (int row = 0; row < numRows; row++)
            {
                for (int col = 0; col < numCols; col++)
                {
                    result[row, col] = rows[row][col];
                }
            }

            return result;
        }
    }
}
