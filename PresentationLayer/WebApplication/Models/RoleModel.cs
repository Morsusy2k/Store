using Store.BusinessLogicLayer.Models;
using System.ComponentModel.DataAnnotations;

namespace Store.PresentationLayer.WebApplication.Models
{
    public class RoleModel
    {
        public RoleModel() { }
        public RoleModel(string name)
        {
            Name = name;
        }

        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public bool IsChecked { get; set; }

        public static implicit operator Role(RoleModel rm)
        {
            Role role = new Role(rm.Name)
            {
                Id = rm.Id
            };

            return role;
        }

        public static implicit operator RoleModel(Role r)
        {
            RoleModel role = new RoleModel(r.Name)
            {
                Id = r.Id
            };

            return role;
        }
    }
}