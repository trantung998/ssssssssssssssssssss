public static class BitHelper
{
    public static void SetBitOn(ref int value, int position)
    {
        value |= (1 << position);
    }

    public static void SetBitOff(ref int value, int position)
    {
        value &= ~(1 << position);
    }

    public static void SetBitOn(ref long value, int position)
    {
        value |= (1 << position);
    }

    public static void SetBitOff(ref long value, int position)
    {
        value &= ~(1 << position);
    }

    public static bool IsBitOn(int value, int position)
    {
        return (value & (1 << position)) > 0;
    }
}