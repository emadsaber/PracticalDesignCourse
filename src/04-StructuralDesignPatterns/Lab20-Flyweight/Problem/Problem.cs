namespace Lab20_Flyweight.Problem
{
    public class Particle
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Speed { get; set; }
        public string Color { get; set; }
        public byte[] Sprite { get; set; }
        
        public void Move()
        {
            Console.WriteLine($"Moving to Point ({X}, {Y}) with speed ({Speed})");
        }

        public void Draw()
        {
            Console.WriteLine($"Started Drawing Particle at Point ({X}, {Y}) with Color {Color}");
        }

        internal static byte[] FromPath(string path)
        {
            return File.ReadAllBytes(path);
        }
    }

    public class Game
    {
        public Game()
        {
            Particles = new List<Particle>();   
        }
        public List<Particle> Particles { get; set; }

        public void AddParticle(Particle p){
            Particles.Add(p);
        }

        public void Draw(){
            foreach(var p in Particles){
                p.Draw();
            }
        }
    }

    public class Application{
        public void StartGame(){
            var game = new Game();
            for (int i = 0; i < 300_000; i++) //THIS WILL CONSUME 6GB OF MEMORY :D
            {
                var p = new Particle(){
                    Color = "red",
                    Speed = 10,
                    X = i,
                    Y = i + i,
                    Sprite = Particle.FromPath("Images\\sprite_red.png")
                };

                game.AddParticle(p);
            }

            game.Draw();
            Console.Write("[Press any key to quit...]");
            Console.ReadLine();
        }
    }
}
