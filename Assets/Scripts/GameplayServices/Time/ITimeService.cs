public interface ITimeService
{
    float DeltaTime { get; }

    float TimeFromStart { get; }

    float TimeScale { get; set; }
}