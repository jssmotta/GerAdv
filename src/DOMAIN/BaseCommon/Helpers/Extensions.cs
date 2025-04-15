namespace MenphisSI.BaseCommon;

public static class Extensions
{
    public static bool IsEmpty(this int value)
    {
        return value == int.MinValue;
    }
}