using System.Collections.Generic;

namespace FluentRuleEngine
{
	public class RuleSet<T>
	{
		public RuleSet()
		{
			Rules = new List<Rule<T>>();
		}

		public List<Rule<T>> Rules { get; private set; }

		public void AddRule(Rule<T> rule)
		{
			Rules.Add(rule);
		}
	}
}