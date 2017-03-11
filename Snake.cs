using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;
namespace MySnake.Model
{
    [Serializable]
    public class Snake : Drawer
    {
        public Snake(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body) { }

        public void Move(int dx, int dy)
        {
            for (int i = body.Count - 1; i > 0; i--)
            {
                body[i].x = body[i - 1].x;
                body[i].y = body[i - 1].y;
            }

            body[0].x += dx;
            body[0].y += dy;

            HitInWall(Game.wall.body );

            while (HitinSnake())
            {
                Game.GameOver = true;
                Console.SetCursorPosition(60, 30);
                Console.Clear();
                Console.Write("GameOver");
                Console.ReadKey();
            

            }
            
           

            
            
            // TODO: check for collision with border (console border (maximum width and height))
            // TODO: if necessary, load new level of the wall
        }

        public bool CanEat(Food f)
        {
            if (body[0].x == f.body[0].x && body[0].y == f.body[0].y)
            {
                body.Add(new Point(f.body[0].x, f.body[0].y));
                return true;
            }
            return false;
        }

        public void HitInWall(List<Point> Q)
        {
            foreach(Point p in Q)
            {
                if(body[0].x == p.x && body[0].y == p.y)
                {
                    Game.GameOver = true;
                    Console.SetCursorPosition(60, 30);
                    Console.Clear();
                    Console.Write("GameOver");
                    Console.ReadKey();
                   
                }
            }
        }

        public bool HitinSnake()
        {
            for (int i = 1; i < body.Count; i++)
            {
                if (body[0].x == body[i].x && body[0].y == body[i].y)
                    return true;
            }
            return false;
        }
    }
}
