using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using NetCoreAPIBestPractices.Models;
using NetCoreAPIBestPractices.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly IContactService _contactService;

        public ContactController(IConfiguration Configuration, IContactService ContactService)
        {
            _configuration = Configuration;
            _contactService = ContactService;
        }

        [HttpGet]
        public String Get()
        {
            return _configuration["EMAIL_ADDRESS"].ToString();
        }

        [ResponseCache(Duration =20)] // keep the id and its info in the cache for 10 secs
        [HttpGet("{id}")]
        public ContactDVO GetContactById(int id)
        {
            return _contactService.GetContactById(id);
        }

        [HttpPost]
        public ContactDVO CreateContact(ContactDVO contact)
        {

            // create contact in DB then return as below

            return contact;
        }
    }
}
