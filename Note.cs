using System;
using System.Globalization;


namespace NoteBook
{
    internal class Note
    {
        static public int id = 0;

        #region Note fields
        internal string CreatedAt { get; } = Convert.ToString(DateTime.Now); 
        internal string UpdatedAt { get; set; } = Convert.ToString(DateTime.Now);
        internal string Text { get; set; } = "";
        internal string Summary { get; set; } = "";
        internal string Author { get; set; }
        internal bool Status { get; set; } = true;
        internal int Id { get; }
        #endregion

        #region Constructors
        internal Note(string createdAt, string updatedAt, string text, string summary, string author, int id, bool status)
        {
            CreatedAt = createdAt;
            UpdatedAt = updatedAt;
            Text = text;
            Summary = summary;
            Author = author;
            Note.id++;
            Id = id;
            Status = status;
        }
        internal Note(string summary, string text)
        {
            Summary = summary;
            Text = text;
            Author = User.CurrentUserName;
            id++;
            Id = id;
            Status = true;
        }
        internal Note(string summary) : this(summary, "Напишите что-нибудь...") { }
        #endregion

        #region Note Methods      
        internal void EditNote()
        {
            Console.WriteLine("Какое поле редактировать?\n1 - Заголовок\n2 - Текст сообщения");
            byte action = Convert.ToByte(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine($"Текущий заголовок: {Summary}\nНовый заголовок: ");
                    Summary = Console.ReadLine();
                    UpdatedAt = Convert.ToString(DateTime.Now);
                    break;
                case 2:
                    Console.WriteLine($"Текущий текст: {Text}\nНовый текст: ");
                    Text = Console.ReadLine();
                    UpdatedAt = Convert.ToString(DateTime.Now);
                    break;
                default:
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Неизвестная команда.");
                    Console.ForegroundColor = ConsoleColor.Gray;
                    break;
            }
        }
        internal void ChangeStatus()
        {
            if (Status)
            {
                Status = false;
                Console.WriteLine($"Заметка {this.Id} удалена.");
                UpdatedAt = Convert.ToString(DateTime.Now);
            }
                
            else
            {
                Status = true;
                Console.WriteLine($"Заметка {this.Id} восстановлена.");
                UpdatedAt = Convert.ToString(DateTime.Now);
            }
        }
        #endregion

    }
}
