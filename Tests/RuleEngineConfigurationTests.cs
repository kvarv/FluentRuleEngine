using FluentRuleEngine.Dsl;
using Xunit;

namespace Tests
{
	public class RuleEngineConfigurationTests
	{
		[Fact]
		public void ShouldInitializeEngine()
		{
			//Arrange
			var ruleEngine = RuleEngineFor<Target>.Initialize(ruleBase =>
			                                                  	{
			                                                  		ruleBase.AddRule.Named("rule 1")
			                                                  			.Description("description")
			                                                  			.When(t => t.Number.Equals(0))
			                                                  			.Then(t => t.Number = 1);

			                                                  		ruleBase.Add(ruleSet =>
			                                                  		             	{
			                                                  		             		ruleSet.AddRule.Named("rule 2")
			                                                  		             			.Description("description")
			                                                  		             			.When(t => t.Number.Equals(1))
			                                                  		             			.Then(t => t.Number = 2);

			                                                  		             		ruleSet.AddRule.Named("rule 3")
			                                                  		             			.Description("description")
			                                                  		             			.When(t => t.Number.Equals(2))
			                                                  		             			.Then(t => t.Number = 3);
			                                                  		             	});

			                                                  		ruleBase.Add<MyRuleSet>();
			                                                  	});

			var target = new Target();
			//Act
			ruleEngine.Execute(target);
			//Assert
			Assert.Equal(4, target.Number);
		}

		[Fact]
		public void ShouldInitializeEngineWithRuleBaseBuilder()
		{
			//Arrange
			var ruleEngine = RuleEngineFor<Target>.Initialize<MyRuleBase>();
			var target = new Target();
			//Act
			ruleEngine.Execute(target);
			//Assert
			Assert.Equal(4, target.Number);
		}
	}
}