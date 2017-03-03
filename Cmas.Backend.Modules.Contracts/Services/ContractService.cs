using Cmas.Backend.Infrastructure.Domain.Commands;
using Cmas.Backend.Infrastructure.Domain.Queries;
using Cmas.Backend.Modules.Contracts.CommandsContexts;
using Cmas.Backend.Modules.Contracts.Criteria;
using Cmas.Backend.Modules.Contracts.Entities;
using Cmas.Backend.Modules.Contracts.Forms;
using System.Threading.Tasks;

namespace Cmas.Backend.Modules.Contracts.Services
{
    public class ContractService
    {
        private readonly ICommandBuilder _commandBuilder;
        private readonly IQueryBuilder _queryBuilder;

        public ContractService(ICommandBuilder commandBuilder, IQueryBuilder queryBuilder)
        {
            _commandBuilder = commandBuilder;
            _queryBuilder = queryBuilder;
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

        public Contract GetContract(string id)
        {

            Contract result = _queryBuilder.For<Contract>().With(new FindById { Id ="1" });

            return result;
        }


    }
}
