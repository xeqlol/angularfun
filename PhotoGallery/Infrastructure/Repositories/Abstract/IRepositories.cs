﻿using PhotoGallery.Entities;
using System.Collections.Generic;

namespace PhotoGallery.Infrastructure.Repositories.Abstract
{
    public interface IAlbumRepository       : IEntityBaseRepository<Album> { }
    public interface ILoggingRepository     : IEntityBaseRepository<Error> { }
    public interface IPhotoRepository       : IEntityBaseRepository<Photo> { }
    public interface IRoleRepository        : IEntityBaseRepository<Role> { }
    public interface IUserRoleRepository    : IEntityBaseRepository<UserRole> { }
    public interface IUserRepository        : IEntityBaseRepository<User>
    {
        User GetSingleByUsername(string username);
        IEnumerable<Role> GetUserRoles(string username);
    }
}
