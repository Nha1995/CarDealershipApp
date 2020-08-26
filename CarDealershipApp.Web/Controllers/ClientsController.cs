using CarDealershipDomain;
using CarDealershipRepository.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using CarDealershipApp.Web;
using CarDealershipApp.Web.Models;
using AutoMapper;
using Microsoft.AspNetCore.Http;

namespace CarDealershipApp.Web.Controllers
{
    [Route("[controller]")]
    public class ClientsController : Controller
    {
        private readonly IClientRepository _clientRepository;
        private readonly IMapper _mapper;

        public ClientsController(IClientRepository clientRepository, IMapper mapper)
        {
            _clientRepository = clientRepository;
            _mapper = mapper;
        }

        [HttpGet]
        public ActionResult<List<ClientVm>> ListClients(bool sold)
        {
            try
            {
                var res = _clientRepository.ClientList(sold);

                var models = _mapper.Map<List<ClientVm>>(res);

                return Ok(models);
            }
            catch (Exception)
            {
                return this.StatusCode(StatusCodes.Status500InternalServerError, "Database failed");
            }
        }

        [HttpGet("{passportId}")]
        public ActionResult<Client> GetClientByPassportId([FromRoute] string passportId)
        {
            var res = _clientRepository.GetClientByPassportId(passportId);

            if (res == null)
                return NotFound();

            return Ok(res);
        }

        [HttpPost]
        public ActionResult<ClientVm> AddClient([FromBody] ClientBaseModel client)
        {
            var entity = _mapper.Map<Client>(client);
            
            var success = _clientRepository.AddClient(entity);
            if (!success)
            {
                return BadRequest($"Client with Passport Id: {entity.PassportId} already exists");
            }

            var Vm = _mapper.Map<ClientVm>(entity);

            return Ok(Vm);
        }
    }
}