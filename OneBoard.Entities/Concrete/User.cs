using OneBoard.Entities.Abstract;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneBoard.Entities.Concrete
{
    public class User:IEntity
    {
        public int ID { get; set; }
        public string UserName { get; set; }
        public string LoginName { get; set; }
        [Required()]
        public string Password { get; set; }
        public DateTime LastLogin { get; set; }
        public int UserType{ get; set; }
        public string RefreshToken { get; set; }
        public DateTime? RefreshTokenEndDate { get; set; }
        public IEnumerable<UserFirm> UserFirms { get; set; }
        public IEnumerable<UserGroup> UserGroups { get; set; }
        public IEnumerable<Dashboard> Dashboards { get; set; }
    }
}
