using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using pc_desk_rest.Data;
using pc_desk_rest.Models;

namespace pc_desk_rest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly DataContext Context;

        public UsersController(DataContext context) 
        { 
            Context = context;  
        }

        [HttpGet]
        [Route("/search/")]
        public async Task<IActionResult> SearchUsers() 
        {
            return Ok(await Context.Users.ToListAsync < User >());
        }

        [HttpGet]
        [Route("/search/{name}")]
        public async Task<IActionResult> SearchUser(string name)
        {
            try
            {
                var user = await Context.Users.SingleAsync<User>(u => u.UserName == name);
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPost]
        [Route("/add")]
        public async Task<ActionResult> AddNewUser(User user)
        {
            if(!ModelState.IsValid)
            {
                return NotFound();
            }

            await Context.Users.AddAsync(user);
            await Context.SaveChangesAsync();
            return Ok(user);
        }

        [HttpDelete]
        [Route("/delete/{id}")]
        public async Task<ActionResult> RemoveUser(int id)
        {
            try
            {
                var user = await Context.Users.SingleAsync<User>(u => u.UserId == id);
                Context.Remove(user);
                await Context.SaveChangesAsync();
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }
        }

        [HttpPut]
        [Route("/update/{id}")]
        public async Task<ActionResult> UpdateUser(int id, User up_user)
        {
            try
            {
                var user = await Context.Users.SingleAsync<User>(u => u.UserId == id);
                user.UserName = up_user.UserName;  
                user.PhoneNumber = up_user.PhoneNumber;
                await Context.SaveChangesAsync();
                return Ok();
            }
            catch
            {
                return NotFound();
            }
        }
    }
}
