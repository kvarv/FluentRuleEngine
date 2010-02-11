using System.Collections.Generic;

namespace FluentRuleEngine
{
	public class RuleSet<T>
	{
		private string _name;

		public RuleSet(string name)
		{
			_name = name;
			Rules = new List<Rule<T>>();
		}

		public List<Rule<T>> Rules { get; private set; }

		public void AddRule(Rule<T> rule)
		{
			Rules.Add(rule);
		}
	}
}