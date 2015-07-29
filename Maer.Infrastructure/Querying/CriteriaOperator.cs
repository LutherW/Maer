
namespace Maer.Infrastructure.Querying
{
    public enum CriteriaOperator
    {
        Equal,
        NotEqual,
        LesserThan,
        LesserThanOrEqual,
        GreaterThan,
        GreaterThanOrEqual,
        In,
        NotIn,
        Exists,
        NotExists,
        Like,
        LikeEnd,
        LikeStart,
        NotLike,
        Null,
        NotNull,
        NotApplicable,
        Between
        // TODO: Implement remainder of the criteria operators...
    }
}
