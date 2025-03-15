using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Mission10_Gouff.Models;

namespace Mission10_Gouff.Controllers

{// Marks this class as an API controller
    [ApiController]
    // Defines the route for this controller as "api/Bowlers" based on the class name
    [Route("api/[controller]")]
    public class BowlersController : ControllerBase
    {
        // Declares a private readonly field to hold the database context
        private readonly BowlingLeagueContext _context;

        public BowlersController(BowlingLeagueContext context)
        {
            _context = context; // Assigns the injected context to the private field
        }

        [HttpGet]
        public IActionResult Get()
        {
            // Fetch bowlers with team information (including only the necessary fields)
            var bowlerList = _context.Bowlers
                .Include(b => b.Team) // Include related Team data
                .Where(b => b.Team != null &&
                            (b.Team.TeamName == "Marlins" || b.Team.TeamName == "Sharks")) // Filter by teams
                .Select(b => new
                {
                    ID = b.BowlerID,
                    BowlerName =
                        $"{b.BowlerFirstName} {b.BowlerMiddleInit} {b.BowlerLastName}", // Combine first, middle, and last names
                    TeamName = b.Team.TeamName,
                    Address = b.BowlerAddress,
                    City = b.BowlerCity,
                    State = b.BowlerState,
                    Zip = b.BowlerZip,
                    PhoneNumber = b.BowlerPhoneNumber
                })
                .ToList();

            return Ok(bowlerList); // Return the filtered data as JSON
        }
    }
}