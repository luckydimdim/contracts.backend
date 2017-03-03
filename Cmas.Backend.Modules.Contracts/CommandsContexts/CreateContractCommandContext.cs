using Cmas.Backend.Infrastructure.Domain.Commands;
using System;

namespace Cmas.Backend.Modules.Contracts.CommandsContexts
{
    public class CreateContractCommandContext : ICommandContext
    {
        public String id;
        public String Name;
        public String Number;
        public String StartDate;
        public String FinishDate;
        public String ContractorName;
        public String Currency;
        public String Amount;
        public bool VatIncluded;
        public String ConstructionObjectName;
        public String ConstructionObjectTitleName;
        public String ConstructionObjectTitleCode;
        public String Description;
    }
}
