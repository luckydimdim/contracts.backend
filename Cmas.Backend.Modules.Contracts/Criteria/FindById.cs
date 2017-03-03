using Cmas.Backend.Infrastructure.Domain.Criteria;
using System;
using System.Collections.Generic;
using System.Text;

namespace Cmas.Backend.Modules.Contracts.Criteria
{
    public class FindById : ICriterion
    {
        public string Id { get; set; }
    }
}
