namespace FluentRuleEngine
{
    public static class Extensions
    {
        public static bool And(this bool condition, bool andCondition)
        {
            return condition && andCondition;
        }

        public static bool Or(this bool condition, bool orCondition)
        {
            return condition || orCondition;
        }


        public static bool And(this bool condition, Rule rule)
        {
            return condition && rule.Condition;
        }

        public static bool Or(this bool condition, Rule rule)
        {
            return condition || rule.Condition;
        }
        
    }
}