using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Crm.Data.Context;
using Crm.Data.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace Crm.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ContactController : ControllerBase
    {
        private readonly CrmDbContext context;
        private readonly IHttpContextAccessor accessor;

        public ContactController(CrmDbContext Context, IHttpContextAccessor Accessor)
        {
            context = Context;
            accessor = Accessor;
        }

        [HttpGet]
        public Contact Get()
        {
            return context.Contact.FirstOrDefault();   
        }

        [HttpGet("{id}")]
        public Contact GetById(int id)
        {
            return context.Contact.FirstOrDefault(i => i.Id == id);
        }

        [HttpGet("GetIP")]
        public String GetIP()
        {
            return accessor.HttpContext.Connection.RemoteIpAddress.ToString();
        }
    }
}
