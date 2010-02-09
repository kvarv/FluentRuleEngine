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

        }
    }
}