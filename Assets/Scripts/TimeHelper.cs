using System;

public enum TimeFormatType
{
    None,
    MinuteNSecond,
}

public static class TimeHelper
{
    public static string StringTimeFormated(TimeFormatType formatType, int seconds)
    {
        switch (formatType)
        {
            case TimeFormatType.None:
                return seconds + "";
                break;
            case TimeFormatType.MinuteNSecond:
                TimeSpan timeSpan = TimeSpan.FromSeconds(seconds);
                return string.Format("{0}:{1}", timeSpan.Minutes, timeSpan.Seconds);
                break;
        }

        return seconds + "";
    }
}