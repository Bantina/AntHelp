using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QX_Frame.Model.DTO
{
    [Serializable]
    public class UserViewModel
    {
        public Guid Uid { get; set; }

        public int loginId { get; set; }

        public string NickName { get; set; }

        public int Age { get; set; }

        public string Email { get; set; }

        public string ClassName { get; set; }
    }
}
