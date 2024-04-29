using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myCoreAPI.Data;

namespace myCoreAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class IssueController : ControllerBase
    {
        private readonly IssueDBcontext _db;
        public IssueController(IssueDBcontext _context) => _db = _context;
        [HttpGet]
        public async Task<IEnumerable<Issue>> Get()
            => await _db.Issues.ToListAsync();

        [HttpGet("Id")]
        [ProducesResponseType(typeof(Issue),StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> GetById(int id)
        {
            var issue = await _db.Issues.FindAsync(id);
            return issue==null ? NotFound() : Ok(issue);

        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        public async Task<IActionResult> Create(Issue issue)
        {
            await _db.Issues.AddAsync(issue);
            await _db.SaveChangesAsync();

            return CreatedAtAction(nameof(GetById), new { Id = issue.Id }, issue);
        }
        
        [HttpPut("Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public async Task<IActionResult> Update(int Id, Issue issue)
        {
            if (Id != issue.Id) return BadRequest();
            _db.Entry(issue).State = EntityState.Modified;
            await _db.SaveChangesAsync();

            return NoContent();
        }

        [HttpDelete("Id")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public async Task<IActionResult> Delete(int Id)
        {
            var issueToDelete = await _db.Issues.FindAsync(Id);
            if (issueToDelete == null) return NotFound();

            _db.Issues.Remove(issueToDelete);
            _db.SaveChanges();
            return NoContent();
        }
    }
}
