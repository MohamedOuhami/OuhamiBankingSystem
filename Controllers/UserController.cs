using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace OuhamiBankingSystem.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Constructor to inject the DbContext
        public UserController(AppDbContext context)
        {
            _context = context;
        }

        // Get all the Users
        [HttpGet]
        public async Task<IResult> GetAllUsers()
        {
            // Await the async call to get the list of users
            var users = await _context.Users.ToListAsync();

            // Return the result as a 200 OK response with the users
            return Results.Ok(users);
        }

        // Get a user by Id
        [HttpGet("{id}")]
        public async Task<IResult> GetUserById(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is not null)
            {
                return Results.Ok(user);
            }
            else
            {
                return Results.NotFound();
            }
        }

        // Create a new User
        [HttpPost]
        public async Task<IResult> CreateNewUser(User NewUser)
        {
            try
            {

                // Add the new user to the context
                _context.Users.Add(NewUser);

                // Save the Users list of the context
                await _context.SaveChangesAsync();

                return Results.Created($"/users/{NewUser.Id}", NewUser);

            }
            catch (Exception ex)
            {
                return Results.Problem("There was a problem" + ex.Message, statusCode: 500);
            }
        }

        // Edit a User
        [HttpPut("{id}")]
        public async Task<IResult> EditUser(int id, User updatedUser)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is not null)
            {

                // Update the user properties
                user.FirstName = updatedUser.FirstName;
                user.LastName = updatedUser.LastName;
                user.Email = updatedUser.Email;
                user.Phone = updatedUser.Phone;

                // Save the updated user
                await _context.SaveChangesAsync();
                return Results.Created($"/api/{user.Id}", user);

            }
            return Results.NotFound();

        }

        // Delete a User By Id
        [HttpDelete("{id}")]
        public async Task<IResult> DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            if (user is not null)
            {

                // Delete the user
                _context.Users.Remove(user);

                // Save the updated user
                await _context.SaveChangesAsync();
                return Results.NoContent();

            }
            return Results.NotFound();


        }

    }
}
