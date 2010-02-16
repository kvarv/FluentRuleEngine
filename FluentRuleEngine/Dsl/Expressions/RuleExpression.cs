using System;
using System.Linq.Expressions;

namespace FluentRuleEngine.Dsl.Expressions
{
	public class RuleExpression<T>
	{
		private Action<T> _action;
		private Expression<Predicate<T>> _condition;
		private string _description;
		private string _name;

		public RuleExpression<T> Name(string name)
		{
			_name = name;
			return this;
		}

		public RuleExpression<T> Description(string description)
		{
			_description = description;
			return this;
		}

		public RuleExpression<T> When(Expression<Predicate<T>> condition)
		{
			_condition = condition;
			return this;
		}

		public RuleExpression<T> Then(Action<T> action)
		{
			_action = action;
			return this;
		}

		public static implicit operator Rule<T>(RuleExpression<T> expression)
		{
			return new Rule<T>(expression._name, expression._description, expression._condition, expression._action);
		}
	}
}