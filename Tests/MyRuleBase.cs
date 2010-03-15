using FluentRuleEngine.Dsl.Builders;

namespace Tests
{
	public class MyRuleBase : RuleBaseBuilder<Target>
	{
		public override void Build()
		{
			Rule("rule 1")
				.Description("description")
				.When(t => t.Number == 0)
				.Then(t => t.Number = 1);

			RuleSet(
			       	Rule("rule 2")
			       		.Description("description")
			       		.When(t => t.Number == 1)
			       		.Then(t => t.Number = 2),
			       	Rule("rule 3")
			       		.Description("description")
			       		.When(t => t.Number == 2)
			       		.Then(t => t.Number = 3)
				);

			RuleSet<MyRuleSet>();
		}
	}
}