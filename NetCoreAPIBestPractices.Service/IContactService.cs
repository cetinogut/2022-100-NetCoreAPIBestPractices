using NetCoreAPIBestPractices.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCoreAPIBestPractices.Service
{
   public interface IContactService
    {
        public ContactDVO GetContactById(int Id);
    }
}
