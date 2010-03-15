using System.Collections.Generic;

namespace FluentRuleEngine
{
	public class RuleBase<TTarget>
	{
		public RuleBase()
		{
			RuleSets = new List<RuleSet<TTarget>>();
		}


		public List<RuleSet<TTarget>> RuleSets { get; private set; }

		public List<Rule<TTarget>> Rules
		{
			get
			{
				var allRules = new List<Rule<TTarget>>();
				RuleSets.ForEach(ruleSet => allRules.AddRange(ruleSet.Rules));
				return allRules;
			}
		}

		public void AddRuleSet(RuleSet<TTarget> ruleSet)
		{
			RuleSets.Add(ruleSet);
		}
	}
}