using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Web.Interfaces.DbEntities;

namespace Web.Gui.Models
{
    public class UserViewModel
    {
        public List<UserEntity> UserList { get; set; }
    }
}