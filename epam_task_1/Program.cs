using System;
using System.Collections.Generic;
using System.Threading;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace epam_task_1
{
    class Hero : IStats
    {
        public string HeroName { get; set; }
        public Origin HeroOrigin { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
        public string HeroStory { get; set; }
        public string HeroNature { get; set; }
        public string GoodEnding { get; set; }
        public string BadEnding { get; set; }
    }

    class Nomad : Hero
    {
        public Nomad(Origin heroOrigin, string heroName)
        {
            HeroNature = "thug";
            HeroName = heroName;
            Strength = 5;
            Dexterity = 8;
            Endurance = 5;
            HeroOrigin = heroOrigin;
            HeroStory = String.Format("...{0} was born in a family of rogues from far {1}, a family that made its living by stealing and deception. However, when the boy could barely walk, a terrible disaster called black plague came to his lands, claiming lives of his parents. Left alone, he was raised by savage rules of the street, making him a malicious and feral person. Many years have passed and {0} decided to change his life once and for ever....", HeroName, HeroOrigin);
            GoodEnding = String.Format("...With the help of his knife, {0} finally took a single precies hit into heart of the beast. Exhausted, {0} fell on his knees. It was a difficult battle, but our hero proved that he was the most dreadful dweller of that region. {0} collected his trophy and moved to the nearest city to sell it out and pour his empty soul with wine and lust....", HeroName);
            BadEnding = String.Format("...In the midst of the battle, our hero lunged on the beast and stabbed it to its stomach. However, the beast turned to be more agile and evaded the hit. Kickback was fatal. The story of {0} ended that night. But noone cried, as he was a dreadful {1}....", heroName, HeroNature);
        }
    }

    class Esquire : Hero
    {
        public Esquire(Origin heroOrigin, string heroName)
        {
            HeroNature = "gentleman";
            HeroName = heroName;
            Strength = 7;
            Dexterity = 4;
            Endurance = 7;
            HeroOrigin = heroOrigin;
            HeroStory = String.Format("...{0} was born in a rich family of noble people from far {1}. From his early ages, the boy was shrouded with care and prosperity, which made him arrogant and lonely. However, throughout the years, adventures and troubles quickly became his second nature. As soon as {0} was taught foreign languages, he left his family castle and went abroad, seeking for new friends and eternal glory....", HeroName, HeroOrigin);
            GoodEnding = String.Format("...Being a person of great savvy, {0} quickly remarked a pattern, which the beast was using to attack our hero. With the help of his sword, he sliced neck of the monster when it was exposed to his hit. As a result, massive body fell without its head and our hero collected it. Years passed and {0} became one of the most influential people of the old world. Those who opposed him, quickly tailed off on a single sight of his horrific trophy....", HeroName);
            BadEnding = String.Format("...Even though {0} was good at melee combat, the enemy turned to be tougher. When remaining stamina left our hero, his heart refused to work. As a result, {0} dropped dead. Tragic as it is, this was the end of an arrogant {1}....", heroName, HeroNature);
        }
    }

    class Knight : Hero
    {
        public Knight(Origin heroOrigin, string heroName)
        {
            HeroNature = "warchief";
            HeroName = heroName;
            Strength = 8;
            Dexterity = 4;
            Endurance = 6;
            HeroOrigin = heroOrigin;
            HeroStory = String.Format("...{0} was born in a family of a military commander from {1}. Instead of teaching their child in normal school, his parents sent him to a secluded military academy. Subordination and devotion to his family sigil quickly became his creed. However, during his first battle experience, {0} suffered heavy loss. In order to return favour of his parents, {0} decided to become wonderer and return his honor through nummerous battles....", HeroName, HeroOrigin);
            GoodEnding = String.Format("...{0} was hardened by numerous battles, therefore, he knew how to defeat even the strongest opponent. Defending his body with a massive shield, {0} deflected attacks of the enemy one by one, unless his opopent was left without his strength. Counter attack of our hero was fearsome. With a series of heavy blows, {0} riddled body of the monster. Without a single word, our hero took off the beast's head and took it home. Questions about honor were never raised again....", HeroName);
            BadEnding = String.Format("...Despite the fact that {0} was a true veteran, he did not predict this battle. With every hit, heavy weight of his armor took big chunk of remaining strength. The final strike of the monster broke his shield into pieces, and once left without protection, {0} became exposed to a fatal blow. The story of exemplar {1} ended that night....", heroName, HeroNature);
        }
    }

    enum Origin
    {
        South, North, East
    }

    interface IStats
    {
        int Strength { get; set; }
        int Dexterity { get; set; }
        int Endurance { get; set; }
    }

    abstract class Path
    {
        public abstract string PathStory { get; set; }
        public abstract Hero Hero { get; set; }
        public abstract string EffectOfPath { get; set; }
    }

    class Mountains : Path
    {
        public Mountains(Hero hero)
        {
            Hero = hero;
        }
        public override Hero Hero { get; set; }
        public override string PathStory
        {
            get
            {
                return String.Format("...Apart from other adventures of our hero, this particular story happened when {0} decided to go to the Northern Mountains. Even though our hero was warned about ghastly creatures that lurked on the frigid lands of the Northern Mountains, {0} joined an expedition of brave men and went to the very heart of the Mountains to prove that he was worthy of a title of a {1}. During the first night of his quest, our hero heard a terrible scream and woke up. He realized that the whole crew was missing. Torn clothes and sheathed weapons were left on the ground. Suddenly, {0} heard a strange sound. He realized that he was not alone....", Hero.HeroName, Hero.HeroNature);
            }

            set
            {
                PathStory = value;
            }
        }

        public override string EffectOfPath
        {
            get
            {
                if (Hero.HeroOrigin == Origin.North)
                {
                    Hero.Strength += 2;
                    Hero.Dexterity += 2;
                    Hero.Endurance += 2;
                    return "...Thanks to the fact that our hero was born in the chilly outskirts of the Northern Kingdom, he was more than ready to face his opponent....";
                }
                else
                {
                    return "...Unfortunately, skin and soul of our hero were not hardened by cold wind and harsh climate. He was not prepared to face what was waiting for him....";
                }
            }

            set
            {
                EffectOfPath = value;
            }
        }
    }

    class Swamp : Path
    {
        public Swamp(Hero hero)
        {
            Hero = hero;
        }
        public override Hero Hero { get; set; }
        public override string PathStory
        {
            get
            {
                return String.Format("...Even though {0} had many interesting situations during his advantures, the most curious one happened when he decided to gain rare trophies from the Southern Swamps. Many wanderers were buried under the gloomy waters of that place, however the restless nature of {1} took over clear reason of our hero. Without a single doubt, he joined a troop of elite soldiers who were appointed to scout the vivid territories of the Southern Swamp. During the first day of their mission, strange illness defeated the whole platoon, unless {0} was left alone. It did not stop our hero and very soon he discovered a strange temple. Inside, he regretted of his curiosity....", Hero.HeroName, Hero.HeroNature);
            }

            set
            {
                PathStory = value;
            }
        }

        public override string EffectOfPath
        {
            get
            {
                if (Hero.HeroOrigin == Origin.South)
                {
                    Hero.Strength += 2;
                    Hero.Dexterity += 2;
                    Hero.Endurance += 2;
                    return "...Thanks to the fact that our hero was born in the humid outskirts of the Southern Kingdom, he was more than ready to face his opponent....";
                }
                else
                {
                    return "...Unfortunately, skin and soul of our hero were not hardened by madid wind and damp climate. He was not prepared to face what was waiting for him....";
                }
            }

            set
            {
                EffectOfPath = value;
            }
        }
    }

    class Desert : Path
    {
        public Desert(Hero hero)
        {
            Hero = hero;
        }
        public override Hero Hero { get; set; }
        public override string PathStory
        {
            get
            {
                return String.Format("...This strange situation happened to {0} when he decided to tempt his fate in the Eastern Desert. For many years this territory remained secluded from the outer world. Numerous rumors were told about that place, while downfall of caravans due to harsh climate was the most innoxious of them. Nonetheless, {1} took over reason of our hero. Recklessly, but with sharp-cut intentions, {0} joined an experimental caravan that was going to set up diplomatic relations with local dwellers. Suddenly, during the first night of their expedition, caravan members took their horses and ran away, leaving {0} on his own. Without a single clue about such a strange conduct, our hero was starting to pack his equipment, when suddenly he noticed a shadow that repulsed from his torch....", Hero.HeroName, Hero.HeroNature);
            }

            set
            {
                PathStory = value;
            }
        }

        public override string EffectOfPath
        {
            get
            {
                if (Hero.HeroOrigin == Origin.East)
                {
                    Hero.Strength += 2;
                    Hero.Dexterity += 2;
                    Hero.Endurance += 2;
                    return "...Thanks to the fact that our hero was born in the torrid outskirts of the Eastern Kingdom, he was more than ready to face his opponent....";
                }
                else
                {
                    return "...Unfortunately, skin and soul of our hero were not hardened by dusty wind and ferwend climate. He was not prepared to face what was waiting for him....";
                }
            }

            set
            {
                EffectOfPath = value;
            }
        }
    }

    abstract class Enemy : IStats
    {
        public abstract string EnemyName { get; set; }
        public abstract string EnemyStory { get; set; }
        public int Strength { get; set; }
        public int Dexterity { get; set; }
        public int Endurance { get; set; }
    }

    class Troll : Enemy
    {
        public Troll()
        {
            EnemyName = "Troll";
            Strength = 8;
            Dexterity = 5;
            Endurance = 7;
        }
        public override string EnemyName { get; set; }
        public override string EnemyStory
        {
            get
            {
                return "...Disgusting stink filled his lungs. A strange and massive creature dragged a blunt trunk and pointed it at our hero. Soon, it became obvious that a giant troll was standing in front of him....";
            }

            set
            {
                EnemyStory = value;
            }
        }
    }

    class Dragon : Enemy
    {
        public Dragon()
        {
            EnemyName = "Troll";
            Strength = 6;
            Dexterity = 7;
            Endurance = 7;
        }
        public override string EnemyName { get; set; }
        public override string EnemyStory
        {
            get
            {
                return "...Violent heat got through the bones of our hero. Sulfur smell in the air gave him a clue. Without a single doubt, it was a dragon. Formidable size of the beast could lead to heart attack of the most veteran soldier. However, our hero was not a timid person....";
            }

            set
            {
                EnemyStory = value;
            }
        }
    }

    class Minotaurus : Enemy
    {
        public Minotaurus()
        {
            EnemyName = "Troll";
            Strength = 8;
            Dexterity = 8;
            Endurance = 4;
        }
        public override string EnemyName { get; set; }
        public override string EnemyStory
        {
            get
            {
                return "...Heavy breathing sounded next to the hero. Hoping to remain undetected, our hero stood still. Unfortunately, after our hero heard a harrowing roar, he understood that he had to confront his enemy. Massive horns, muzzle vile and hooves of terrifying size proved the worst. It was a minotaurus....";
            }

            set
            {
                EnemyStory = value;
            }
        }
    }

    class Program
    {
        public static bool BattleTheCreature(Hero hero, Enemy enemy, string stat)
        {
            bool heroWins = false;
            switch(stat)
            {
                case "s":
                    heroWins = HeroWins(hero.Strength, enemy.Strength);
                    break;
                case "d":
                    heroWins = HeroWins(hero.Dexterity, enemy.Dexterity);
                    break;
                default:
                    heroWins = HeroWins(hero.Endurance, enemy.Endurance);
                    break;
            }
            return heroWins;
        }

        public static bool HeroWins(int heroStat, int enemyStat)
        {
            Random rnd = new Random();
            int heroResult = rnd.Next(0, heroStat);
            int enemyResult = rnd.Next(0, enemyStat);
            return heroResult >= enemyResult;
        }

        static void Main(string[] args)
        {
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("Enter your name");
            string name = Console.ReadLine().ToString();
            Thread.Sleep(1000);
            Console.WriteLine("Select place of your birth. Press 'n' for North, 's' for South or 'e' for East.");
            string origin = Console.ReadLine().ToString();
            Origin selectedOrigin;
            switch(origin)
            {
                case "n":
                    selectedOrigin = Origin.North;
                    break;
                case "s":
                    selectedOrigin = Origin.South;
                    break;
                default:
                    selectedOrigin = Origin.East;
                    break;
            }
            Thread.Sleep(1000);
            Console.WriteLine("Select your story. Press 'n' for Nomad, 'e' for Esquire or 'k' for Knight.");
            string story = Console.ReadLine().ToString();
            Hero hero;
            switch (story)
            {
                case "n":
                    hero = new Nomad(selectedOrigin, name);
                    break;
                case "e":
                    hero = new Esquire(selectedOrigin, name);
                    break;
                default:
                    hero = new Knight(selectedOrigin, name);
                    break;
            }
            Random rnd = new Random();
            List<Path> paths = new List<Path>() { new Mountains(hero), new Desert(hero), new Swamp(hero) };
            int pathIndex = rnd.Next(0, 3);
            Path heroPath = paths[pathIndex];
            Console.WriteLine("_________________________________________________________________________________________________________________");
            Thread.Sleep(1000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("...This story happened long time ago. In fact, it is so ancient, that its narrator lived even before Julius Caesar ascended the throne of the mighty Roman Empire....");
            Thread.Sleep(5000);
            Console.WriteLine("...The story, invented as it is, tells us about adventures of {0}, who was a {1} by his nature....", hero.HeroName, hero.HeroNature);
            Thread.Sleep(5000);
            Console.WriteLine(hero.HeroStory);
            Thread.Sleep(20000);
            Console.WriteLine(heroPath.PathStory);
            Thread.Sleep(20000);
            Console.WriteLine(heroPath.EffectOfPath);
            Thread.Sleep(4000);
            List<Enemy> enemies = new List<Enemy>() { new Troll(), new Dragon(), new Minotaurus() };
            int enemyIndex = rnd.Next(0, 3);
            Enemy enemy = enemies[enemyIndex];
            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("_________________________________________________________________________________________________________________");
            Console.WriteLine(enemy.EnemyStory);
            Thread.Sleep(7000);
            Console.WriteLine("In order to fight the creature, you should select one of three basic stats and throw a dice. Press 's' for Strength, 'd' for Dexterity and 'e' for Endurance");
            string stat = Console.ReadLine().ToString();
            Thread.Sleep(5000);
            Console.WriteLine("So be it!");
            Thread.Sleep(1000);
            bool heroWins = BattleTheCreature(hero, enemy, stat);
            if (heroWins)
            {
                Console.WriteLine("Good job, you know how to throw a dice!");
            }
            else
            {
                Console.WriteLine("Oh no, you failed!");
            }
            Console.WriteLine("_________________________________________________________________________________________________________________");
            Thread.Sleep(3000);
            Console.ForegroundColor = ConsoleColor.Cyan;
            if (heroWins)
            {
                Console.WriteLine(hero.GoodEnding);
            }
            else
            {
                Console.WriteLine(hero.BadEnding);
            }
            Thread.Sleep(10000);
            Console.WriteLine("...The End...");
        }
    }
}
