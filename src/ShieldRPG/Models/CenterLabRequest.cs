using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Threading.Tasks;

namespace ShieldRPG.Models
{
    public class CenterLabRequest
    {
        public Guid Id { get; set; }

        [DisplayName("Пользователь")]
        public string UserName { get; set; }

        [DisplayName("Запрос")]
        public string Request { get; set; }

        [DisplayName("Ответ центральной лаборатории")]
        public string Response { get; set; }
    }
}
