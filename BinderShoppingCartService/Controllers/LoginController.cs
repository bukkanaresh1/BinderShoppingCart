using BinderShoppingCart.OAuth._2._0;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using BinderShoppingCart.OAuth._2._0;

namespace BinderShoppingCartService.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {

        private readonly ILogger<LoginController> _logger;
        private readonly IConfiguration _config;
        public LoginController(IConfiguration config, ILogger<LoginController> logger)
        {
            _config = config;
            _logger = logger;
        }

        [HttpPost]
        [Route("Login")]
        [AllowAnonymous]
        public IActionResult Login(string emailAddress, string password)
        {
            try
            {
                var jwtAuthenticationManager = new JwtAuthenticationManager(_config);
                var authResult = jwtAuthenticationManager.Authenticate(emailAddress, password);
                if (authResult == null)
                    return Unauthorized();
                else
                    return Ok(authResult);
            }
            catch(Exception ex)
            {
                _logger.LogError("Error occured in Login controller ", ex);
                return StatusCode(500, $"An error occurred. Please try again. If the problem persists, " +
                    $" Please contact admin.");
            }            
        }
    }
}
