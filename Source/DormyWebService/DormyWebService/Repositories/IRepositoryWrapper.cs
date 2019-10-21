﻿using DormyWebService.Entities.NewsEntities;
using DormyWebService.Repositories.EquipmentRepository;
using DormyWebService.Repositories.NewsRepositories;
using DormyWebService.Repositories.ParamRepositories;
using DormyWebService.Repositories.RoomRepositories;
using DormyWebService.Repositories.UserRepositories;

namespace DormyWebService.Repositories
{
    public interface IRepositoryWrapper
    {
        IUserRepository User { get; }

        IStudentRepository Student { get; }

        IAdminRepository Admin { get; }

        INewsRepository News { get; }

        IParamRepository Param { get; }

        IParamTypeRepository ParamType { get;}

        IEquipmentRepository Equipment { get; }

        IRoomRepository Room { get; }
    }
}