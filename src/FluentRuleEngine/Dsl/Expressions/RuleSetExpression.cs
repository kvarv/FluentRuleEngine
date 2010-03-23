using System.Collections.Generic;

namespace FluentRuleEngine.Dsl.Expressions
{
	public class RuleSetExpression<T> : IRuleSetExpression<T>
	{
		public RuleSetExpression()
		{
			RuleExpressions = new List<RuleExpression<T>>();
		}

		public List<RuleExpression<T>> RuleExpressions { get; private set; }

		public RuleExpression<T> AddRule
		{
			get
			{
				var ruleExpression = new RuleExpression<T>();
				RuleExpressions.Add(ruleExpression);
				return ruleExpression;
			}
		}

		public RuleExpression<T> AddRuleWithName(string name)
		{
			var ruleExpression = new RuleExpression<T>();
			ruleExpression.Named(name);
			RuleExpressions.Add(ruleExpression);
			return ruleExpression;
		}
	}
}