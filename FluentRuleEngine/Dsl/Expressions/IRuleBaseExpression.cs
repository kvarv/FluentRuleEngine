using System;
using FluentRuleEngine.Dsl.Builders;

namespace FluentRuleEngine.Dsl.Expressions
{
	public interface IRuleBaseExpression<T>
	{
		void Add(Action<IRuleSetExpression<T>> ruleSetExpressionAction);
		void Add<TRuleSet>() where TRuleSet : RuleSetBuilder<T>;
		RuleExpression<T> AddRule { get; }
	}
}