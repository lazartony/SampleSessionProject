using Microsoft.AspNetCore.Mvc;

namespace SampleSessionProject.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class SessionController : ControllerBase
    {
        private readonly ILogger<SessionController> _logger;

        public SessionController(ILogger<SessionController> logger)
        {
            _logger = logger;
        }

        [HttpGet(Name = "GetSessionValue")]
        public string? GetSession(string key)
        {
            string? value = HttpContext.Session.GetString(key);
            _logger.Log(LogLevel.Information, "{0}:{1}", key, value);
            return value;
        }
        [HttpPost(Name = "SetSessionValue")]
        public void SetSession(string key, string value)
        {
            HttpContext.Session.SetString(key, value);
            _logger.Log(LogLevel.Information, "{0}:{1}", key, value);
        }
    }
}