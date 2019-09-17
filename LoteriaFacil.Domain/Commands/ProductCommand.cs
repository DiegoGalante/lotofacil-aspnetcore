using System;
using LoteriaFacil.Domain.Core.Commands;

namespace LoteriaFacil.Domain.Commands
{
    public abstract class ProductCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

    }
}
