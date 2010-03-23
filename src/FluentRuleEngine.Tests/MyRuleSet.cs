using FluentRuleEngine.Dsl.Builders;

namespace FluentRuleEngine.Tests
{
	public class MyRuleSet : RuleSetBuilder<Target>
	{
		public override void Build()
		{
			Rule("rule 4")
				.Description("description")
				.When(t => t.Number == 3)
				.Then(t => t.Number = 4);

			Rule("rule 5")
				.Description("description");
		}
	}
}