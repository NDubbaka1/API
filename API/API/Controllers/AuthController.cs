using API.Model.DTO;
using API.Repo;
using API.Validations;
using AutoMapper;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers
{

    [ApiController]
    [Route("[Controller]")]
    public class AuthController : Controller
    {
        private readonly UserManager<IdentityUser> usermanager;
        private readonly IUserValid userValid;
        private readonly IMapper mapper;
        private readonly ITokenHandler tokenHanlder;

        public AuthController(IUserValid userValid, IMapper mapper, UserManager<IdentityUser> usermanager , ITokenHandler tokenHandler)
        {
            this.usermanager = usermanager;
            this.userValid = userValid;
            this.mapper = mapper;
            this.tokenHanlder = tokenHandler;

        }

        [HttpPost]
        [Route("Register")]

        public async Task<IActionResult> Register([FromBody] Model.DTO.Register register)
        {
            var identityUser = new IdentityUser
            {
                UserName = register.Username,
                Email = register.Username

            };

           var identity = await usermanager.CreateAsync(identityUser, register.Password);
           
            if (identity.Succeeded)
            {
                //Add role to user 
                if(register.Roles != null && register.Roles.Any())
                {
                   identity= await usermanager.AddToRolesAsync(identityUser, register.Roles);

                    if (identity.Succeeded)
                    {
                        return Ok("User registered");
                    }
                }
                    
                   
            }
            return BadRequest();

        }

        [HttpPost]
        [Route("Login")]
        public async Task<IActionResult> Login(Model.DTO.Login login)
        {
            // check username and password is null recieved from client
            //Fluent validation
            // check if user is authenticated
            //var IsAuthenticated = await userValid.ValidateUser(login.Username,login.Password);

           var User= await usermanager.FindByEmailAsync(login.Username);

            if (User!= null)
            {
               var CheckPwd = await usermanager.CheckPasswordAsync(User,login.Password);
               

                if (CheckPwd ) {
                    //get role for this user
                    var role =await usermanager.GetRolesAsync(User);         
                    //Create JWT
                    var jwtToken = tokenHanlder.CreateJWToken(User, role.ToList());

                    var response = new LoginResponse
                    {
                        JwtToken = jwtToken
                    };

                        return Ok(response);
                }
                

            }
            // Check user name ad password
            return BadRequest();
        }


        [HttpPost]
        [Route("Reset")]

        public async Task<IActionResult> ResetPWD (Model.DTO.ResetPassword resetPwd)
        {
            var User = await usermanager.FindByEmailAsync(resetPwd.Username);

            if (User != null)
            {
                var token =await usermanager.GeneratePasswordResetTokenAsync(User);
                await usermanager.ResetPasswordAsync(User,token, resetPwd.Newpassword);
                return Ok();
            }
              
            
            return BadRequest();
        }
    }
}
