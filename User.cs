using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NoteBook
{
    internal class User
    {
        static internal int Id = 0;
        
        #region User Fields
        internal string Name { get; set; } = "Undefined";
        internal string CreatedAt { get; set; } = Convert.ToString(DateTime.Now);
        internal int UserId { get; set; }
        internal static string CurrentUserName { get; set; } = "";
        #endregion

        #region Constructors
        internal User(string name) : this(name, Convert.ToString(DateTime.Now), User.Id+1) { }
        internal User(string name, string createdAt, int id)
        {
            this.Name = name;
            this.CreatedAt = createdAt;
            Id++;
            this.UserId = id;
        }
        #endregion
    }
}