using Core.Data.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.DataAccess.Abstract;
using TeknikMarket.DataAccess.Concrete.EntityFramework.context;
using TeknikMarket.Model.Entity;

namespace TeknikMarket.DataAccess.Concrete.EntityFramework.repository
{
    public class EFSiparisKampanyaRepository : EfRepositoryBase<SiparisKampanya, TeknikMarketDBContext>, ISiparisKampanyaRepository
    {
    }
}
