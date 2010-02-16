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
			var ruleEngine = Fluently.Initialize<Target>(ruleBase =>
			                                             	{
			                                             		ruleBase.Rule("rule 1")
			                                             			.Description("description")
			                                             			.When(t => t.Number.Equals(0))
			                                             			.Then(t => t.Number = 1);

			                                             		ruleBase.RuleSet(ruleSet =>
			                                             		                 	{
			                                             		                 		ruleSet.Rule("rule 2")
			                                             		                 			.Description("description")
			                                             		                 			.When(t => t.Number.Equals(1))
			                                             		                 			.Then(t => t.Number = 2);

			                                             		                 		ruleSet.Rule("rule 3")
			                                             		                 			.Description("description")
			                                             		                 			.When(t => t.Number.Equals(2))
			                                             		                 			.Then(t => t.Number = 3);
			                                             		                 	});

			                                             		ruleBase.RuleSet(new MyRuleSet());
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
			var ruleEngine = Fluently.Initialize(new MyRuleBase());
			var target = new Target();
			//Act
			ruleEngine.Execute(target);
			//Assert
			Assert.Equal(4, target.Number);
		}
	}
}