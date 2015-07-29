using System.Collections.Generic;
using System.Text;

namespace Maer.Infrastructure.Domain
{
    public abstract class EntityBase<TId>
    {
        private IList<BusinessRule> _brokenRules = new List<BusinessRule>();

        public virtual TId Id { get; set; }

        protected abstract void Validate();

        protected void AddRule(BusinessRule businessRule) 
        {
            _brokenRules.Add(businessRule);
        }

        public virtual IEnumerable<BusinessRule> GetBrokenRules() 
        {
            _brokenRules.Clear();
            Validate();

            return _brokenRules;
        }

        public void ThrowExceptionIfInvalid()
        {
            _brokenRules.Clear();
            Validate();
            if (_brokenRules.Count > 0)
            {
                StringBuilder issues = new StringBuilder();
                foreach (BusinessRule rule in _brokenRules)
                {
                    issues.AppendLine(rule.Rule);
                }
                throw new EntityObjectIsInvalidException(issues.ToString());
            }
        }

        public override bool Equals(object entity)
        {
            return entity != null
               && entity is EntityBase<TId>
               && this == (EntityBase<TId>)entity;

        }

        public override int GetHashCode()
        {
            return this.Id.GetHashCode();
        }

        public static bool operator ==(EntityBase<TId> entity1, EntityBase<TId> entity2)
        {
            if ((object)entity1 == null && (object)entity2 == null)
            {
                return true;
            }

            if ((object)entity1 == null || (object)entity2 == null)
            {
                return false;
            }

            if (entity1.Id.ToString() == entity2.Id.ToString())
            {
                return true;
            }

            return false;
        }

        public static bool operator !=(EntityBase<TId> entity1,
            EntityBase<TId> entity2)
        {
            return (!(entity1 == entity2));
        }
    }
}
