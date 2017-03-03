using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Forms;
using System.Threading.Tasks;

namespace Cmas.Backend.Modules.Contracts.Services
{
    public class ContractService
    {
        private readonly ICommandBuilder _commandBuilder;

        public ContractService(ICommandBuilder commandBuilder)
        {
            _commandBuilder = commandBuilder;
        }


       public async Task<int> CreateContract(CreateContractForm form)
        {
            var context = new CreateContractCommandContext
            {
                Name = form.Name,
                Number = form.Number,
                StartDate = form.StartDate,
                FinishDate = form.FinishDate,
                ContractorName = form.ContractorName,
                Currency = form.Currency,
                Amount = form.Amount,
                VatIncluded = form.VatIncluded,
                ConstructionObjectName = form.ConstructionObjectName,
                ConstructionObjectTitleName = form.ConstructionObjectTitleName,
                ConstructionObjectTitleCode = form.ConstructionObjectTitleCode,
                Description = form.Description
            };

            context = await _commandBuilder.Execute(context);

            return context.id;
        }
    }
}
