using System;
using System.Collections.Generic;
using FluentRuleEngine.Dsl.Builders;

namespace FluentRuleEngine.Dsl.Expressions
{
	public class RuleBaseExpression<T> : IRuleBaseExpression<T>
	{
		private readonly List<RuleExpression<T>> _ruleExpressions = new List<RuleExpression<T>>();
		private readonly List<RuleSet<T>> _ruleSets = new List<RuleSet<T>>();

		public List<RuleExpression<T>> RuleExpressions
		{
			get { return _ruleExpressions; }
		}

		public List<RuleSet<T>> RuleSets
		{
			get { return _ruleSets; }
		}

		public RuleExpression<T> Rule(string name)
		{
			var ruleExpression = new RuleExpression<T>();
			ruleExpression.Name(name);
			_ruleExpressions.Add(ruleExpression);
			return ruleExpression;
		}

		public void RuleSet(Action<IRuleSetExpression<T>> ruleSetExpressionAction)
		{
			var ruleSetExpression = new RuleSetExpression<T>();
			ruleSetExpressionAction(ruleSetExpression);
			AddRulesToRuleSet(ruleSetExpression.RuleExpressions);
		}

		public void RuleSet(RuleSetBuilder<T> ruleSetBuilder)
		{
			ruleSetBuilder.Build();
			AddRulesToRuleSet(ruleSetBuilder.RuleExpressions);
		}

		private void AddRulesToRuleSet(List<RuleExpression<T>> ruleExpressions)
		{
			var ruleSet = new RuleSet<T>();
			ruleExpressions.ForEach(ruleExpression => ruleSet.AddRule(ruleExpression));
			AddRuleSet(ruleSet);
		}

		public void AddRuleSet(RuleSet<T> ruleSet)
		{
			_ruleSets.Add(ruleSet);
		}
	}
}