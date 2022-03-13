using Microsoft.AspNetCore.Mvc;
using ProjctModel.Services;
using ProjctModel.VeiwModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ExJwt2.Controllers
{
    [Route("User")]
    public class UserController : Controller
    {
        private readonly UserService _userService;

        public UserController(UserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [Route("Post")]
        public IActionResult Post(UserDto userDto)
        {
            var Resulte = _userService.RegisterUser(userDto);
            return Ok(Resulte);
        }

        [HttpGet]
        [Route("Login")]
        public IActionResult Login(string UserName , string Password)
        {
            var Resulte = _userService.Login(UserName, Password);
            if (Resulte == null)
                return NotFound();

            else

            return Ok(SampleJwt.GetToke(Resulte));
        }
    }
}
