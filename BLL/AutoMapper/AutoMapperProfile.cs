using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using BLL.Models;
using DAL.Entities;

namespace BLL.AutoMapper
{
    class AutoMapperProfile : Profile
    {
        public AutoMapperProfile()
        {
            CreateMap<EmployeeModel, EmployeeEntity>();
            CreateMap<EmployeeEntity, EmployeeModel>();
        }
    }
}
