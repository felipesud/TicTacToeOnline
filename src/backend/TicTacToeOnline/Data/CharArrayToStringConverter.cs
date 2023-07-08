using Microsoft.EntityFrameworkCore.Storage.ValueConversion;

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
            return string.Empty;
        }

        private static char[,] ConvertToCharArray(string value)
        {
            return new char[3, 3];
        }
    }
}
