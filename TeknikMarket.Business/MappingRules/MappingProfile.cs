using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeknikMarket.Model.Entity;
using TeknikMarket.Model.ViewModel.Areas.Admin.Kategories;
using TeknikMarket.Model.ViewModel.Areas.Admin.Urunlers;

namespace TeknikMarket.Business.MappingRules
{
    public class MappingProfile: Profile
    {
        public MappingProfile()
        {
            CreateMap<KategoriListeViewModel, Kategori>().ReverseMap();

            CreateMap<Urun, UrunAddViewModel>().ReverseMap();



        }
    }
}
