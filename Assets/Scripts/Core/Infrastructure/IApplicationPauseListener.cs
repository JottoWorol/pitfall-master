namespace Core.Infrastructure
{
    public interface IApplicationPauseListener
    {
        void OnApplicationPause(bool pause);
    }
}