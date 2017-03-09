using Cmas.Backend.Infrastructure.Domain.Commands;
using System;

namespace Cmas.Backend.Modules.Contracts.CommandsContexts
{
    public class DeleteContractCommandContext : ICommandContext
    {
        public String id;
    }
}
