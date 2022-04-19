using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.Models.Repository;

namespace WebApplication1.Models.DataManager
{
    public class EmployeeManager : IDataRepository<Keyvalue>
    {
        readonly KeyvalueContext _keyvalueContext;

        public EmployeeManager(KeyvalueContext context)
        {
            _keyvalueContext = context;
        }
        public IEnumerable<Keyvalue> GetAll()
        {
            return _keyvalueContext.KeyItems.ToList();
        }
        public Keyvalue Get(string key)
        {
            return _keyvalueContext.KeyItems
                  .FirstOrDefault(e => e.Key == key);
        }
        public void Add(Keyvalue entity)
        {
            _keyvalueContext.KeyItems.Add(entity);
            _keyvalueContext.SaveChanges();
        }
        public void Update(Keyvalue employee, Keyvalue entity)
        {
            
            employee.Value = entity.Value;

            _keyvalueContext.SaveChanges();
        }
        public void Delete(Keyvalue employee)
        {
            _keyvalueContext.KeyItems.Remove(employee);
            _keyvalueContext.SaveChanges();
        }
    }
}
