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

		public RuleExpression<T> Rule(string name)
		{
			var ruleBuilder = new RuleExpression<T>();
			ruleBuilder.Name(name);
			RuleExpressions.Add(ruleBuilder);
			return ruleBuilder;
		}
	}
}