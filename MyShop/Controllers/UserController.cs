using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MyShop.Models;
using MyShop.Models.Dtos;
using MyShop.Services;
using MyShop.Services.IServices;

namespace MyShop.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMapper _mapper;
        private readonly IUser _userService;

        public UserController(IMapper mapper, IUser userService)
        {
            _mapper = mapper;
            _userService = userService;
        }

        [HttpGet]
        public async Task<ActionResult<List<User>>> GetAllUsers()
        {
            try
            {
                var users = await _userService.GetUsersAsync();
                if (users == null)
                {
                    return NotFound("User is not found");
                }
                return Ok(users);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<User>> GetUserByEmail(string email)
        {
            try
            {
                var user = await _userService.GetUserByEmailAsync(email);
                if (user == null)
                {
                    return NotFound("Email not found");
                }
                return Ok(user);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPost]
        public async Task<ActionResult<string>> AddUser(AddUserDto newUser)
        {
            try
            {
                var user = _mapper.Map<User>(newUser);
                var response = await _userService.AddUserAsync(user);
                return Created($"", response);
            } catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<string>> UpdateUser(Guid id, AddUserDto updateUser) 
        {
            try 
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound("Email not found");
                }
                var updatedUser = _mapper.Map(updateUser, user);
                var response = await _userService.UpdateUserAsync(updatedUser);
                return Ok(response);

            } catch (Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult<string>> DeleteUser(Guid id) 
        {
            try 
            {
                var user = await _userService.GetUserByIdAsync(id);
                if (user == null)
                {
                    return NotFound("Email not found");
                }
               var response = await _userService.DeleteProductAsync(user);
               return Ok(response);

            } catch(Exception ex) 
            {
                return BadRequest(ex.Message);
            }
        }
        
    }
}
