using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Modules.Contracts.Forms;
using Cmas.Backend.Modules.Contracts.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Cmas.Backend.Modules.Contracts
{
    public class ContractsModule : NancyModule
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly ContractService _contractService;

        public ContractsModule(ICommandBuilder commandBuilder) : base("/contracts")
        {
            _commandBuilder = commandBuilder;
            _contractService = new ContractService(_commandBuilder);


            Get("/", _ => {
                return "contracts";
            });
            Get("/{id}", _ => "get contract");


            Post("/", async (args, ct) =>
            {
                CreateContractForm form = this.Bind();

               int result = await _contractService.CreateContract(form);

                return result.ToString();
            });
        }
 
    }
}
