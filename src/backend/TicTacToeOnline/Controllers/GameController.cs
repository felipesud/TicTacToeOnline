using Microsoft.AspNetCore.Mvc;

namespace TicTacToeOnline.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class GameController : ControllerBase
    {
        [HttpPost("new")]
        public ActionResult<string> NewGame()
        {
            //pass
        }

        [HttpPost("{gameId}/move")]
        public ActionResult MakeMove(string gameId, [FromBody] MoveRequest moveRequest)
        {
            //pass
            return Ok("move_result");
        }
    }
}