using Unity.VisualScripting;
using UnityEngine;

namespace Burak.TweenKit
{
    public static class TransformExtensions
    {
        public static TransformInterpolation MoveWithInterpolation(this Transform transform, Vector3 target, float duration, EaseMode easeMode = EaseMode.Linear)
        {
            var interp = transform.GetComponent<TransformInterpolation>();
            if (interp is null)
                interp = transform.AddComponent<TransformInterpolation>();
            
            interp.MoveTo(target, duration, easeMode);
            return interp;
        }
    }
}
