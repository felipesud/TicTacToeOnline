using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;

namespace TicTacToeOnline.Models
{
    public class Game
    {
        [Key]
        public string Id { get; set; }

        [NotMapped]
        public char[,] Board
        {
            get
            {
                if (string.IsNullOrEmpty(BoardString))
                {
                    return new char[3, 3];
                }

                char[,] board = new char[3, 3];
                string[] rows = BoardString.Split(',');

                for (int row = 0; row < 3; row++)
                {
                    for (int col = 0; col < 3; col++)
                    {
                        board[row, col] = rows[row][col];
                    }
                }

                return board;
            }
            set
            {
                if (value == null)
                {
                    BoardString = string.Empty;
                }
                else
                {
                    BoardString = string.Join(",", Enumerable.Range(0, 3).Select(row =>
                        string.Join("", Enumerable.Range(0, 3).Select(col => value[row, col]))));
                }
            }
        }

        [Column("Board")]
        public string BoardString { get; set; }

        public char CurrentPlayer { get; set; }
    }
}
