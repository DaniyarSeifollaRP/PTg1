using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
using System.IO;

namespace MySnake.Model
{
    [Serializable]
    public class Drawer
    {
        public ConsoleColor color;
        public int x, y;
        public List<Point> body = new List<Point>();
        public char sign;

        public Drawer() { }

        public Drawer(ConsoleColor color, char sign, List<Point> body)
        {
            this.body = body;
            this.color = color;
            this.sign = sign;
        }

        public void Draw()
        {
            Console.ForegroundColor = color;
            foreach (Point p in body)
             {
                Console.SetCursorPosition(p.x, p.y);
                Console.Write(sign);
            }
        }

        public void Create()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Type t = this.GetType();
            FileStream fs = new FileStream(String.Format(@"{0}.cer", t.Name), FileMode.OpenOrCreate, FileAccess.Write);
            bf.Serialize(fs, this);
            fs.Close();
        }

        public void Resume()
        {
            BinaryFormatter bf = new BinaryFormatter();
            Type t = this.GetType();
            FileStream fs = new FileStream(String.Format(@"{0}.cer", t.Name), FileMode.Open, FileAccess.Read);

            if (t == typeof(Wall))
            {
                Game.wall = bf.Deserialize(fs) as Wall;

            }
            else if (t == typeof(Food))
            {
                Game.food = bf.Deserialize(fs) as Food;
            }
            else if (t == typeof(Snake))
            {

                Game.snake = bf.Deserialize(fs) as Snake;
            }
            fs.Close();



        
        }
    }
}
