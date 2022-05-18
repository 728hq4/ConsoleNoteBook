using System;
using System.IO;

namespace NoteBook
{
    internal class Repo
    {
        internal User user = new User("");
        internal User[] users = new User[0]; 
        private Note[] notes = new Note[0];

        #region Notes Methods
        private void PrintNotesList()
        {
            if (notes.Length == 0)
                Console.WriteLine("Список заметок пуст:(");
            else
            {
                string id = "ID";
                string summary = "Заголовок";
                string author = "Автор";
                string createdAt = "Дата создания";
                Console.WriteLine($"{id, 4}|{summary, 40}|{author, 20}|{createdAt, 20}");
                int counter = 0;
                for (int i = 0; i < notes.Length; i++)
                {
                    if (notes[i].Status)
                    {
                        Console.WriteLine($"{notes[i].Id,4}|{notes[i].Summary,40}|{notes[i].Author,20}|{notes[i].CreatedAt,20}");
                        counter++;
                    }
                    
                }
                Console.WriteLine($"Всего: {counter}");
                Console.WriteLine();
                counter = 0;
            }
            DetailNoteMenu();          
        }
        private void PrintNoteById(int id)
        {
            foreach(Note n in notes)
            {
                if(id == n.Id)
                {
                    if (n.Status)
                    {
                        Console.ForegroundColor = ConsoleColor.DarkYellow;
                        Console.WriteLine($"Создано: {n.CreatedAt: f}\nОбновлено: {n.UpdatedAt: f}\n");
                        Console.ForegroundColor = ConsoleColor.Gray;

                        Console.WriteLine($"Заголовок: {n.Summary}\n\nТекст сообщения: {n.Text}\n\nАвтор: {n.Author}");
                        Console.WriteLine();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Выбранная заметка удалена");
                        Menu();
                    }  
                }
            }
        }
        private void AddNote()
        {
            Console.WriteLine("Введите заголовок");
            string sum = Console.ReadLine();
            Console.WriteLine("Введите текст заметки");
            string text = Console.ReadLine();
            
            Note note = new Note(sum, text);
            if(notes.Length < Note.id)
            {
                Array.Resize(ref notes, Note.id);
            }
            notes[Note.id - 1] = note;
            SaveNotes();
        }
        private void OpenNote()
        {
            Console.WriteLine("Введите ID заметки");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            PrintNoteById(id);
            NoteActions(id);
        }
        #endregion

