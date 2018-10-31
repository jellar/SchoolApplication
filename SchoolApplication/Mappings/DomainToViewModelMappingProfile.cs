using AutoMapper;
using SchoolApplication.Data;
using SchoolApplication.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SchoolApplication.Mappings
{
    public class DomainToViewModelMappingProfile : Profile
    {
        public DomainToViewModelMappingProfile()
        {            
            CreateMap<Course, CourseViewModel>();
        }       
        
    }
}