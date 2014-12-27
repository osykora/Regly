namespace Regly.Interfaces
{
    public interface IPositionableDigit
    {
        IContainsDigit AtTheBeggining();

        IContainsQuantity AtTheBegginingOf();
    }
}