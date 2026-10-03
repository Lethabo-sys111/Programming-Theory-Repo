using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

// Singleton that shows messages on screen
public class UIManager : MonoBehaviour
{
    // ENCAPSULATION - anyone can read Instance, only this class can set it
    public static UIManager Instance { get; private set; }

    [SerializeField] private TMP_Text messageText;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }
        Instance = this;
    }

    private void Start()
    {
        ShowMessage("Click a shape!");
    }

    // POLYMORPHISM - method overloading (same name, different parameters)
    public void ShowMessage(string message)
    {
        ShowMessage(message, Color.white);
    }

    // POLYMORPHISM - method overloading
    public void ShowMessage(string message, Color color)
    {
        messageText.text = message;
        messageText.color = color;
    }

    public void BackToMenu()
    {
        SceneManager.LoadScene("Title");
    }
}
