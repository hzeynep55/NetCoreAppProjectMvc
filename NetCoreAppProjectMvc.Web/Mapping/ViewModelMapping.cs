using AutoMapper;
using NetCoreAppProjectMvc.Web.Models;
using NetCoreAppProjectMvc.Web.ViewModels;

namespace NetCoreAppProjectMvc.Web.Mapping
{
    public class ViewModelMapping:Profile
    {
        public ViewModelMapping()
        {
            CreateMap<Product, ProductViewModel>().ReverseMap();
        }
    }
}
