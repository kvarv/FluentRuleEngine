using System;

namespace FluentRuleEngine.Builders
{
	public class RuleSetBuilder<T>
	{
		private readonly Action<RuleSetExpression<T>> _ruleExpression;
		private readonly string _name;

		public RuleSetBuilder(string name, Action<RuleSetExpression<T>> ruleExpression)
		{
			_name = name;
			_ruleExpression = ruleExpression;
		}

		public static implicit operator RuleSet<T>(RuleSetBuilder<T> builder)
		{
			var ruleSet = new RuleSet<T>(builder._name);
			var ruleSetExpression = new RuleSetExpression<T>();
			builder._ruleExpression(ruleSetExpression);
			ruleSetExpression.RuleBuilders.ForEach(ruleBuilder => ruleSet.AddRule(ruleBuilder));
			return ruleSet;
		}
	}
}