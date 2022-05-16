using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CSharp3
{
    // OOP(은닉성/상속성/다형성)
    class Player    // 부모 혹은 기반
    {
        static public int counter = 1;
        public int id;
        public int hp;
        public int attack;

        public Player()
        {
            Console.WriteLine("Player 생성자 호출!");
        }

        public Player(int hp)
        {
            this.hp = hp;
            Console.WriteLine("Player hp 생성자 호출!");
        }
    }

    class Mage : Player     // 자식 혹은 파생
    {
        
    }

    class Archer : Player
    {
        
    }


    // 참조(ref)
    class Knight : Player
    {
        static public void Test()
        {
            // static 아닌 this.hp, this.attack 변수에 접근 불가능.
            counter++;
        }

        static public Knight CreateKnight()
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 10;

            return knight;
        }

        int c;
        public Knight() : base(100)
        {
            // id = counter;
            // counter++;

            // hp = 100;
            // attack = 10;
            this.c = 10;
            base.hp = 100;
            Console.WriteLine("Knight 생성자 호출!");
        }

        // : this() - Knight() 먼저 호출 생성, attack이 10으로 세팅됨.
        public Knight(int hp) : this()
        {
            this.hp = hp;
            Console.WriteLine("int 생성자 호출!");
        }

        public Knight(int hp, int attack) : this(hp)
        {
            this.hp = hp;
            this.attack = attack;
            Console.WriteLine("int, int 생성자 호출!");
        }

        public Knight Clone()
        {
            Knight knight = new Knight();
            knight.hp = hp;
            knight.attack = attack;

            return knight;
        }

        public void Move()
        {

        }

        public void Attack()
        {

        }
    }

    // 복사
    struct stMage
    {
        public int hp;
        public int attack;
    }

    class Program
    {
        static void KillKnight(Knight knight)
        {
            knight.hp = 0;
        }

        static void KillMage(stMage mage)
        {
            mage.hp = 0;
        }

        static void Main(string[] args)
        {
            Knight knight = new Knight();
            knight.hp = 100;
            knight.attack = 10;
            // 클래스니까 ref로 넘기지 않아도 됨.
            // 클래스는 ref처럼 참조되기 때문에 함수에서 0으로 반영하면
            // main에서도 0으로 반영됨.
            KillKnight(knight);

            // 클래스는 =로 받으면 같은 주소를 가르키고 있음.
            Knight knight2 = knight.Clone();
            knight2.hp = 0;

            Knight knight3 = new Knight(50);

            Knight knight4 = Knight.CreateKnight(); // static
            knight4.Move(); // 일반

            // 구조체는 new 로 생성해도 되고 안해도 되고.
            stMage mage;
            mage.hp = 100;
            mage.attack = 10;
            // 복사 개념이라 함수에선 0으로 바뀌지만 main에선 100.
            KillMage(mage);

            // mage를 받았지만 별도로 복사해서 각각 다른 주소를 가르키고 있음.
            stMage mage2 = mage;
            mage2.hp = 0;
        }
    }
}
