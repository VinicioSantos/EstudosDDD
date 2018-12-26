using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using AutoMapper;
using ProjetoModeloDDD.Domain.Entities;
using ProjetoModeloDDD.MVC.ViewModels;

namespace ProjetoModeloDDD.MVC.AutoMapper
{
    public class DomainToViewModelMappingProfile : Profile
    {

        public DomainToViewModelMappingProfile()
        {
            CreateMap<ClienteViewModel, Cliente>();
            CreateMap<ProdutoViewModel,Produto>();

            // Use CreateMap... Etc.. here (Profile methods are the same as configuration methods)
        }

        public override string ProfileName
        {
            get { return "ViewModelToDomainMappingProfile"; }
        }

        

    }
}