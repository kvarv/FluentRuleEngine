using System;
using System.Linq.Expressions;

namespace FluentRuleEngine
{
	public class Rule<T>
	{
		private readonly Action<T> _action;
		private readonly Expression<Predicate<T>> _condition;
		private readonly string _description;
		private readonly string _name;

		public Rule(string name, string description, Expression<Predicate<T>> condition, Action<T> action)
		{
			_name = name;
			_condition = condition;
			_action = action;
			_description = description;
		}

		public bool CanExecute(T target)
		{
			if (_condition == null) return false;
			var condition = _condition.Compile();
			return condition(target);
		}

		public void Execute(T target)
		{
			if (_action == null) return;
			_action(target);
		}

		public void PrintRule()
		{
			if (!string.IsNullOrEmpty(_name))
				Console.WriteLine(_name);
			if (!string.IsNullOrEmpty(_description))
				Console.WriteLine("  " + _description);
			Console.WriteLine("  Condition: " + _condition + "\n");
		}
	}
}