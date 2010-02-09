using FluentRuleEngine;

namespace Tests
{
    public class TaskRuleEngine : RuleEngine
    {
        public void SetUp(Task task)
        {
            RuleSet("First ruleset").
                                    Rules(
                                        Rule("Remaining Hours").
                                            Description("Task is done when remaining hours is 0").
                                            When(task.RemainingHours == 0).
                                            Then(() => task.IsDone = true),

                                        Rule("Estimate").
                                            When((task.Estimate > 8)).
                                            Then(() => task.IsTooBig = true)
                                    );



            Rule ruleReference = Rule("Example rule 1").
                                    Description("Used in another rule. If you absolutely want to!").
                                    When(task.RemainingHours > 0).
                                    Then(() => task.IsDone = false);

            RuleSet("Second ruleset").
                                    Rules(
                                        ruleReference,
                                        Rule("Example rule 2").
                                            Description("Evaluates also the condition of another rule").
                                            When((task.Estimate < 8).And(ruleReference)).
                                            Then(() => task.IsTooBig = false)
                                    );
        }
    }
}