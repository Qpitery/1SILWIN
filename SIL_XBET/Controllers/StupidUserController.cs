using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using SIL_XBET.DB;
namespace SIL_XBET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class StupidUserController : ControllerBase
    {
        private readonly XBETContext _context;

        public StupidUserController(XBETContext context)
        {
            _context = context;
        }

        [HttpGet("Spin")]
        public IActionResult Spin(string sid, decimal price)
        {
            var user = _context.User.FirstOrDefault(u => u.SessionId == sid);
            if (user == null)
                return NotFound();

            // Логика для кручения рулетки и изменения баланса пользователя в зависимости от результата
            // ...

            return Ok();
        }

        [HttpGet("ViewHistory")]
        public IActionResult ViewHistory(string sid, DateTime from, DateTime to)
        {
            var user = _context.User.FirstOrDefault(u => u.SessionId == sid);
            if (user == null)
                return NotFound();

            // Логика для получения истории игр пользователя за заданный период
            // ...

            return Ok();
        }
    }
}
