using System.Collections;
using UnityEngine;

// INHERITANCE - CapsuleShape is a child of Shape
public class CapsuleShape : Shape
{
    [SerializeField] private float pulseScale = 1.3f;
    [SerializeField] private float pulseDuration = 0.3f;

    private bool isPulsing;
    private Vector3 baseScale;

    protected override void Awake()
    {
        base.Awake();
        baseScale = transform.localScale;
    }

    // POLYMORPHISM
    protected override string GetDisplayText()
    {
        return "I'm " + ShapeName + ", a capsule: a cylinder with round ends. Clicks: " + ClickCount;
    }

    // POLYMORPHISM - the capsule pulses
    protected override void React()
    {
        if (!isPulsing)
        {
            StartCoroutine(Pulse());
        }
    }

    private IEnumerator Pulse()
    {
        isPulsing = true;
        float t = 0f;

        while (t < pulseDuration)
        {
            t += Time.deltaTime;
            float s = Mathf.Lerp(pulseScale, 1f, t / pulseDuration);
            transform.localScale = baseScale * s;
            yield return null;
        }

        transform.localScale = baseScale;
        isPulsing = false;
    }
}
