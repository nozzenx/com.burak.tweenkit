using System.Collections;
using UnityEngine;

public class TransformInterpolation : MonoBehaviour
{
    private Coroutine _currentCoroutine;
    
    public event System.Action OnComplete;

    public void MoveTo(Vector3 target, float duration, EaseMode easeMode)
    {
        if (_currentCoroutine != null)
            StopCoroutine(_currentCoroutine);
        
        _currentCoroutine = StartCoroutine(MoveCoroutine(target, duration, easeMode));
    }

    private IEnumerator MoveCoroutine(Vector3 target, float duration, EaseMode easeMode)
    {
        Vector3 start = transform.position;
        float time = 0;

        while (time < duration)
        {
            time += Time.deltaTime;
            float t = time / duration;

            float eased = Ease.Apply(easeMode, t);
            transform.position = Vector3.Lerp(start, target, eased);
            
            yield return null;
        }
        
        transform.position = target;
        _currentCoroutine = null;
        OnComplete?.Invoke();
    }
}
