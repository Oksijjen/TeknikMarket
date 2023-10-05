using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Business.Abstract;
using TeknikMarket.DataAccess.Abstract;
using TeknikMarket.Model.Entity;

namespace TeknikMarket.Business.Concrete
{
    public class BankaBS : IBankaBS
    {
        private IBankaRepository repo;

        public BankaBS(IBankaRepository _repo)
        {
            repo = _repo;
        }

        public Banka Delete(Banka entity)
        {
            return repo.Delete(entity);
        }

        public Banka Delete(int Id)
        {
            return repo.Delete(Id);
        }

        public Banka Get(Expression<Func<Banka, bool>> filter, params string[] incluedelist)
        {
            return repo.Get(filter, incluedelist);
        }

        public List<Banka> GetAll(Expression<Func<Banka, bool>> filter, params string[] incluedelist)
        {
            return repo.GetAll(filter, incluedelist);
        }

        public Banka GetById(int Id, params string[] incluedelist)
        {
            return repo.GetById(Id, incluedelist);
        }

        public Banka Insert(Banka entity)
        {
            return repo.Insert(entity);
        }

        public Banka Update(Banka entity)
        {
            return repo.Update(entity);
        }
        

       
    }
}
