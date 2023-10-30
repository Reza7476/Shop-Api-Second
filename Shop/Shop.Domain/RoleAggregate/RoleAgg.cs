using Common.Domain;
using Common.Domain.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shop.Domain.RoleAggregate
{
    public class RoleAgg : AggregateRoot
    {
        public string Title { get; private set; }
        public List<RolePermissionAgg> Permissions { get; private set; }
        private RoleAgg()//برای efcore
        {

        }
        public RoleAgg(string title, List<RolePermissionAgg> permission)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
            Permissions = permission;
        }
        public RoleAgg(string title)
        {
            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
            Permissions = new List<RolePermissionAgg>();

        }

        public void SetPermission(List<RolePermissionAgg> permission)
        {

            Permissions = permission;
        }

        public void Edit(string title)
        {

            NullOrEmptyDomainDataException.CheckString(title, nameof(title));
            Title = title;
        }


    }


}
