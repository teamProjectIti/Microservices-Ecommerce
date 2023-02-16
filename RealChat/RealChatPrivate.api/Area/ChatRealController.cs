using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using RealChatPrivate.api.Controllers;
using Repositery.Implemint.SignalR;
using System.Security.Claims;

namespace RealChatPrivate.api.Area
{
    public class ChatRealController : BaseController
    {

        //private readonly IPrivateMessageRepository _privateMessageRepository;
        //private readonly UserManager<ApplicationUser> _userManager;

        //public ChatRealController(IPrivateMessageRepository privateMessageRepository,
        //                                UserManager<ApplicationUser> userManager)
        //{
        //    _privateMessageRepository = privateMessageRepository;
        //    _userManager = userManager;
        //}



        [HttpPost]
        public async Task<IActionResult> SendMessage(string recipientId, string message)
        {
            var senderId = User.FindFirst(ClaimTypes.NameIdentifier).Value;

           // await _privateMessageRepository.SendMessage(recipientId, message);

            return Ok();
        }
    }
}
