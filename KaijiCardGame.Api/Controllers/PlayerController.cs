using KaijiCardGame.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KaijiCardGame.Api.Controllers
{
    public class PlayerController : Controller
    {
        private readonly GameContext _gameContext;

        public PlayerController(GameContext gameContext)
        {
            _gameContext = gameContext;
        }
        
    }
}
