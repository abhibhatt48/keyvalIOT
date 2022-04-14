using keyvalueIoT.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace keyvalueIoT.Data
{
    public interface IMatchRepository
    {
        void Add<T>(T entity) where T : class;
        void Delete(Keyvalue keyvalue);
        void Update(string key, string value);

        Task<bool> SaveChanges();

        //Get method
        public bool Exist(string key);

        Keyvalue GetMatchbykey(string key);
    }
}
