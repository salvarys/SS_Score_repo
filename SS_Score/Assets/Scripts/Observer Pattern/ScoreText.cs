using UnityEngine;

public class ScoreText : Observer
{
    private int score = 0;

    public override void Notify(Subject subject)
    {
        if (IsWithinTriggerDistance())
        {
            score += 100;
            messageText.text = "Score increased! Current Score: " + score;
        }
    }
}
