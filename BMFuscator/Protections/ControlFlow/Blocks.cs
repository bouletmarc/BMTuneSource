using dnlib.DotNet.Emit;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Krawk_Protector.Protections.ControlFlow
{
    public class Block
    {
        public int ID = 0;
        public int nextBlock = 0;
        public List<Instruction> instructions = new List<Instruction>();
    }
    public class Blocks
    {
        public List<Block> blocks = new List<Block>();
        private static Random generator = new Random();
        public Block getBlock(int id)
        {
            return blocks.Single(block => block.ID == id);
        }

        public void Scramble(out Blocks incGroups)
        {
            Blocks groups = new Blocks();
            foreach (var group in blocks)
                groups.blocks.Insert(generator.Next(0, groups.blocks.Count), group);
            incGroups = groups;
        }

    }
}
