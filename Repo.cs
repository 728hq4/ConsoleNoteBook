using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox
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
                Console.WriteLine("Notes list is empty.");
            else
            {
                string id = "ID";
                string summary = "Summary";
                string author = "Author";
                string createdAt = "Created";
                Console.WriteLine($"{id, 4}|{summary, 40}|{author, 20}|{createdAt, 20}");
                for (int i = 0; i < notes.Length; i++)
                {
                    Console.WriteLine($"{notes[i].Id, 4}|{notes[i].Summary, 40}|{notes[i].Author, 20}|{notes[i].CreatedAt, 20}");
                }
                Console.WriteLine($"Total: {notes.Length}");
            }
            DetailNoteMenu();          
        }
        private void AddNote()
        {
            Console.WriteLine("Enter the summary");
            string sum = Console.ReadLine();
            Console.WriteLine("Enter the note");
            string text = Console.ReadLine();
            
            Note note = new Note(sum, text);
            if(notes.Length < Note.id)
            {
                Array.Resize(ref notes, Note.id);
            }
            notes[Note.id - 1] = note;
        }
        private void OpenNote()
        {
            Console.WriteLine("Enter the note ID");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Clear();
            notes[id - 1].PrintNote();
            NoteActions(id);
        }
        private void DeleteNote(int id)
        {
            Array.Clear(notes, id, 1);
            notes[id] = notes[notes.Length-1];
            Array.Resize(ref notes, notes.Length - 1);
            Note.id--;
        }
        #endregion
        
        #region Menu methods
        internal void MainMenu()
        {
            Console.WriteLine("1 - Notes\n2 - Users");
            byte action = Convert.ToByte(Console.ReadLine());
            Console.Clear();
            switch (action)
            {
                case 1:
                    PrintNotesList();
                    DetailNoteMenu();
                    break;
                case 2:
                    Console.Clear();
                    DetailUsersMenu();
                    break;
                default:
                    Console.Clear();
                    break;
            }
            Console.Clear();
            MainMenu();
        }
        private void DetailNoteMenu()
        {
            Console.WriteLine("1 - Open a note\n2 - Add a note\n3 - Main menu");
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
                    MainMenu();
                    break;
            }
        }
        private void DetailUsersMenu()
        {
            Console.WriteLine("1 - Users list\n2 - Main menu");
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
            MainMenu();
        }
        private void UserActions()
        {
            Console.WriteLine("1 - Select User\n2 - Create new one\n3 - Main menu");
            byte action1 = Convert.ToByte(Console.ReadLine());
            switch (action1)
            {
                case 1:
                    Console.WriteLine("Enter the user ID");
                    ChooseUser(Convert.ToInt32(Console.ReadLine()));
                    Console.Clear();
                    Console.WriteLine($"Now you have logged as {User.CurrentUserName}");
                    break;
                case 2:
                    Console.Clear();
                    CreateUser();
                    Console.Clear();
                    Console.WriteLine($"User {users[users.Length-1].Name} has been created.");
                    break;
                default:
                    Console.Clear();
                    break;
            }
            MainMenu();
        }
        private void NoteActions(int id)
        {
            Console.WriteLine("1 - Edit\n2 - Delete\n3 - Main menu");
            byte action1 = Convert.ToByte(Console.ReadLine());
            switch (action1)
            {
                case 1:
                    Console.Clear();
                    notes[id - 1].EditNote();
                    Console.Clear();
                    PrintNotesList();
                    break;
                case 2:
                    Console.Clear();
                    DeleteNote(id - 1);
                    PrintNotesList();
                    break;
                case 3:
                    Console.Clear();
                    MainMenu();
                    break;
            }
        }
        #endregion

        #region User Methods
        internal void CheckAndCreateUser()
        {
            if(User.CurrentUserName == "")
            {
                User.Id--;
                CreateUser();
                ChooseUser(1);
                Console.Clear();
                Console.WriteLine($"Hello, {User.CurrentUserName}!");
            }
            else
                Console.WriteLine($"Hello, {User.CurrentUserName}!");
        }
        private void CreateUser()
        {
            Console.WriteLine("Hello! What's you name?");
            User user = new User (Console.ReadLine());
            if (users.Length < User.Id)
            {
                Array.Resize(ref users, User.Id);
            }
            users[User.Id - 1] = user;
        }
        private void ChooseUser(int id)
        {
            User.CurrentUserName = users[id - 1].Name;
        }
        private void PrintUsersList()
        {
            if (users.Length == 0)
                Console.WriteLine("Users list is empty.");
            else
            {
                string id = "ID";
                string name = "Name";
                string createdAt = "Created";
                Console.WriteLine($"{id,4}|{name,20}|{createdAt,20}");
                for (int i = 0; i < users.Length; i++)
                {
                    Console.WriteLine($"{users[i].UserId,4}|{users[i].Name,20}|{users[i].CreatedAt,20}");
                }
                Console.WriteLine($"Total: {users.Length}");
            }
        }
        #endregion
    }
}
