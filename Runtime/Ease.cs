using System;

public static class Ease
{
    public static float Apply(EaseMode mode, float t)
    {
        switch (mode)
        {
            default:
                
            case EaseMode.Linear:
                return t;
            case EaseMode.SmoothStep:
                return t * t * (3f - 2f * t);
            case EaseMode.InOutCubic:
                return t < 0.5f ?
                    4f * t * t * t :
                    1 - MathF.Pow(-2f * t + 2f, 3f) / 2f;
            case EaseMode.OutCubic:
                t--;
                return t * t * t + 1f;
        }
    }
}
