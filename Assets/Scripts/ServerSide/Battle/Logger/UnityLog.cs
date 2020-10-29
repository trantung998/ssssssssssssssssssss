namespace ServerSide.Battle.Logger
{
    public class UnityLog : ILog
    {
        public void Debug(string msg)
        {
            UnityEngine.Debug.Log(msg);
        }

        public void Error(string msg)
        {
            UnityEngine.Debug.LogError(msg);
        }
    }
}