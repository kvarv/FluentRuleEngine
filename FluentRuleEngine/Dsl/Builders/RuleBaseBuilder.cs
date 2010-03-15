using System.Collections.Generic;
using System.Linq;
using FluentRuleEngine.Dsl.Expressions;

namespace FluentRuleEngine.Dsl.Builders
{
	public abstract class RuleBaseBuilder<TTarget>
	{
		private readonly RuleBaseExpression<TTarget> _ruleBaseExpression;

		protected RuleBaseBuilder()
		{
			_ruleBaseExpression = new RuleBaseExpression<TTarget>();
		}

		public List<RuleExpression<TTarget>> RuleExpressions
		{
			get { return _ruleBaseExpression.RuleExpressions; }
		}

		public List<RuleSet<TTarget>> RuleSets
		{
			get { return _ruleBaseExpression.RuleSets; }
		}

		public abstract void Build();

		public RuleExpression<TTarget> Rule(string name)
		{
			return _ruleBaseExpression.AddRuleWithName(name);
		}

		public void RuleSet(params RuleExpression<TTarget>[] ruleExpressions)
		{
			var ruleSet = new RuleSet<TTarget>();
			ruleExpressions.ToList().ForEach(ruleExpression => ruleSet.AddRule(ruleExpression));
			_ruleBaseExpression.AddRuleSet(ruleSet);
		}

		public void AddRuleSet<TRuleSet>() where TRuleSet : RuleSetBuilder<TTarget>
		{
			_ruleBaseExpression.Add<TRuleSet>();
		}
	}
}