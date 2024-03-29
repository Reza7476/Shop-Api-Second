﻿using Common.Domain;

namespace Shop.Domain.UserAggregate
{
    public class UserRoles : BaseEntity
    {
        public UserRoles(long roleId)
        {
            RoleId = roleId;
        }

        public long UserId { get; internal set; }
        public long RoleId { get; private set; }

    }
}
