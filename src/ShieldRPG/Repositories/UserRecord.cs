using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Repositories
{
    public class UserRecord
    {
        [DisplayName("Имя пользователя")]
        public string UserName { get; set; }

        [DisplayName("Логин")]
        public string Login { get; set; }

        [DisplayName("Пароль")]
        public string Password { get; set; }

        [DisplayName("Уровень доступа")]
        public int Access { get; set; }

        [DisplayName("Уровень навыка взломщика")]
        public int HackerRank { get; set; }

        [DisplayName("Роли")]
        public string[] Roles { get; set; }
    }
}