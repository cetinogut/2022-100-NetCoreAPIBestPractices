using AutoMapper;
using NetCoreAPIBestPractices.Data.Models;
using NetCoreAPIBestPractices.Models;
using System;
using System.Net.Http;

namespace NetCoreAPIBestPractices.Service
{
    public class ContactService : IContactService
    {
        private readonly IMapper _mapper;
        private readonly IHttpClientFactory _httpClientFactory;

        public ContactService(IMapper mapper, IHttpClientFactory httpClientFactory)
        {
            _mapper = mapper;
            _httpClientFactory = httpClientFactory;
        }
        public ContactDVO GetContactById(int Id)
        {
            Contact dbContact = getDummyContact();
            var client= _httpClientFactory.CreateClient("garanti.api");


            //return new ContactDVO()  //without automapper
            //{
            //    Id = dbContact.Id,
            //    FullName = $"{dbContact.FirstName} {dbContact.LastName}"
            //};

            //ContactDVO resultContact = new ContactDVO(); // this can be done in one line as below
            //_mapper.Map(dbContact, resultContact);

            ContactDVO resultContact = _mapper.Map<ContactDVO>(dbContact);
            return resultContact;
        }

         private Contact getDummyContact() // this is a fake method respresnting the DB connection. It brings the DB Object
        {
            return new Contact
            {
                Id = 1,
                FirstName = "Dastugo",
                LastName = "the Company"
            };
        }
    }
}
