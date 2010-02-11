using System.Collections.Generic;

namespace FluentRuleEngine.Builders
{
	public class RuleSetExpression<T>
	{
		private readonly List<RuleBuilder<T>> _ruleBuilders = new List<RuleBuilder<T>>();

		public List<RuleBuilder<T>> RuleBuilders
		{
			get { return _ruleBuilders; }
		}

		public RuleBuilder<T> Rule(string name)
		{
			var ruleBuilder = new RuleBuilder<T>();
			ruleBuilder.Name(name);
			RuleBuilders.Add(ruleBuilder);
			return ruleBuilder;
		}
	}
}