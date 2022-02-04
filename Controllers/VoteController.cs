using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Api_UrnaEletronica.Data;
using Api_UrnaEletronica.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Api_UrnaEletronica.Controllers
{
    [ApiController]
    public class VoteController : ControllerBase
    {
        // Get
        [HttpGet]
        [Route("votes")]
        public async Task<ActionResult<List<Vote>>> Get([FromServices] DataContext context)
        {
            var vote = await context.Votes
                .Include(x => x.candidate)
                .ToListAsync();
            return vote.GroupBy(x => x.candidateId)
                .Select( x => new Vote { 
                    id = x.FirstOrDefault().id,
                    candidateId = x.Key,
                    candidate = x.FirstOrDefault().candidate,
                    voteDate = x.FirstOrDefault().voteDate,
                    candidateVotes = x.Count()
                }).ToList();
        }

        [HttpGet]
        [Route("votes/{id:int}")]
        public async Task<ActionResult<Vote>> GetById([FromServices] DataContext context, int id)
        {
            var vote = await context.Votes.Include(x => x.candidate)
                .AsNoTracking()
                .FirstOrDefaultAsync(x => x.id == id);
            return vote;
        }

        [HttpGet]
        [Route("votes/candidates/{id:int}")]
        public async Task<ActionResult<List<Vote>>> GetByCategory([FromServices] DataContext context, int id)
        {
            var vote = await context.Votes
                .Include(x => x.candidate)
                .AsNoTracking()
                .Where(x => x.candidateId == id)
                .ToListAsync();
            return vote;
        }

        // Post
        [HttpPost]
        [Route("vote")]
        public async Task<ActionResult<Vote>> Post(
            [FromServices] DataContext context,
            [FromBody] Vote model)
        {
            if (ModelState.IsValid)
            {
                context.Votes.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }
    }
}