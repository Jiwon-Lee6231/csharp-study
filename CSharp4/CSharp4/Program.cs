using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp4
{
    // OOP(은닉성/상속성/다형성)
    class Player
    {
        protected int hp;
        protected int attack;

        public virtual void Move()
        {
            Console.WriteLine("Player 이동!");
        }
    }

    class Knight : Player
    {
        public sealed override void Move()
        {
            base.Move();

            Console.WriteLine("Knight 이동!");
        }
    }

    class Mage : Player
    {
        public int mp;

        public override void Move()
        {
            Console.WriteLine("Mage 이동!");
        }
    }


    class Program
    {
        static Player FindPlayerById(int id)
        {
            // id가 있는지 탐색

            return null;
        }

        static void EnterGame(Player player)
        {
            player.Move();

            Mage mage = (player as Mage);
            
            if (mage != null)
            {
                mage.mp = 10;
                mage.Move();
            }
        }
        
        static void Main(string[] args)
        {
            Knight knight = new Knight();
            Mage mage = new Mage();

            knight.Move();
            mage.Move();

            EnterGame(knight);
        }
    }
}
