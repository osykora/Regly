namespace Regly.Interfaces
{
    public interface ICaseSensitive<out T>
    {
        T CaseInsensitive();

        T CaseSensitive();
    }
}