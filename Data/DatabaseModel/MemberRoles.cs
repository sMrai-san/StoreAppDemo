using System;
using System.Collections.Generic;

// Code scaffolded by EF Core assumes nullable reference types (NRTs) are not used or disabled.
// If you have enabled NRTs for your project, then un-comment the following line:
// #nullable disable

namespace StoreApp.Data.DatabaseModel
{
    public partial class MemberRoles
    {
        public int MemberRoleId { get; set; }
        public int? MemberId { get; set; }
        public int? RoleId { get; set; }
    }
}
