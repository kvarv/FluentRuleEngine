using System.Collections.Generic;

namespace FluentRuleEngine
{
    public class RuleSet
    {
        public List<Rule> RuleList = new List<Rule>();
        public string Name;

        public RuleSet(string name)
        {
            Name = name;
        }

        public void Rules(params Rule[] rules)
        {
            foreach (var rule in rules)
            {
                RuleList.Add(rule);
            }
        }

        public void Execute()
        {
            RuleList.ForEach(rule => rule.Execute());
        }
    }
}