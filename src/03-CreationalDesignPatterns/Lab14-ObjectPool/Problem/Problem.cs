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

    public class Problem
    {
        public void Test1()
        {
            //Initialize 50 NPCs
            var npcs = new List<NPC>();
            for (var i = 0; i < 50; i++)
            {
                npcs.Add(new NPC()); //new object creation is slow, every time the method is executed time is wasted
            }
        }
    }
}
