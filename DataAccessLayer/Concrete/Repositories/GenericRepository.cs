using DataAccessLayer.Abstract;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace DataAccessLayer.Concrete.Repositories
{
    public class GenericRepository<T> : IRepository<T> where T : class
    {

        Context c = new Context();

        DbSet<T> _object;

        //ctor tab tab
        public GenericRepository()
        {
            _object = c.Set<T>();// dışarıdan gelen t değerini object üstüne aldı - object isimli field dışarıdan gönderilen değer neyse o olcak
        }


        public void Delete(T p)
        {
            _object.Remove(p);
            c.SaveChanges();
        }

        public void Insert(T p)
        {
            _object.Add(p);
            c.SaveChanges();
        }

        public List<T> List()
        {
            return _object.ToList();
        }

        public List<T> List(Expression<Func<T, bool>> filter)
        {
            return _object.Where(filter).ToList();  //filterdan gelen değer neyse onu listeliycek 
        }

        public void Update(T p)
        {
            c.SaveChanges();
        }
    }
}
