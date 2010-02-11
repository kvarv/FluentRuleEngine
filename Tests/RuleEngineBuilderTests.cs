using System;
using FluentRuleEngine;
using FluentRuleEngine.Builders;
using Xunit;

namespace Tests
{
	public class RuleEngineBuilderTests
	{
		[Fact]
		public void ShouldBuildRuleBase()
		{
			//Arrange
			var ruleBaseBuilder = new RuleBaseBuilder<Target>();
			ruleBaseBuilder.CreateRuleSet("First rule set", x =>
			                                                	{
			                                                		x.Rule("rule 1")
			                                                			.Description("description")
			                                                			.When(t => t.Name == "goran")
			                                                			.Then(t => t.Name = "goran kvarv");

			                                                		x.Rule("rule 2")
			                                                			.Description("description");
			                                                	});
			ruleBaseBuilder.CreateRuleSet("My rule set", MyRuleSet.Create);

			var ruleEngine = new RuleEngine<Target>(ruleBaseBuilder);
			var target = new Target {Name = "goran"};
			//Act
			ruleEngine.Execute(target);
			//Assert
			Assert.Equal("goran sveia kvarv", target.Name);
		}
	}

	//If you want to setup the rules in separate classes
	public class MyRuleSet
	{
		public static void Create(RuleSetExpression<Target> x)
		{
			x.Rule("rule 3")
				.Description("description")
				.When(t => t.Name == "goran kvarv")
				.Then(t => t.Name = "goran sveia kvarv");

			x.Rule("rule 4")
				.Description("description");
		}
	}
}