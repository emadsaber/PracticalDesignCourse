using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Lab14_ObjectPool.Problem
{
    class NPC
    {
        public string Color { get; set; }
    }

    public class Client
    {
        private void Scene1()
        {
            Console.WriteLine("Scene 1 requires 50 NPCs");
            List<NPC> npcList = new List<NPC>();
            for (int index = 0; index < 50; ++index)
            {
                npcList.Add(new NPC());
            }
            Console.WriteLine($"Current NPCs count in scene 1 is {npcList.Count}");
            Console.WriteLine("Clear NPCs list after scene 1 to save memory...");
            npcList.Clear();
            Console.WriteLine($"Current NPCs count after scene 1 is {npcList.Count}");
            Console.WriteLine("----------------------------------------------------");
        }

        private void Scene2()
        {
            Console.WriteLine("Scene 2 requires another 100 NPCs");
            List<NPC> npcList = new List<NPC>();
            for (int index = 0; index < 100; ++index)
            {
                npcList.Add(new NPC());
            }
            Console.WriteLine($"Current NPCs count in scene 2 is {npcList.Count}");
            Console.WriteLine("Clear NPCs list after scene 2 to save memory...");
            npcList.Clear();
            Console.WriteLine($"Current NPCs count after scene 2 is {npcList.Count}");
            Console.WriteLine("----------------------------------------------------");
        }

        public void Test()
        {
            this.Scene1();
            this.Scene2();
        }
    }
}
