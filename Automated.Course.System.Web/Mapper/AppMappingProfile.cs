using AutoMapper;
using Automated.Course.System.BLL.DTO;
using Automated.Course.System.DAL;
using Automated.Course.System.Web.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automated.Course.System.Web.Mapper
{
    public class AppMappingProfile : Profile
    {
        public AppMappingProfile()
        {
            CreateMap<DAL.Entities.Course, CourseDTO>();
            CreateMap<CourseDTO, CourseViewModel>();
        }
    }
}
