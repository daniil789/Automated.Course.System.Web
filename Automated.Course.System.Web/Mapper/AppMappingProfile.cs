﻿using AutoMapper;
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
            CreateMap<CourseDTO, DAL.Entities.Course>();
            CreateMap<CourseDTO, CourseViewModel>();

            CreateMap<DAL.Entities.Chapter, ChapterDTO>();
            CreateMap<ChapterDTO, DAL.Entities.Chapter>();
            CreateMap<ChapterDTO, ChapterViewModel>();

            CreateMap<DAL.Entities.Task, TaskDTO>();
            CreateMap<TaskDTO, DAL.Entities.Task>();
            CreateMap<TaskDTO, TaskViewModel>();


            CreateMap<DAL.Entities.Language, LanguageDTO>();
            CreateMap<LanguageDTO, LanguageViewModel>();
        }
    }
}
