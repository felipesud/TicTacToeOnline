using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using TicTacToeOnline.Data;
using TicTacToeOnline.Models;

namespace TicTacToeOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private readonly GameContext _context;

        public GameController(GameContext context)
        {
            _context = context;
        }

        [HttpPost("new")]
        public ActionResult<string> NewGame()
        {
            var gameId = GenerateNewGameId();
            var game = new Game
            {
                Id = gameId,
                Board = new char[3, 3],
                CurrentPlayer = 'X'
            };

            _context.Games.Add(game);
            _context.SaveChanges();

            return Ok(gameId);
        }

        private string GenerateNewGameId()
        {
            return Guid.NewGuid().ToString();
        }

        private Game GetGameById(string gameId)
        {
            return _context.Games.FirstOrDefault(game => game.Id == gameId);
        }

        private bool IsValidMove(Game game, Move move)
        {
            return move != null && move.Row >= 0 && move.Row < 3 && move.Column >= 0 && move.Column < 3 && game != null && game.Board[move.Row, move.Column] == '\0';
        }

        private string GetGameResult(Game game)
        {
            if (CheckForWinner(game, 'X'))
            {
                return "Vitória do Jogador X";
            }
            else if (CheckForWinner(game, 'O'))
            {
                return "Vitória do Jogador O";
            }
            else if (IsBoardFull(game))
            {
                return "Empate";
            }
            else
            {
                return "Jogo em andamento";
            }
        }

        private bool CheckForWinner(Game game, char player)
        {
            if (game == null || game.Board == null)
            {
                return false;
            }

            int boardLength = game.Board.GetLength(0);
            for (int row = 0; row < boardLength; row++)
            {
                if (game.Board[row, 0] == player && game.Board[row, 1] == player && game.Board[row, 2] == player)
                {
                    return true;
                }
            }

            for (int col = 0; col < boardLength; col++)
            {
                if (game.Board[0, col] == player && game.Board[1, col] == player && game.Board[2, col] == player)
                {
                    return true;
                }
            }

            if (game.Board[0, 0] == player && game.Board[1, 1] == player && game.Board[2, 2] == player)
            {
                return true;
            }

            if (game.Board[2, 0] == player && game.Board[1, 1] == player && game.Board[0, 2] == player)
            {
                return true;
            }

            return false;
        }


        private bool IsBoardFull(Game game)
        {
            if (game == null || game.Board == null)
            {
                return false;
            }

            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    if (game.Board[row, col] == '\0')
                    {
                        return false;
                    }
                }
            }
            return true;
        }

        private string GetGameBoardAsString(char[,] board)
        {
            string boardString = "";
            for (int row = 0; row < 3; row++)
            {
                for (int col = 0; col < 3; col++)
                {
                    boardString += board[row, col].ToString();
                }
            }
            return boardString;
        }

        [HttpPost("{gameId}/move")]
        public ActionResult MakeMove(string gameId, [FromBody] Move move)
        {
            var game = GetGameById(gameId);
            if (game == null)
            {
                return NotFound();
            }
            if (!IsValidMove(game, move))
            {
                return BadRequest("Invalid move");
            }
            game.Board[move.Row, move.Column] = game.CurrentPlayer;

            var gameResult = GetGameResult(game);
            var gameBoardAsString = GetGameBoardAsString(game.Board);

            _context.SaveChanges();

            return Ok(new { Result = gameResult, Board = gameBoardAsString });
        }
    }
}
