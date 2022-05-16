using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox
{
    internal class Note
    {
        static public int id = 0;

        #region Note fields
        internal DateTime CreatedAt { get; } = DateTime.Now;
        private DateTime UpdatedAt { get; set; } = DateTime.Now;
        internal string Text { get; set; } = "";
        internal string Summary { get; set; } = "";
        internal string Author { get; set; }
        internal int Id { get; }
        private bool status { get; set; } = true;
        #endregion

        #region Constructors
        internal Note(string summary, string text)
        {
            Summary = summary;
            Text = text;
            Author = User.CurrentUserName;
            id++;
            Id = id;
        }
        internal Note(string summary) : this(summary, "Write something...") { }
        #endregion

        #region Note Methods      
        internal void PrintNote()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine($"Created: {CreatedAt: f}\nUpdated: {UpdatedAt: f}\n");
            Console.ForegroundColor = ConsoleColor.Gray;

            Console.WriteLine($"Summary: {Summary}\n{Text}\nAuthor: {Author}");
            Console.WriteLine();
        }
        internal void EditNote()
        {
            Console.WriteLine("Whitch field do you want to edit?\n1 - Summary\n2 - Message");
            byte action = Convert.ToByte(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine($"Current summary: {Summary}\nNew summary: ");
                    Summary = Console.ReadLine();
                    break;
                case 2:
                    Console.WriteLine($"Current message: {Text}\nNew message: ");
                    Text = Console.ReadLine();
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Unknown command.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        internal void DeleteNote()
        {
            if (status)
            {
                status = false;
                Console.WriteLine("Note has been deleted.");
            }
            else
                Console.WriteLine("This note is already deleted!");
        }
        internal void ActivateNote()
        {
            if (!status)
                status = true;
            else
                Console.WriteLine("This note is already activated!");
        }
        #endregion

    }
}
