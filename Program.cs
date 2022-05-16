using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace SkillBox
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Repo repo = new Repo();
            repo.MainMenu();
            // Ожидание ввода
            Console.ReadLine();
        }
    }
}
