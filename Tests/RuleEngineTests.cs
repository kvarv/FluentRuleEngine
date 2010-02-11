using FluentRuleEngine;
using Xunit;

namespace Tests
{
	public class RuleEngineTests
	{

		[Fact]
		public void ShouldExecuteRuleEngineOnSeveralTargets()
		{
			var ruleBase = new RuleBase<Target>();
			var ruleSet = new RuleSet<Target>("rule set");
			var rule = new Rule<Target>("rule 1", "", t => string.IsNullOrEmpty(t.Name), t => t.Name = "goran");
			ruleSet.AddRule(rule);
			ruleBase.AddRuleSet(ruleSet);
			var ruleEngine = new RuleEngine<Target>(ruleBase);

			var target = new Target();
			ruleEngine.Execute(target);
			Assert.Equal("goran", target.Name);
			var newTarget = new Target();
			ruleEngine.Execute(newTarget);
			Assert.Equal("goran", newTarget.Name);
		}

		[Fact]
		public void ShouldForwardChainRules()
		{
			var ruleBase = new RuleBase<Target>();
			var ruleSet = new RuleSet<Target>("rule set");
			var rule = new Rule<Target>("rule 1", "description of rule 1", t => string.IsNullOrEmpty(t.Name), t => t.Name = "goran");
			var rule2 = new Rule<Target>("rule 2", "", t => t.Name == "goran" , t => t.Name = "goran kvarv");
			ruleSet.AddRule(rule);
			ruleSet.AddRule(rule2);
			ruleBase.AddRuleSet(ruleSet);
			var target = new Target();
			var ruleEngine = new RuleEngine<Target>(ruleBase);
			ruleEngine.Execute(target);
			Assert.Equal("goran kvarv", target.Name);
		}
	}
}