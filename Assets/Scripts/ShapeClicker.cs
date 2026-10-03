using UnityEngine;
using UnityEngine.InputSystem;

// Detects mouse clicks on shapes using the Input System
public class ShapeClicker : MonoBehaviour
{
    [SerializeField] private Camera cam;

    private void Awake()
    {
        if (cam == null)
        {
            cam = Camera.main;
        }
    }

    private void Update()
    {
        if (Mouse.current == null || !Mouse.current.leftButton.wasPressedThisFrame)
        {
            return;
        }

        Ray ray = cam.ScreenPointToRay(Mouse.current.position.ReadValue());

        if (Physics.Raycast(ray, out RaycastHit hit) && hit.collider.TryGetComponent(out Shape shape))
        {
            shape.OnClicked(); // ABSTRACTION - one call, details hidden in Shape
        }
    }
}
