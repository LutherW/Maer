
namespace Maer.Infrastructure.Querying
{
    public class OrderByClause
    {
        public OrderByClause() { }

        public OrderByClause(string propertyName, bool desc) 
        {
            PropertyName = propertyName;
            Desc = desc;
        }

        public string PropertyName { get; set; }
        public bool Desc { get; set; }
    }
}
