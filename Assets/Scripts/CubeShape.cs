using UnityEngine;

// INHERITANCE - CubeShape is a child of Shape
public class CubeShape : Shape
{
    // POLYMORPHISM - overriding the abstract method
    protected override string GetDisplayText()
    {
        return "I'm " + ShapeName + ", a cube with 6 equal faces. Clicks: " + ClickCount;
    }

    // POLYMORPHISM - the cube spins instead of using the default reaction
    protected override void React()
    {
        transform.Rotate(0f, 45f, 0f);
    }
}
