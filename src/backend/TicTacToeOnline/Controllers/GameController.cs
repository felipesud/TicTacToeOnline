using Microsoft.AspNetCore.Mvc;

namespace TicTacToeOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        private static List<Game> games = new List<Game>();

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
            games.Add(game);

            return Ok(gameId);
        }

        private string GenerateNewGameId()
        {
            return Guid.NewGuid().ToString();
        }


        private Game GetGameById(string gameId)
        {
            return games.FirstOrDefault(game => game.Id == gameId);
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
            
            return Ok(gameResult);
        }
    }
}