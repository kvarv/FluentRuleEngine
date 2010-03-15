using System;
using System.Collections.Generic;
using FluentRuleEngine.Dsl.Builders;
using FluentRuleEngine.Dsl.Expressions;

namespace FluentRuleEngine.Dsl
{
	public class RuleEngineFor<TTarget>
	{
		public static RuleEngine<TTarget> Initialize(Action<IRuleBaseExpression<TTarget>> ruleBaseExpressionAction)
		{
			var ruleBase = new RuleBase<TTarget>();
			var ruleBaseExpression = new RuleBaseExpression<TTarget>();
			ruleBaseExpressionAction(ruleBaseExpression);
			AddDefaultRuleSet(ruleBaseExpression.RuleExpressions, ruleBase);
			ruleBaseExpression.RuleSets.ForEach(ruleBase.AddRuleSet);
			return new RuleEngine<TTarget>(ruleBase);
		}

		public static RuleEngine<TTarget> Initialize<TRuleBase>() where TRuleBase : RuleBaseBuilder<TTarget>
		{
			var ruleBaseBuilder = Activator.CreateInstance<TRuleBase>();
			ruleBaseBuilder.Build();
			var ruleBase = new RuleBase<TTarget>();
			AddDefaultRuleSet(ruleBaseBuilder.RuleExpressions, ruleBase);
			ruleBaseBuilder.RuleSets.ForEach(ruleBase.AddRuleSet);
			return new RuleEngine<TTarget>(ruleBase);
		}

		private static void AddDefaultRuleSet<T>(List<RuleExpression<T>> ruleExpressions, RuleBase<T> ruleBase)
		{
			var defaultRuleSet = new RuleSet<T>();
			ruleExpressions.ForEach(ruleBuilder => defaultRuleSet.AddRule(ruleBuilder));
			ruleBase.AddRuleSet(defaultRuleSet);
		}
	}
}