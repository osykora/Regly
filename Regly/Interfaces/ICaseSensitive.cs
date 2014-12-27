namespace Regly.Interfaces
{
    public interface ICaseSensitive<T>
    {
        T CaseInsensitive();

        T CaseSensitive();
    }
}