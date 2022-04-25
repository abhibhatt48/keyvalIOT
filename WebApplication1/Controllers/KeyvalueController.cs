using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models;
using WebApplication1.Models.Repository;

namespace WebApplication1.Controllers
{

    
    [Route("api/keys")]
    [ApiController]

    public class KeyvalueController : ControllerBase
    {
            private readonly IDataRepository<Keyvalue> _dataRepository;
            public KeyvalueController (IDataRepository<Keyvalue> dataRepository)
            {
                _dataRepository = dataRepository;
            }
            [HttpGet]
            public IActionResult Get()
            {
                IEnumerable<Keyvalue> keyitems = _dataRepository.GetAll();
                return Ok(keyitems);
            }

            [HttpGet("{Key}", Name = "Get")]
            public IActionResult Get(string Key)
            {
                Keyvalue value = _dataRepository.Get(Key);
                if (value == null)
                {

                 return StatusCode(StatusCodes.Status404NotFound, "Key is not here");
                }
                return Ok(value);
            }

            [HttpPost]
            public IActionResult Post([FromBody] Keyvalue keyvalue)
            {
                if (keyvalue == null)
                {
                    return BadRequest("key is null.");
                }
                _dataRepository.Add(keyvalue);
                return CreatedAtRoute(
                      "Get",
                      new { Key = keyvalue.Key },
                      keyvalue);
            }
            [HttpPatch("{Key}")]
            public IActionResult Patch(string key, [FromBody] Keyvalue keyvalue)
            {
                if (keyvalue == null)
                {
                    return BadRequest("Employee is null.");
                }
                Keyvalue keyToUpdate = _dataRepository.Get(key);
                if (keyToUpdate == null)
                {
                    return StatusCode(StatusCodes.Status409Conflict, "Key already exist");
                }
                _dataRepository.Update(keyToUpdate, keyvalue);
                return NoContent();
            }

            [HttpDelete("{Key}")]
            public IActionResult Delete(string key)
            {
                Keyvalue val = _dataRepository.Get(key);
                if (val == null)
                {
                    return StatusCode(StatusCodes.Status404NotFound, "Key already exist");
                }
                _dataRepository.Delete(val);
                return NoContent();
            }     
        }
    }

