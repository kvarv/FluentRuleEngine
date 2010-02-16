using System;
using System.Collections.Generic;
using FluentRuleEngine.Dsl.Builders;
using FluentRuleEngine.Dsl.Expressions;

namespace FluentRuleEngine.Dsl
{
	public class Fluently
	{
		public static RuleEngine<T> Initialize<T>(Action<IRuleBaseExpression<T>> ruleBaseExpressionAction)
		{
			var ruleBase = new RuleBase<T>();
			var ruleBaseExpression = new RuleBaseExpression<T>();
			ruleBaseExpressionAction(ruleBaseExpression);
			AddDefaultRuleSet(ruleBaseExpression.RuleExpressions, ruleBase);
			ruleBaseExpression.RuleSets.ForEach(ruleBase.AddRuleSet);
			return new RuleEngine<T>(ruleBase);
		}

		public static RuleEngine<T> Initialize<T>(RuleBaseBuilder<T> ruleBaseBuilder)
		{
			ruleBaseBuilder.Build();
			var ruleBase = new RuleBase<T>();
			AddDefaultRuleSet(ruleBaseBuilder.RuleExpressions, ruleBase);
			ruleBaseBuilder.RuleSets.ForEach(ruleBase.AddRuleSet);
			return new RuleEngine<T>(ruleBase);
		}

		private static void AddDefaultRuleSet<T>(List<RuleExpression<T>> ruleExpressions, RuleBase<T> ruleBase)
		{
			var defaultRuleSet = new RuleSet<T>();
			ruleExpressions.ForEach(ruleBuilder => defaultRuleSet.AddRule(ruleBuilder));
			ruleBase.AddRuleSet(defaultRuleSet);
		}
	}
}