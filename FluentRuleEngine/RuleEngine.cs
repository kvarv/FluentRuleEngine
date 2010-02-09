using System.Collections.Generic;

namespace FluentRuleEngine
{
    public abstract class RuleEngine
    {
        public List<RuleSet> RuleSets = new List<RuleSet>();

        public Rule Rule(string name)
        {
            Rule rule = new Rule(name);
            return rule;
        }
        public RuleSet RuleSet(string name)
        {
            RuleSet ruleSet = new RuleSet(name);
            RuleSets.Add(ruleSet);
            return ruleSet;
        }

        public void Execute()
        {
            RuleSets.ForEach(ruleSet => ruleSet.Execute());
        }
    }
}