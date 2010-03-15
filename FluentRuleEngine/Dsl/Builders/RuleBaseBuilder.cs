using System.Collections.Generic;
using System.Linq;
using FluentRuleEngine.Dsl.Expressions;

namespace FluentRuleEngine.Dsl.Builders
{
	public abstract class RuleBaseBuilder<T>
	{
		private readonly RuleBaseExpression<T> _ruleBaseExpression;

		protected RuleBaseBuilder()
		{
			_ruleBaseExpression = new RuleBaseExpression<T>();
		}

		public List<RuleExpression<T>> RuleExpressions
		{
			get { return _ruleBaseExpression.RuleExpressions; }
		}

		public List<RuleSet<T>> RuleSets
		{
			get { return _ruleBaseExpression.RuleSets; }
		}

		public abstract void Build();

		public RuleExpression<T> Rule(string name)
		{
			return _ruleBaseExpression.AddRuleWithName(name);
		}

		public void RuleSet(params RuleExpression<T>[] ruleExpressions)
		{
			var ruleSet = new RuleSet<T>();
			ruleExpressions.ToList().ForEach(ruleExpression => ruleSet.AddRule(ruleExpression));
			_ruleBaseExpression.AddRuleSet(ruleSet);
		}

		public void RuleSet<TRuleSet>() where TRuleSet : RuleSetBuilder<T>
		{
			_ruleBaseExpression.AddRuleSet<TRuleSet>();
		}
	}
}