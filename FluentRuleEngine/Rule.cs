namespace FluentRuleEngine
{
    public class Rule
    {
        public bool Condition;
        public delegate void Action();
        public Action ActionToExecute;
        public string Name { get; set; }
        public string RuleDescription { get; set; }

        public Rule(string name)
        {
            Name = name;
        }

        public Rule Description(string description)
        {
            RuleDescription = description;
            return this;
        }

        public bool And(bool condition)
        {
            return condition;
        }

        public bool Or(bool condition)
        {
            return condition;
        }


        public void Execute()
        {
            if (Condition && ActionToExecute != null)
                ActionToExecute();
        }

        public Rule When(bool condition)
        {
            Condition = condition;
            return this;
        }

        public Rule Then(Action action)
        {
            ActionToExecute = action;
            return this;
        }
    }
}