using System;

namespace Tetris
{
    public class BlockQueue
    {
        private readonly Block[] blocks = new Block[]
        {
            new IBlock(),
            new JBlock(),
            new LBlock(),
            new OBlock(),
            new SBlock(),
            new TBlock(),
            new ZBlock()
        };

        private readonly Random random = new Random();

        public Block NextBlock { get; private set; }
        public Block Next2Block { get; private set; }
        public BlockQueue()
        {
            NextBlock = RandomBlock();
            Next2Block = RandomBlock();
        }

        private Block RandomBlock()
        {
            return blocks[random.Next(blocks.Length)];
        }

        public Block GetAndUpdate()
        {
            Block block = NextBlock;
            Block block2 = Next2Block;
            do
            {
                NextBlock = RandomBlock();
                Next2Block = RandomBlock();
            }
            while (block.Id == NextBlock.Id);

            return block;
        }
    }
}
