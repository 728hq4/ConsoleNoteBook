using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SkillBox
{
    internal class Repo
    {
        internal User user = new User();
        internal User[] users = new User[0]; 
        private Note[] notes = new Note[0];

        #region Notes Methods
        internal void PrintNotesList()
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
        internal void AddNote()
        {
            Console.WriteLine("Enter the summary");
            string sum = Console.ReadLine();
            Console.WriteLine("Enter the note");
            string text = Console.ReadLine();
            
            Note note = new Note(sum, text);
            Note.id++;
            if(notes.Length < Note.id)
            {
                Array.Resize(ref notes, Note.id * 2);
            }
            notes[Note.id] = note;
        }
        internal void MainMenu()
        {
            Console.WriteLine("1 - Notes\n2 - Users");
            byte action = Convert.ToByte(Console.ReadLine());
            switch (action)
            {
                case 1:
                    PrintNotesList();
                    DetailNoteMenu();
                    break;
                case 2:
                    break;
                default:
                    break;
            }
        }
        internal void DetailNoteMenu()
        {
            Console.WriteLine("1 - Open a note\n2 - Add a note\n3 - Return");
            byte action = Convert.ToByte(Console.ReadLine());
            switch (action)
            {
                case 1:
                    Console.WriteLine("Enter the note ID");
                    int id = Convert.ToInt32(Console.ReadLine());
                    notes[id+1].PrintNote();
                    Console.WriteLine("1 - Edit\n2 - Delete\n3 - Return");
                    byte action1 = Convert.ToByte(Console.ReadLine());
                    switch (action1)
                    {
                        case 1:
                            notes[id+1].EditNote();
                            break;
                        case 2:
                            notes[id+1].DeleteNote();
                            break;
                        case 3:
                            break;
                    }
                    break;
                case 2:
                    AddNote();
                    break;
                default:
                    break;
            }
            //main menu call
        }
        #endregion
    }
}
