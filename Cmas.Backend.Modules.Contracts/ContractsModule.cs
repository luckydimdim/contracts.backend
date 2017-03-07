using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Infrastructure.Domain.Queries;
using Cmas.Backend.Modules.Contracts.Forms;
using Cmas.Backend.Modules.Contracts.Services;
using Nancy;
using Nancy.ModelBinding;

namespace Cmas.Backend.Modules.Contracts
{
    public class ContractsModule : NancyModule
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly IQueryBuilder _queryBuilder;
        private readonly ContractService _contractService;

        public ContractsModule(ICommandBuilder commandBuilder, IQueryBuilder queryBuilder) : base("/contracts")
        {
            _commandBuilder = commandBuilder;
            _queryBuilder = queryBuilder;
            _contractService = new ContractService(_commandBuilder, _queryBuilder);


            Get("/", _ => {
                return _contractService.GetContracts();
            });


            Get("/{id}", async args => await _contractService.GetContract(args.id));

            
            Post("/", async (args, ct) =>
            {
                CreateContractForm form = this.Bind();

               var result = await _contractService.CreateContract(form);

                return result.ToString();
            });

            Put("/{id}", async (args, ct) =>
            {
                UpdateContractForm form = this.Bind();


                var result = await _contractService.UpdateContract(args.id, form);

                return result.ToString();
            });
        }
 
    }
}
