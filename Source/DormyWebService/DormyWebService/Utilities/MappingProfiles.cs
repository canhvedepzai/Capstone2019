﻿using AutoMapper;
using DormyWebService.Entities.AccountEntities;
using DormyWebService.Entities.NewsEntities;
using DormyWebService.Entities.ParamEntities;
using DormyWebService.ViewModels.NewsViewModels;
using DormyWebService.ViewModels.NewsViewModels.CreateNews;
using DormyWebService.ViewModels.NewsViewModels.GetNewsHeadlines;
using DormyWebService.ViewModels.UserModelViews;
using DormyWebService.ViewModels.UserModelViews.GetAllStudent;
using DormyWebService.ViewModels.UserModelViews.Param;
using DormyWebService.ViewModels.UserModelViews.UpdateStudent;
using Microsoft.AspNetCore.Identity.UI.V3.Pages.Account.Internal;

namespace DormyWebService.Utilities
{
    //Declare mapping profiles
    public class MappingProfiles : Profile
    {
        public MappingProfiles()
        {
            CreateMap<UpdateStudentRequest, Student>();
            CreateMap<CreateNewsRequest, News>();
            CreateMap<Student, UpdateStudentResponse>();
            CreateMap<Student, GetAllStudentResponse>();
            CreateMap<Student, FindByIdStudentResponse>();
            CreateMap<News, CreateNewsResponse>();
            CreateMap<News, GetNewsHeadlinesResponse>();
            CreateMap<Param, ParamModelView>();
        }
    }
}