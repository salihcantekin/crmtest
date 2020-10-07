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
        public String Get()
        {
            String local = $"Local Ip Address: {accessor.HttpContext.Connection.LocalIpAddress.MapToIPv4()}";
            String remote = $"Local Ip Address: {accessor.HttpContext.Connection.RemoteIpAddress.MapToIPv4()}";

            return $"{local}\n{remote}";
        }

        [HttpGet("{id}")]
        public Contact GetById(int id)
        {
            return context.Contact.FirstOrDefault(i => i.Id == id);
        }
    }
}
