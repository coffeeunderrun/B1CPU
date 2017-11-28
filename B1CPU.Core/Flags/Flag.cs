﻿namespace B1CPU.Core.Flags
{
    public class Flag : IFlag
    {
        public string Name { get; }

        public int Selector { get; }

        public Flag(string name, int selector = -1)
        {
            Name = name;
            Selector = selector;
        }
    }
}
