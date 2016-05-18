using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WatPhaSom.Models
{
    public class GroupedUserViewModel
    {
        public List<UserViewModel> UsersWholeSale { get; set; }
        public List<UserViewModel> UsersRetail { get; set; }
    }

    public class UserViewModel
    {
        public string Username { get; set; }
        public string Roles { get; set; }
    }
}
