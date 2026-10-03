using System.Collections;
using UnityEngine;

// INHERITANCE - SphereShape is a child of Shape
public class SphereShape : Shape
{
    [SerializeField] private float hopHeight = 1f;
    [SerializeField] private float hopDuration = 0.4f;

    private bool isHopping;

    // POLYMORPHISM
    protected override string GetDisplayText()
    {
        return "I'm " + ShapeName + ", a sphere with no corners at all. Clicks: " + ClickCount;
    }

    // POLYMORPHISM - the sphere hops
    protected override void React()
    {
        if (!isHopping)
        {
            StartCoroutine(Hop());
        }
    }

    private IEnumerator Hop()
    {
        isHopping = true;
        Vector3 start = transform.position;
        float t = 0f;

        while (t < hopDuration)
        {
            t += Time.deltaTime;
            float height = Mathf.Sin(t / hopDuration * Mathf.PI) * hopHeight;
            transform.position = start + Vector3.up * height;
            yield return null;
        }

        transform.position = start;
        isHopping = false;
    }
}
