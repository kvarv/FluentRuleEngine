using System;
using System.Linq.Expressions;

namespace FluentRuleEngine.Builders
{
	public class RuleBuilder<T>
	{
		private Action<T> _action;
		private Expression<Predicate<T>> _condition;
		private string _description;
		private string _name;

		public RuleBuilder<T> Name(string name)
		{
			_name = name;
			return this;
		}

		public RuleBuilder<T> Description(string description)
		{
			_description = description;
			return this;
		}

		public RuleBuilder<T> When(Expression<Predicate<T>> condition)
		{
			_condition = condition;
			return this;
		}

		public RuleBuilder<T> Then(Action<T> action)
		{
			_action = action;
			return this;
		}

		public static implicit operator Rule<T>(RuleBuilder<T> builder)
		{
			return new Rule<T>(builder._name, builder._description, builder._condition, builder._action);
		}
	}
}