using System;
using FluentRuleEngine.Dsl.Builders;

namespace FluentRuleEngine.Dsl.Expressions
{
	public interface IRuleBaseExpression<T>
	{
		RuleExpression<T> Rule(string name);
		void RuleSet(Action<IRuleSetExpression<T>> ruleSetExpressionAction);
		void RuleSet(RuleSetBuilder<T> ruleSet);
	}
}