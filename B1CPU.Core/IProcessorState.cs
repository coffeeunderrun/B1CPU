using System;
using System.Collections.Generic;

namespace B1CPU.Core
{
    public interface IProcessorState
    {
        IList<byte> Registers { get; }

        byte Flags { get; set; }

        ushort ProgramCounter { get; set; }

        ushort StackPointer { get; set; }

        ushort DestinationIndex { get; set; }

        ushort SourceIndex { get; set; }

        Func<ushort, byte> Read { get; }

        Action<ushort, byte> Write { get; }
    }
}