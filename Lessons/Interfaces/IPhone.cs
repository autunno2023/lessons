namespace Interfaces
{
    interface ITelefono
    {
        public void Call();
    }
    interface IMultimedia
    {
        public void Play();

    }
    interface ISmartPhone : ITelefono, IMultimedia
    {

    }
    public class IPhone : ISmartPhone
    {
        public void Play() { }
        public void Call() { }
    }
}
