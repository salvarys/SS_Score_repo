using UnityEngine;

public class Spawner : Observer
{
    public Renderer playerRenderer;      // Reference to the player's Renderer
    public Color[] colors;              // Array of colors to switch between
    private int currentColorIndex = 0;  // Tracks the current color index

    private void OnEnable()
    {
        Score.OnDistanceReached += ObserverColorChange; // Subscribe to the event
    }

    private void OnDisable()
    {
        Score.OnDistanceReached -= ObserverColorChange; // Unsubscribe to prevent memory leaks
    }

    public override void Notify(Subject subject)
    {
        if (IsWithinTriggerDistance())
        {
            ChangePlayerColor();
        }
    }

    private void ObserverColorChange()
    {
        ChangePlayerColor();
    }

    private void ChangePlayerColor()
    {
        // Ensure the playerRenderer and colors array are assigned
        if (playerRenderer == null)
        {
            Debug.LogError("Spawner: Player Renderer is not assigned. Cannot change color.");
            return;
        }

        if (colors == null || colors.Length == 0)
        {
            Debug.LogError("Spawner: Colors array is not assigned or empty. Cannot change color.");
            return;
        }

        // Cycle to the next color
        currentColorIndex = (currentColorIndex + 1) % colors.Length;
        playerRenderer.material.color = colors[currentColorIndex];

        Debug.Log($"Player color changed to: {colors[currentColorIndex]}");
    }

    private new bool IsWithinTriggerDistance()
    {
        // Placeholder for distance check logic
        return true; // Example condition; customize as needed
    }
}
