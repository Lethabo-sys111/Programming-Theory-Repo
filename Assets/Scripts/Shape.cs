using UnityEngine;

// INHERITANCE - abstract parent class that every clickable shape derives from
public abstract class Shape : MonoBehaviour
{
    [SerializeField] private string shapeName = "Shape";
    [SerializeField] private Color shapeColor = Color.white;

    private Renderer shapeRenderer;

    // ENCAPSULATION - name is validated before it can be changed
    public string ShapeName
    {
        get { return shapeName; }
        set
        {
            if (string.IsNullOrWhiteSpace(value) || value.Length > 12)
            {
                Debug.LogWarning("Shape name must be between 1 and 12 characters.");
                return;
            }
            shapeName = value;
        }
    }

    // ENCAPSULATION - setting the colour also updates the material
    public Color ShapeColor
    {
        get { return shapeColor; }
        set
        {
            shapeColor = value;
            ApplyColor();
        }
    }

    // ENCAPSULATION - other classes can read the count but not change it
    public int ClickCount { get; private set; }

    protected virtual void Awake()
    {
        shapeRenderer = GetComponent<Renderer>();
        ApplyColor();
    }

    // ABSTRACTION - callers just call OnClicked(); the steps are hidden inside
    public void OnClicked()
    {
        ClickCount++;
        React();
        UIManager.Instance.ShowMessage(GetDisplayText(), ShapeColor);
    }

    // ABSTRACTION
    private void ApplyColor()
    {
        if (shapeRenderer != null)
        {
            shapeRenderer.material.color = shapeColor;
        }
    }

    // POLYMORPHISM - every child must provide its own text
    protected abstract string GetDisplayText();

    // POLYMORPHISM - children can override how they react to a click
    protected virtual void React()
    {
        Debug.Log(ShapeName + " was clicked.");
    }
}
