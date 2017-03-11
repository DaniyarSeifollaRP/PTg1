using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO; // для streamreader и для streamwriter и directery info 


namespace FarManager
{
    public class State
    {
        private int index;
        public int Index
        {
            get { return index; }
            set
            {
                int maxVal = Folder.GetDirectories().Length;
                if (value >= 0 && value < maxVal)
                {
                    index = value;
                }
            }
        }
        public DirectoryInfo Folder { get; set; }
    }
}




    class Program
    {
        static void ShowFolderContent(State state)
        {
            Console.Clear();
            DirectoryInfo[] list = state.Folder.GetDirectories(); //возвращает данные, которые расположены в текущей папке  
            for (int i = 0; i < list.Length; ++i) //пробегаемся 
            {
                if (state.Index == i) //если индекс равно i
                {
                    Console.BackgroundColor = ConsoleColor.White; //цвет фона
                    Console.ForegroundColor = ConsoleColor.Black; //цвет самого текста
                }
                Console.Write(list[i]);
                Console.BackgroundColor = ConsoleColor.Black;
                Console.ForegroundColor = ConsoleColor.White;
                Console.WriteLine(); // выводим на экран
            }

            foreach (FileInfo f in state.Folder.GetFiles()) //просмотриваем все файлы
            {
                Console.WriteLine(f.Name); // пишем файл и название
            }
        }

        static void Main(string[] args)
        {
            bool alive = true;  
            State state = new State { Folder = new DirectoryInfo(@"C:\") }; //создаем новый State, в которым мы создаем новый DirectoryInfo
            Stack<State> layers = new Stack<State>();
            layers.Push(state); // Push указывает папку, которая находится под индексом 0 // pusg - засосывает  в stack
            while (alive)
            {
                ShowFolderContent(layers.Peek()); // показывает , что внутри папки 
                ConsoleKeyInfo pressedKey = Console.ReadKey();
                switch (pressedKey.Key) // управление
                {
                    case ConsoleKey.UpArrow:
                        layers.Peek().Index--; // peek - просмтаривает
                        break;
                    case ConsoleKey.DownArrow:
                        layers.Peek().Index++; // 
                        break;
                    case ConsoleKey.Escape:
                        layers.Pop();  // удаляет 
                        break;
                    case ConsoleKey.Enter:
                        DirectoryInfo[] list = layers.Peek().Folder.GetDirectories(); // показывает , что внутри папки
                        State newState = new State
                        {
                            Folder = new DirectoryInfo(list[state.Index].FullName),
                            Index = 0
                        };
                        layers.Push(newState); // push добавляет
                        break;
                }

            }
        }
    }
}