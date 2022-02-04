using System.Collections.Generic;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Api_UrnaEletronica.Data;
using Api_UrnaEletronica.Models;
using System.Linq;

namespace Api_UrnaEletronica.Controllers
{
    [ApiController]
    [Route("candidate")]
    public class CandidateController : ControllerBase
    {
        // Get
        [HttpGet]
        [Route("")]
        public async Task<ActionResult<List<Candidate>>> Get([FromServices] DataContext context)
        {
            var candidates = await context.Candidates.ToListAsync();
            return candidates;
        }

        // Get Id
        [HttpGet]
        [Route("{id}")]
        public async Task<ActionResult<Candidate>> GetId([FromServices] DataContext context, int id)
        {
            var candidate = await context.Candidates.Where(x => x.id == id).FirstOrDefaultAsync();
            return candidate;
        }

        // Post
        [HttpPost]
        [Route("")]
        public async Task<ActionResult<Candidate>> Post(
            [FromServices] DataContext context,
            [FromBody] Candidate model)
        {
            if (ModelState.IsValid)
            {
                context.Candidates.Add(model);
                await context.SaveChangesAsync();
                return model;
            }
            else
            {
                return BadRequest(ModelState);
            }
        }

        // Delete
        [HttpDelete]
        [Route("{id}")]
        public void Delete(
            [FromServices] DataContext context,
            int id
        )
        {
            Candidate candidate = context.Candidates.Where(x => x.id == id).FirstOrDefault();
            context.Candidates.Attach(candidate);
            context.Candidates.Remove(candidate);
            context.SaveChanges();
        }

        // Update
        [HttpPut]
        [Route("")]
        public async Task<ActionResult<Candidate>> Update(
            [FromServices] DataContext context,
            [FromBody] Candidate model
        )
        {
            if (ModelState.IsValid)
            {
                context.Entry<Candidate>(model).State = EntityState.Modified;
                //context.Candidates.Update(model);
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