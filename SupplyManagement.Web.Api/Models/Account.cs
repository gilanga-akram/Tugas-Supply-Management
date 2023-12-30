using System.ComponentModel.DataAnnotations.Schema;
using API.Models;



namespace API.Models.Account
{
    public class Accounts
    {

        [Column("username", TypeName = "nvarchar(max)")]
        public string Username { get; set; }

        [Column("password", TypeName = "nvarchar(max)")]
        public string Password { get; set; }


        //Cardinality
        public Employee? Employee { get; set; }

        public ICollection<AccountRole>? AccountRoles { get; set; }
    }
}