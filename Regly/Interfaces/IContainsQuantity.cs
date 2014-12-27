namespace Regly.Interfaces
{
    public interface IContainsQuantity
    {
        IContainsEvery Every();

        IContainsAny Any();

        IContainsFirst First();

        IContainsFirstN First(int count);
    }
}