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
			var ruleBaseExpression = new RuleBaseExpression<TTarget>();
			ruleBaseExpressionAction(ruleBaseExpression);
			var ruleBase = CreateRuleBase(ruleBaseExpression.RuleSets, ruleBaseExpression.RuleExpressions);
			return new RuleEngine<TTarget>(ruleBase);
		}

		public static RuleEngine<TTarget> Initialize<TRuleBase>() where TRuleBase : RuleBaseBuilder<TTarget>
		{
			var ruleBaseBuilder = Activator.CreateInstance<TRuleBase>();
			ruleBaseBuilder.Build();
			var ruleBase = CreateRuleBase(ruleBaseBuilder.RuleSets, ruleBaseBuilder.RuleExpressions);
			return new RuleEngine<TTarget>(ruleBase);
		}

		private static RuleBase<TTarget> CreateRuleBase(List<RuleSet<TTarget>> ruleSets, List<RuleExpression<TTarget>> ruleExpressions)
		{
			var ruleBase = new RuleBase<TTarget>();
			AddDefaultRuleSet(ruleExpressions, ruleBase);
			ruleSets.ForEach(ruleBase.AddRuleSet);
			return ruleBase;
		}

		private static void AddDefaultRuleSet(List<RuleExpression<TTarget>> ruleExpressions, RuleBase<TTarget> ruleBase)
		{
			var defaultRuleSet = new RuleSet<TTarget>();
			ruleExpressions.ForEach(ruleBuilder => defaultRuleSet.AddRule(ruleBuilder));
			ruleBase.AddRuleSet(defaultRuleSet);
		}
	}
}