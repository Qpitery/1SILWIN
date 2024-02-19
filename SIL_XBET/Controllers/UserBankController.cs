using Microsoft.AspNetCore.Mvc;
using System;
using System.Linq;
using SIL_XBET.DB;

namespace SIL_XBET.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class UserBankController : ControllerBase
    {
        private readonly XBETContext _context;

        public UserBankController(XBETContext context)
        {
            _context = context;
        }

        [HttpGet("GetAccountSid")]
    public IActionResult GetAccountSid(string login, string password)
    {
        var user = _context.User.FirstOrDefault(u => u.Login == login && u.Password == password);
        if (user == null)
            return NotFound();

        // Генерация и возврат сессии пользователя
        var session = Guid.NewGuid().ToString();
        return Ok(session);
    }

    [HttpGet("GetAccountBalance")]
    public IActionResult GetAccountBalance(string sid)
    {
        var user = _context.User.FirstOrDefault(u => u.SessionId == sid);
        if (user == null)
            return NotFound();

        // Возврат баланса пользователя
        return Ok(user.Balance);
    }

    [HttpPost("TopUpBalance")]
    public IActionResult TopUpBalance(string sid, decimal money)
    {
        var user = _context.User.FirstOrDefault(u => u.SessionId == sid);
        if (user == null)
            return NotFound();

        // Пополнение баланса пользователя
        user.Balance += money;
        _context.SaveChanges();

        return Ok();
    }
}


}

