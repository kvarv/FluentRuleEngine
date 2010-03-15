using FluentRuleEngine.Dsl.Builders;

namespace Tests
{
	public class MyRuleSet : RuleSetBuilder<Target>
	{
		public override void Build()
		{
			Rule("rule 4")
				.WithDescription("description")
				.When(t => t.Number == 3)
				.Then(t => t.Number = 4);

			Rule("rule 5")
				.WithDescription("description");
		}
	}
}