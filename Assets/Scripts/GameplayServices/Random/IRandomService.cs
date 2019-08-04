public interface IRandomService
{
    /// <summary>
    /// /// Get int32 random number from range [0, max).
    /// </summary>
    /// <returns>Random int32 value.</returns>
    int GetInt(int max);

    /// <summary>
    /// Get int32 random number from range [min, max).
    /// </summary>
    /// <returns>Random int32 value.</returns>
    /// <param name="min">Min value.</param>
    /// <param name="max">Max value (excluded).</param>
    int GetInt(int min, int max);

    /// <summary>
    /// Get float random number from range [0, 1) or [0, 1] for includeOne=true.
    /// </summary>
    /// <param name="includeOne">Include 1 value for searching.</param>
    float GetFloat(bool includeOne = true);

    /// <summary>
    /// Get float random number from range [min, max) or [min, max] for includeMax=true.
    /// </summary>
    /// <returns>The float.</returns>
    /// <param name="min">Min value.</param>
    /// <param name="max">Max value.</param>
    /// <param name="includeMax">Include max value for searching.</param>
    float GetFloat(float min, float max, bool includeMax = true);
}