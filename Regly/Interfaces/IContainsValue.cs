namespace Regly.Interfaces
{
    public interface IContainsValue : IExecutableExpression, IPositionableValue, ICaseSensitive<IContainsValue>
    {
        IContainsValue ButNot(string notContains);
    }
}