namespace FluentRuleEngine.Dsl.Expressions
{
	public interface IRuleSetExpression<T>
	{
		RuleExpression<T> Rule(string name);
	}
}