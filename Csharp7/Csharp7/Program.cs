using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Csharp7
{
    public enum ClassType
    {
        Knight,
        Archer,
        Mage
    }

    public class Player
    {
        public ClassType ClassType { get; set; }
        public int Level { get; set; }
        public int Hp { get; set; }
        public int Attack { get; set; }
        public List<int> items { get; set; } = new List<int>();
    }

    class Program
    {
        static List<Player> _players = new List<Player>();

        // LINQ
        static void Main(string[] args)
        {
            Random rand = new Random();

            for (int i = 0; i < 100; i++)
            {
                ClassType type = ClassType.Knight;
                
                switch (rand.Next(0, 3))
                {
                    case 0:
                        type = ClassType.Knight;
                        break;
                    case 1:
                        type = ClassType.Archer;
                        break;
                    case 2:
                        type = ClassType.Mage;
                        break;
                }

                Player player = new Player()
                {
                    ClassType = type,
                    Level = rand.Next(1, 100),
                    Hp = rand.Next(100, 1000),
                    Attack = rand.Next(5, 50)
                };

                for (int j = 0; j < 5; j++)
                {
                    player.items.Add(rand.Next(1, 101));
                }

                _players.Add(player);
            }

            // 일반 버전
            {
                // 레벨이 50이상인 Knight만 추려서 레벨을 낮음->높음 순으로 정렬
                List<Player> players = GetHighLevelKnights();

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Level} {p.Hp}");
                }
            }

            // LINQ 버전
            {
                var players =
                    from p in _players
                    where p.ClassType == ClassType.Knight && p.Level >= 50
                    orderby p.Level ascending
                    select p;
                    // select new { Hp = p.Hp, Level = p.Level * 2 };

                foreach (Player p in players)
                {
                    Console.WriteLine($"{p.Level} {p.Hp}");
                }
            }

            // 중첩 from
            // ex) 모든 아이템 목록 추출
            {
                var playerItems = from p in _players
                                  from i in p.items
                                  where i < 30
                                  select new { p, i };

                var li = playerItems.ToList();
            }

            // grouping
            {
                var playersByLevel = from p in _players
                                     group p by p.Level into g
                                     orderby g.Key
                                     select new { g.Key, Players = g };
            }

            // join (내부 조인)
            // outer njoin (외부 조인)
            {
                List<int> levels = new List<int>() { 1, 5, 10 };

                var playerLevels =
                    from p in _players
                    join l in levels
                    on p.Level equals l
                    select p;
            }

            // LINQ 표준 연산자
            {
                var players =
                    from p in _players
                    where p.ClassType == ClassType.Knight && p.Level >= 50
                    orderby p.Level ascending
                    select p;

                var players2 = _players
                    .Where(p => p.ClassType == ClassType.Knight && p.Level >= 50)
                    .OrderBy(p => p.Level)
                    .Select(p => p);
            }
            
            
        }

        public static List<Player> GetHighLevelKnights()
        {
            List<Player> players = new List<Player>();

            foreach (Player player in _players)
            {
                if (player.ClassType != ClassType.Knight)
                    continue;
                if (player.Level < 50)
                    continue;

                players.Add(player);
            }

            players.Sort((lhs, rhs) => { return lhs.Level - rhs.Level; });

            return players;
        }
    }
}
