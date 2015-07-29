using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Maer.Infrastructure.Querying
{
    public static class NameQueryFactory
    {
        public static Query FindUserByName(string name)
        {
            IList<Criterion> criteria = new List<Criterion>();
            criteria.Add(new Criterion("UserName", name, CriteriaOperator.NotApplicable));

            return new Query(QueryName.FindUserByName, null, criteria);
        }
    }
}
