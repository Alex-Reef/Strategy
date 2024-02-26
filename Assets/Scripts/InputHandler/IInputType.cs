namespace InputHandler
{
    public interface IInputType
    {
        public void Init(BaseInputHandler baseInputHandler);
        public void Handle();
    }
}