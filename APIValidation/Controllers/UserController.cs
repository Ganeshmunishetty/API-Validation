using APIValidation.Model;
using Dapper;
using FluentValidation;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlClient;

namespace APIValidation.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController:ControllerBase
    {
        private readonly IValidator<User> _validate;
        private readonly IConfiguration _config;

        public UserController(IValidator<User> validator, IConfiguration config) 
        {
            _validate=validator;
            _config = config;
        }
        [HttpPost]
        public async Task<ActionResult<User>> AddCustomer(User user)
        {
            var validationResult = await _validate.ValidateAsync(user);

            if (!validationResult.IsValid)
                return BadRequest(validationResult.Errors);

            using var connection = new SqlConnection(_config.GetConnectionString("DefaultConnection"));
            await connection.ExecuteAsync("insert into [User] (Name,Age,Email,PhoneNumber,Address) values (@Name,@Age,@Email,@PhoneNumber,@Address)", user);
            return Ok(user);
        }
    }
}
