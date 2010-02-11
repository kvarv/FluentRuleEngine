using System;
using System.Collections.Generic;

namespace FluentRuleEngine.Builders
{
	public class RuleBaseBuilder<T>
	{
		private readonly List<RuleSetBuilder<T>> _ruleSetBuilders;

		public RuleBaseBuilder()
		{
			_ruleSetBuilders = new List<RuleSetBuilder<T>>();
		}

		public void CreateRuleSet(string name, Action<RuleSetExpression<T>> ruleExpression)
		{
			var ruleSetBuilder = new RuleSetBuilder<T>(name, ruleExpression);
			_ruleSetBuilders.Add(ruleSetBuilder);
		}

		public static implicit operator RuleBase<T>(RuleBaseBuilder<T> builder)
		{
			var ruleBase = new RuleBase<T>();
			builder._ruleSetBuilders.ForEach(ruleSetBuilder => ruleBase.AddRuleSet(ruleSetBuilder));
			return ruleBase;
		}
	}
}