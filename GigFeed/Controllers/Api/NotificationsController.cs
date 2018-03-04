using AutoMapper.QueryableExtensions;
using GigFeed.Dtos;
using GigFeed.Models;
using Microsoft.AspNet.Identity;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web.Http;

namespace GigFeed.Controllers.Api
{
    [Authorize]
    public class NotificationsController : ApiController
    {
        public ApplicationDbContext _context;

        public NotificationsController()
        {
            _context = new ApplicationDbContext();
        }

        public IEnumerable<NotificationDto> GetNewNotifications()
        {
            var userId = User.Identity.GetUserId();
            var notifications = _context.UserNotifications
                .Where(un => un.UserId == userId && !un.IsRead)
                .Select(un => un.Notification)
                .Include(n => n.Gig.Artist)
                .ProjectTo<NotificationDto>()
                .ToList();

            return notifications;
        }
    }
}
