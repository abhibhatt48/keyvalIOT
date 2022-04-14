using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using keyvalueIoT.Models;
using keyvalueIoT.Data;

namespace keyvalueIoT.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class KeyvaluesController : ControllerBase
    {
        private readonly IMatchRepository _repository;

        public KeyvaluesController(IMatchRepository repository)
        {
            _repository = repository;
        }


        [HttpGet("keys/{key}")]
        public ActionResult<Keyvalue> Get(string key)
        {
            if (_repository.Exist(key))
            {
                var match = _repository.GetMatchbykey(key);
                return match;
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, "Specified key absence");
            }
        }

        [HttpPost("keys")]
        public async Task<ActionResult<Keyvalue>> Post([FromBody] Keyvalue keyvalue)
        {
            var exist = _repository.Exist(keyvalue.Key);
            if (exist)
            {
                return StatusCode(StatusCodes.Status409Conflict, "Specified Key already exist");
            }
            _repository.Add(keyvalue);
            if (await _repository.SaveChanges())
            {
                return Created($"/api/keyvalue/keys/{keyvalue.Key}", keyvalue);
            }

            return BadRequest();


        }



        [HttpDelete("keys/{key}")]
        public async Task<IActionResult> Delete(string key)
        {
            var exists = _repository.Exist(key);
            if (exists)
            {
                var value = _repository.GetMatchbykey(key);
                _repository.Delete(value);
                if (await _repository.SaveChanges())
                {
                    return Ok();
                }
                else
                {
                    return BadRequest($"Failed to delete {key}");
                }
            }
            else
            {
                return StatusCode(StatusCodes.Status404NotFound, " Key does not exist");
            }

        }
        [HttpPatch("keys/{key}/{value}")]
        public async Task<IActionResult> Patch(string key, string value)
        {
            var exist = _repository.Exist(key);
            if (exist)
            {
                _repository.Update(key, value);
            }
            if (await _repository.SaveChanges())
            {
                return Ok();
            }
            return StatusCode(StatusCodes.Status404NotFound, "Specified Key already exist");
        }
    }          
}
