using Hrm.Helpers;
using HumanResource.Entity;
using HumanResource.Services;
using Microsoft.AspNetCore.Mvc;

namespace HumanResource.Controllers
{
    public class ContactController : ApiBaseController
    {
        private readonly IContactService _contactService;
        public ContactController(IContactService contactService)
        {
            _contactService = contactService;
        }



        [Route("contacts")]
        [HttpPost]
        public async Task<IActionResult> RegisterContacts([FromBody]Contact contact)
        {
            return await ResponseWrapperAsync(async () =>
            {
                await _contactService.RegisterOrUpdate(contact);
                return true;
            });
        }

    }
}
