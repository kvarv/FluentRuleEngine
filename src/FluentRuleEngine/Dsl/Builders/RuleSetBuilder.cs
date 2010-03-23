using System.Collections.Generic;
using FluentRuleEngine.Dsl.Expressions;

namespace FluentRuleEngine.Dsl.Builders
{
	public abstract class RuleSetBuilder<T>
	{
		private readonly RuleSetExpression<T> _ruleSetExpression;

		protected RuleSetBuilder()
		{
			_ruleSetExpression = new RuleSetExpression<T>();
		}

		public List<RuleExpression<T>> RuleExpressions
		{
			get { return _ruleSetExpression.RuleExpressions; }
		}

		public abstract void Build();

		public RuleExpression<T> Rule(string name)
		{
			return _ruleSetExpression.AddRuleWithName(name);
		}
	}
}