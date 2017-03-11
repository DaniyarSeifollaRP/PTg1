using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization.Formatters.Binary;

namespace MySnake.Model
{
    [Serializable]
    public class Food : Drawer
    {

        public Food(ConsoleColor color, char sign, List<Point> body) : base(color, sign, body)
        {
            SetRandomPosition();
        }

        public  void SetRandomPosition()
        {
            int x = new Random().Next(1, 70);
            int y = new Random().Next(1, 35);
            body[0] = new Point(x, y);
            while ( foodinwall(Game.wall.body) || foodInSnake( Game.snake.body) )
            {
                x = new Random().Next(1, 70);
                y = new Random().Next(1, 35);
            }
            

         /*   if (Game.snake.CanEat(Game.food))
            {
                Game.food.SetRandomPosition();
            }
            if (Game.snake.body.Count == 4)
            {
                Game.wall.LoadLevel(2);
            }
            */
        }
        public bool foodInSnake(List<Point> s) 
        {
            foreach (Point p in s)
            {
                if (body[0].x == p.x && p.y == body[0].y)
                {
                    return true;
                }
            }
            return false;
        }
        public bool foodinwall(List<Point> w) 
        {
            foreach (Point p in w)
            {
                if (body[0].x == p.x & body[0].y == p.y)
                {
                    return true;
                    
                }
            }
            return false;
        }
       
       
    }
}