using System.Collections.Generic;
using System.Text;

namespace Maer.Infrastructure.Domain
{
    public abstract class ValueObjectBase
    {
        private IList<BusinessRule> _brokenRules = new List<BusinessRule>();

        public ValueObjectBase() 
        { }

        protected abstract void Validate();

        protected void AddRule(BusinessRule businessRule) 
        {
            _brokenRules.Add(businessRule);
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
                throw new ValueObjectIsInvalidException(issues.ToString());
            }
        }
    }
}
