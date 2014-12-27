namespace Regly
{
    public class Expression
    {
        public Expression(ExpressionType type)
            : this(type, string.Empty)
        {
        }

        public Expression(ExpressionType type, string value)
        {
            Type = type;
            Value = value;
        }

        public Expression(ExpressionType type, int count)
        {
            Type = type;
            Count = count;
        }

        public ExpressionType Type { get; set; }

        public string Value { get; set; }

        public int Count { get; set; }

        public static Expression AnyDigit
        {
            get { return new Expression(ExpressionType.AnyDigit); }
        }

        public static Expression AtTheBeggining
        {
            get { return new Expression(ExpressionType.AtTheBeggining); }
        }

        public static Expression AtTheBegginingOf
        {
            get { return new Expression(ExpressionType.AtTheBegginingOf); }
        }

        public static Expression Any
        {
            get { return new Expression(ExpressionType.Any); }
        }

        public static Expression First
        {
            get { return new Expression(ExpressionType.First); }
        }

        public static Expression Every
        {
            get { return new Expression(ExpressionType.Every); }
        }

        public static Expression Word
        {
            get { return new Expression(ExpressionType.Word); }
        }

        public static Expression Words
        {
            get { return new Expression(ExpressionType.Words); }
        }
    }
}