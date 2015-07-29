using System;
using System.Collections.Generic;

namespace Maer.Infrastructure.Querying
{
    public class Query
    {
        private QueryName _name;
        private IList<Query> _subQueries = new List<Query>();
        private IList<Criterion> _criteria = new List<Criterion>();
        private IList<OrderByClause> _orderByClauses = new List<OrderByClause>();

        public Query()
           : this(QueryName.Dynamic, new List<Query>(), new List<Criterion>())
        { }

        public Query(QueryName name, IList<Query> subQueries, IList<Criterion> criteria) 
        {
            _name = name;
            _subQueries = subQueries;
            _criteria = criteria;
        }

        public QueryName Name 
        {
            get { return _name; }
        }

        public IEnumerable<Criterion> Criteria
        {
            get { return _criteria; }
        }

        public IEnumerable<Query> SubQueries
        {
            get { return _subQueries; }
        }

        public QueryOperator QueryOperator { get; set; }

        public IList<OrderByClause> OrderByClauses
        {
            get { return _orderByClauses; }
        }

        public bool IsNamedQuery()
        {
            return Name != QueryName.Dynamic;
        }

        public void AddOrderByClause(OrderByClause orderByClause)
        {
            if (!IsNamedQuery())
            {
                _orderByClauses.Add(orderByClause);
            }
            else
            {
                throw new ApplicationException("You cannot add additional subquery to named queries");
            }
        }

        public void ClearOrderByClause()
        {
            if (!IsNamedQuery())
            {
                _orderByClauses.Clear();
            }
            else
            {
                throw new ApplicationException("You cannot add additional subquery to named queries");
            }
        }

        public void AddSubQuery(Query subQuery)
        {
            if (!IsNamedQuery())
            {
                _subQueries.Add(subQuery);
            }
            else 
            {
                throw new ApplicationException("You cannot add additional subquery to named queries");
            }
        }

        public void AddCriterion(Criterion criterion)
        {
            if (!IsNamedQuery())
            {
                _criteria.Add(criterion);
            }
            else
            {
                throw new ApplicationException("You cannot add additional criteria to named queries");
            }
        }
    }
}
