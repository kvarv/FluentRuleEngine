namespace FluentRuleEngine.Dsl.Expressions
{
	public interface IRuleSetExpression<T>
	{
		RuleExpression<T> AddRule { get; }
	}
}