namespace ServerSide.Battle.Logger
{
    public interface ILog
    {
        void Debug(string msg);
        void Error(string msg);
    }
}