        #region Menu methods
        internal void Menu()
        {
            PrintNotesList();
            DetailNoteMenu();
        }
        private void DetailNoteMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - Открыть заметку\n2 - Создать новую\n3 - Пользователи");
            Console.ForegroundColor = ConsoleColor.Gray;
            byte action = Convert.ToByte(Console.ReadLine());
            switch (action)
            {
                case 1:
                    OpenNote();
                    break;
                case 2:
                    Console.Clear();
                    AddNote();
                    Console.Clear();
                    PrintNotesList();
                    break;
                default:
                    Console.Clear();
                    PrintUsersList();
                    UserActions();
                    break;
            }
        }
        private void DetailUsersMenu()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - Список пользователей\n2 - Главное меню");
            Console.ForegroundColor = ConsoleColor.Gray;
            byte action = Convert.ToByte(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.Clear();
                    PrintUsersList();
                    UserActions();
                    break;
                case 2:
                    Console.Clear();
                    break;
                default:
                    Console.Clear();
                    break;
            }
            Menu();
        }
        private void UserActions()
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - Выбрать пользователя\n2 - Создать нового\n3 - Заметки");
            Console.ForegroundColor = ConsoleColor.Gray;
            byte action1 = Convert.ToByte(Console.ReadLine());
            switch (action1)
            {
                case 1:
                    Console.WriteLine("Введите ID пользователя");
                    ChooseUser(Convert.ToInt32(Console.ReadLine()));
                    Console.Clear();
                    Console.WriteLine($"Вы вошли как {User.CurrentUserName}");
                    break;
                case 2:
                    Console.Clear();
                    CreateUser();
                    Console.Clear();
                    Console.WriteLine($"Пользователь {users[users.Length-1].Name} успешно создан.");
                    break;
                default:
                    Console.Clear();
                    break;
            }
            Menu();
        }
        private void NoteActions(int id)
        {
            Console.ForegroundColor = ConsoleColor.DarkYellow;
            Console.WriteLine("1 - Изменить\n2 - Удалить\n3 - Главное меню");
            Console.ForegroundColor = ConsoleColor.Gray;
            byte action1 = Convert.ToByte(Console.ReadLine());
            switch (action1)
            {
                case 1:
                    Console.Clear();
                    notes[id - 1].EditNote();
                    SaveNotes();
                    Console.Clear();
                    PrintNotesList();
                    break;
                case 2:
                    Console.Clear();
                    notes[id - 1].ChangeStatus();
                    SaveNotes();
                    PrintNotesList();
                    break;
                case 3:
                    Console.Clear();
                    Menu();
                    break;
            }
        }
        #endregion

        #region User Methods
        internal void CheckAndCreateUser()
        {
            if(User.CurrentUserName == "")
            {
                CreateUser();
                ChooseUser(1);
                Console.Clear();
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Привет, {User.CurrentUserName}!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine($"Привет, {User.CurrentUserName}!");
                Console.ForegroundColor = ConsoleColor.Gray;
                Console.WriteLine();
            }
        }
        private void CreateUser()
        {
            Console.WriteLine("Привет! Как тебя зовут?");
            User user = new User (Console.ReadLine());
            if (users.Length < User.Id)
            {
                Array.Resize(ref users, User.Id);
            }
            users[User.Id - 1] = user;
            SaveUsers();
        }
        private void ChooseUser(int id)
        {
            User.CurrentUserName = users[id - 1].Name;
        }
        private void PrintUsersList()
        {
            if (users.Length == 0)
                Console.WriteLine("Список пользователей пуст.");
            else
            {
                string id = "ID";
                string name = "Имя";
                string createdAt = "Дата создания";
                Console.WriteLine($"{id,4}|{name,20}|{createdAt,20}");
                for (int i = 0; i < users.Length; i++)
                {
                    Console.WriteLine($"{users[i].UserId,4}|{users[i].Name,20}|{users[i].CreatedAt,20}");
                }
                Console.WriteLine($"Всего: {users.Length}");
                Console.WriteLine();
            }
        }
        #endregion

        #region Save And Load Methods
        private void LoadNotes()
        {
            string[] lines = File.ReadAllLines("notes.csv");
            foreach(string line in lines)
            {
                string[] row = line.Split(',');
                
                Note note = new Note(row[0], row[1], row[2], row[3], row[4], Convert.ToInt32(row[5]), Convert.ToBoolean(row[6]));
                if (notes.Length < Note.id)
                {
                    Array.Resize(ref notes, Note.id);
                }
                notes[Note.id - 1] = note;
            }

        }
        private void SaveNotes()
        {
            string[] lines = new string[notes.Length];
            for(int i = 0; i < notes.Length; i++)
            {
                lines[i] = $"{notes[i].CreatedAt},{notes[i].UpdatedAt},{notes[i].Text},{notes[i].Summary},{notes[i].Author},{notes[i].Id},{notes[i].Status}";
            }
            File.WriteAllLines("notes.csv", lines);
        }
        private void LoadUsers()
        {
            User.Id--;
            string[] lines = File.ReadAllLines("users.csv");
            foreach (string line in lines)
            {
                string[] row = line.Split(',');

                User user = new User(row[0], row[1], Convert.ToInt32(row[2]));
                if (users.Length < User.Id)
                {
                    Array.Resize(ref users, User.Id);
                }
                users[User.Id - 1] = user;
            }
            if(users.Length != 0)
            {
                ChooseUser(1);
            }
        }
        private void SaveUsers()
        {
            string[] lines = new string[users.Length];
            for(int i = 0; i < users.Length; i++)
            {
                lines[i] = $"{users[i].Name},{users[i].CreatedAt},{users[i].UserId}";
            }
            File.WriteAllLines("users.csv", lines);
        }
        #endregion

        #region Initialisation
        internal void Start()
        {
            LoadNotes();
            SaveNotes();
            LoadUsers();
            SaveUsers();
            CheckAndCreateUser();
        }
        #endregion
    }
}
