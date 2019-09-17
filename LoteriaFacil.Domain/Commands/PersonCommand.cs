using LoteriaFacil.Domain.Core.Commands;
using System;

namespace LoteriaFacil.Domain.Commands
{
    public abstract class PersonCommand : Command
    {
        public Guid Id { get; protected set; }

        public string Name { get; protected set; }

        public string Email { get; protected set; }

        public string Password { get; protected set; }

        public DateTime DtRegister { get; protected set; }

        public bool Active { get; protected set; }
    }
}
