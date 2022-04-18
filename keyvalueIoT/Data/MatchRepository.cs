using keyvalueIoT.Models;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyvalueIoT.Data
{
    public class MatchRepository : IMatchRepository
    {
        private readonly KeyValueContext _context;
        private readonly ILogger<MatchRepository> _logger;

        public MatchRepository(KeyValueContext context, ILogger<MatchRepository> logger)
        {
            _context = context;
            _logger = logger;
        }

        public void Add<T>(T entity) where T : class
        {
            _logger.LogInformation($"Adding an object {entity.GetType()} to the context");
            _context.Add(entity);
        }

        public void Delete(Keyvalue keyvalue)
        {
            _logger.LogInformation($"Removing the Keyvalue by {keyvalue.Key} to the context");
            _context.Remove(keyvalue);
        }

        public bool Exist(string key)
        {
            return _context.KeyItems.Where(x => x.Key == key.ToString()).Any();
        }

        public Keyvalue GetMatchbykey(string key)
        {
            _logger.LogInformation($"Getting keyvalue by key");
            var q = from contxt in _context.KeyItems
                        where contxt.Key == key
                        select contxt;
            var r = q.ToArray();
            return r[0];
        }

        public async Task<bool> SaveChanges()
        {
            _logger.LogInformation($"Save changes");
            return(await _context.SaveChangesAsync()) > 0;
        }
         
        public void Update(string key, string value)
        {
            var query = _context.KeyItems.Where(m => m.Key == key).ToArray().ElementAt(0).Value = value;
        }
    }
}
