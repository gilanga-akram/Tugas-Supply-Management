using Microsoft.AspNetCore.Authentication;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using API.Models.Account;

namespace API.Models
{
    [Table("tb_m_account_roles")]
    public class AccountRole : BaseEntity
    {
        [Column("account_guid")]
        public Guid AccountGuid { get; set; }

        [Column("role_guid")]
        public Guid RoleGuid { get; set; }

        //Cardinality
        public Account? Account { get; set; }
        public Role? Role { get; set; }

    }
}