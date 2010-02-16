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
			var ruleSet = new RuleSet<Target>();
			var rule = new Rule<Target>("rule 1", "", t => t.Number == 0, t => t.Number = 1);
			ruleSet.AddRule(rule);
			ruleBase.AddRuleSet(ruleSet);
			var ruleEngine = new RuleEngine<Target>(ruleBase);

			var target = new Target();
			ruleEngine.Execute(target);
			Assert.Equal(1, target.Number);
			var newTarget = new Target();
			ruleEngine.Execute(newTarget);
			Assert.Equal(1, newTarget.Number);
		}

		[Fact]
		public void ShouldForwardChainRules()
		{
			var ruleBase = new RuleBase<Target>();
			var ruleSet = new RuleSet<Target>();
			var rule = new Rule<Target>("rule 1", "description of rule 1", t => t.Number == 0, t => t.Number = 1);
			var rule2 = new Rule<Target>("rule 2", "", t => t.Number == 1, t => t.Number = 2);
			ruleSet.AddRule(rule);
			ruleSet.AddRule(rule2);
			ruleBase.AddRuleSet(ruleSet);
			var target = new Target();
			var ruleEngine = new RuleEngine<Target>(ruleBase);
			ruleEngine.Execute(target);
			Assert.Equal(2, target.Number);
		}
	}
}