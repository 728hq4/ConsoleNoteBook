using System;

namespace NoteBook
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Repo repo = new Repo();
            repo.Start();
            repo.Menu();
        }
    }
}
