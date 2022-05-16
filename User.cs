using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox
{
    internal class User
    {
        User[] users;
        static int Id = 0;
        
        #region User Fields
        internal string Name { get; set; } = "Undefined";
        internal DateTime CreatedAt { get; set; } = DateTime.Now;
        internal int UserId { get; set; }
        public static string CurrentUserName { get; set; }
        #endregion
    }
}
