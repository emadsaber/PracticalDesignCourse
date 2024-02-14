namespace Lab20_Flyweight.Solution
{
    public class FullSprite
    {
        public string Color { get; set; }
        public byte[] Sprite { get; set; }

        internal static byte[] FromPath(string path)
        {
            return File.ReadAllBytes(path);
        }
    }

    public class MovingParticle
    {
        public FullSprite FullSprite { get; set; }
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }

        public void Move()
        {
            Console.WriteLine($"Moving to Point ({X}, {Y}) with speed ({Speed})");
        }

        public void Draw()
        {
            Console.WriteLine($"Started Drawing Particle at Point ({X}, {Y}) with Color {FullSprite.Color}");
        }
    }

    public class Game
    {
        public Game()
        {
            Sprites = new HashSet<Tuple<string, FullSprite>>();
            MovingParticles = new List<MovingParticle>();
        }

        public HashSet<Tuple<string, FullSprite>> Sprites { get; set; }
        public List<MovingParticle> MovingParticles { get; set; }

        public string GetHashKey(string color, string path) => $"{color}_{path}";

        public void AddParticle(int x, int y, int speed, string color, string path)
        {
            //check if the item exists in the cache (flyweight)
            var key = GetHashKey(color, path);
            FullSprite fsprite;
            if (!Sprites.Any(x => x.Item1 == key))
            {
                fsprite = new FullSprite { Color = color, Sprite = FullSprite.FromPath(path) };
                Sprites.Add(new Tuple<string, FullSprite>(key,fsprite));
            }else{
                fsprite = Sprites.First(x => x.Item1 == key).Item2;
            }

            MovingParticles.Add(
                new MovingParticle
                {
                    X = x,
                    Speed = speed,
                    Y = y, 
                    FullSprite = fsprite
                }
            );
        }

        public void Draw()
        {
            foreach (var p in MovingParticles)
            {
                p.Draw();
            }
        }
    }

    public class Application
    {
        public void StartGame()
        {
            var game = new Game();
            for (int i = 0; i < 300_000; i++) //WARNING : THIS WILL CONSUME 32 MB OF MEMORY
            {
                game.AddParticle(x: i, y: i + i, speed: 10, color: "red", path: "Images\\sprite_red.png");
            }

            game.Draw();
            Console.Write("[Press any key to quit...]");
            Console.ReadLine();
        }
    }
}
