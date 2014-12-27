namespace Regly.Interfaces
{
    public interface IRegly
    {
        IContains Contains();

        IContainsValue Contains(string exactValue);

        ISplitBy SplitBy(string expression);
    }
}