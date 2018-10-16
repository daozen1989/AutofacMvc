namespace Web.Interfaces.DbEntities
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;
    using Web.Interfaces.Utilities;

    public class UserEntity
    {
        public UserEntity()
        {
        }

        public UserEntity(object srcObj, char separator)
            : this()
        {
            ModelMapper.MappingCamelUpper(srcObj, this, separator);
        }

        public int Id { get; set; }

        public string Password { get; set; }

        public string email { get; set; }

        public string Name { get; set; }

        public int? TeamId { get; set; }

        public int RoleId { get; set; }

        public string Description { get; set; }
    }
}
