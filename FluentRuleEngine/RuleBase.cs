using System;
using System.Collections.Generic;

namespace FluentRuleEngine
{
	public class RuleBase<T>
	{
		public RuleBase()
		{
			RuleSets = new List<RuleSet<T>>();
		}


		public List<RuleSet<T>> RuleSets{ get; private set;}

		public void AddRuleSet(RuleSet<T> ruleSet)
		{
			RuleSets.Add(ruleSet);
		}

		public List<Rule<T>> Rules
		{
			get
			{
				var allRules = new List<Rule<T>>();
				RuleSets.ForEach(ruleSet => allRules.AddRange(ruleSet.Rules));
				return allRules;
			}
		}
	}
}