using System.Collections.Generic;
using System.Linq;

namespace FluentRuleEngine
{
	public class RuleEngine<T>
	{
		private readonly List<Rule<T>> _initialRules;
		private readonly List<Rule<T>> _availableRules;
		private List<Rule<T>> _activatedRules;
		private readonly List<Rule<T>> _executedRules;

		public RuleEngine(RuleBase<T> ruleBase)
		{
			_initialRules = new List<Rule<T>>();
			_availableRules = new List<Rule<T>>();
			_activatedRules = new List<Rule<T>>();
			_executedRules = new List<Rule<T>>();
			_initialRules.AddRange(ruleBase.Rules);
		}

		public void Execute(T target)
		{
			ResetRuleEngine();
			AddInitialRules();
			ActivateRules(target);				
			while (_activatedRules.Count > 0)
			{
				ExecuteActivatedRules(target);
				ActivateRules(target);				
			}
			PrintExecutedRules();
		}

		public void PrintExecutedRules()
		{
			_executedRules.ForEach(rule => rule.PrintRule());
		}

		private void ResetRuleEngine()
		{
			_availableRules.Clear();
			_activatedRules.Clear();
			_executedRules.Clear();
		}

		private void AddInitialRules()
		{
			_availableRules.AddRange(_initialRules);
		}

		private void ActivateRules(T target)
		{
			_activatedRules = _availableRules.Where(rule => rule.CanExecute(target)).ToList();
			_activatedRules.ForEach(rule => _availableRules.Remove(rule));
		}
		private void ExecuteActivatedRules(T target)
		{
			_activatedRules.ForEach(rule => rule.Execute(target));
			_executedRules.AddRange(_activatedRules);
		}
	}
}