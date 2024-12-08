using UnityEngine;
using UnityEngine.UI;

public class ScoreText : Observer
{
    public new Text messageText; // Reference to the Text component displaying the score
    private int score = 0;   // Tracks the current score

    private void OnEnable()
    {
        Score.OnDistanceReached += ChangeText; // Subscribe to the event
    }

    private void OnDisable()
    {
        Score.OnDistanceReached -= ChangeText; // Unsubscribe to prevent memory leaks
    }

    public override void Notify(Subject subject)
    {
        if (IsWithinTriggerDistance())
        {
            UpdateScore();
        }
    }

    private void ChangeText()
    {
        UpdateScore();
    }

    private void UpdateScore()
    {
        score += 1; // Increment the score

        if (messageText != null)
        {
            messageText.text = $"Score: {score}"; // Update the score display
        }
        else
        {
            Debug.LogError("ScoreText: messageText is not assigned. Cannot display score.");
        }
    }

    private new bool IsWithinTriggerDistance()
    {
        // Placeholder for a condition to check trigger distance
        return true; // Example condition; customize as needed
    }
}
