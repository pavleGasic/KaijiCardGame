using KaijiCardGame.Infrastructure;
using Microsoft.AspNetCore.Mvc;

namespace KaijiCardGame.Api.Controllers
{
    public class PlayerController : Controller
    {
        private readonly DbContext _dbContext;

        public PlayerController(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
    }
}
