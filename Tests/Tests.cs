using System.Collections.Generic;
using FluentRuleEngine;
using Xunit;
using XunitExt;

namespace Tests
{
    public class Tests
    {
        public static IEnumerable<object[]> ConditionsAndExpectedEvaluations
        {
            get
            {
                yield return new object[] { true.And(true), true };
                yield return new object[] { true.Or(false), true };
                yield return new object[] { true.And(false), false };
                yield return new object[] { false.Or(false), false };
                yield return new object[] { true.And(true), true };
                yield return new object[] { true.And(true.Or(false)), true };
                yield return new object[] { true.Or(true.And(false)), true };
                yield return new object[] { true.And(false.And(false)), false };
                yield return new object[] { false.Or(true).And(false), false };
                yield return new object[] { false.Or(true).And(true), true };
            }
        }

        [Theory]
        [PropertyData("ConditionsAndExpectedEvaluations")]
        public void ShouldEvaluateCondition(bool condition, bool expectedEvaluation)
        {
            Rule rule = new Rule("").When(condition);
            Assert.Equal(expectedEvaluation, rule.Condition);
        }

        [Fact]
        public void RulesShouldBeAddedToRuleSet()
        {
            Task task = new Task();
            TaskRuleEngine engine = new TaskRuleEngine();
            engine.SetUp(task);
            Assert.Equal(2, engine.RuleSets.Count);
            Assert.Equal("Remaining Hours", engine.RuleSets[0].RuleList[0].Name);
            Assert.Equal("Task is done when remaining hours is 0", engine.RuleSets[0].RuleList[0].RuleDescription);
            Assert.Equal("Estimate", engine.RuleSets[0].RuleList[1].Name);
            Assert.Equal("Example rule 1", engine.RuleSets[1].RuleList[0].Name);
            Assert.Equal("Example rule 2", engine.RuleSets[1].RuleList[1].Name);
            Assert.Equal(2, engine.RuleSets[0].RuleList.Count);
            Assert.Equal(2, engine.RuleSets[1].RuleList.Count);
        }

        [Fact]
        public void ShouldExecuteActionWhenConditionIsTrue()
        {
            Task task = new Task { RemainingHours = 0, Estimate = 10};
            TaskRuleEngine engine = new TaskRuleEngine();
            engine.SetUp(task);
            engine.Execute();
            Assert.True(task.IsDone);
            Assert.True(task.IsTooBig);
        }

        [Fact]
        public void ShouldNotExecuteActionWhenConditionIsFalse()
        {
            Task task = new Task { RemainingHours = 0, Estimate = 5};
            TaskRuleEngine engine = new TaskRuleEngine();
            engine.SetUp(task);
            engine.Execute();
            Assert.False(task.IsTooBig);
        }

        [Fact]
        public void ShouldEvaluateConditionOfReferencedRules()
        {
            Rule rule = new Rule("").When(true);
            Rule rule2 = new Rule("").When(true.And(rule));
            Assert.True(rule2.Condition);

            Rule rule3 = new Rule("").When(false);
            Rule rule4 = new Rule("").When(true.And(rule3));
            Assert.False(rule4.Condition);
        }
    }
}
