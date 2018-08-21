using GigFeed.Dtos;
using GigFeed.Models;
using Microsoft.AspNet.Identity;
using System.Linq;
using System.Web.Http;

namespace GigFeed.Controllers.Api
{
    [Authorize]
    public class FollowingsController : ApiController
    {
        private ApplicationDbContext _context;

        public FollowingsController()
        {
            _context = new ApplicationDbContext();
        }

        [HttpPost]
        public IHttpActionResult follow(FollowingDto dto)
        {
            var userId = User.Identity.GetUserId();
            if(_context.Followings.Any(f => f.FollowerId == userId && f.FolloweeId == dto.FolloweeId))
                return (BadRequest("Following already exists."));

            var Following = new Following()
            {
                FollowerId = userId,
                FolloweeId = dto.FolloweeId
            };
            _context.Followings.Add(Following);
            _context.SaveChanges();

            return Ok();
        }

        [HttpDelete]
        public IHttpActionResult unfollow(string id)
        {
            var userId = User.Identity.GetUserId();

            var following = _context.Followings
                .SingleOrDefault(f => f.FollowerId == userId && f.FolloweeId == id);

            if (following == null)
                return NotFound();

            _context.Followings.Remove(following);
            _context.SaveChanges();

            return Ok(id);
        }
    }
}