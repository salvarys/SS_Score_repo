using UnityEngine;
using UnityEngine.UI;

public class ScoreText : Observer
{
    private int score = 0;

    private void OnEnable()
    {
        Score.OnDistanceReached += ChangeText;
    }

    private void OnDisable()
    {
        Score.OnDistanceReached -= ChangeText;
    } 

    public override void Notify(Subject subject)
    {
        if (IsWithinTriggerDistance())
        {
            score += 1;
            messageText.text = "Score increased! Current Score: " + score;
        }
    } 

    void ChangeText()
    {
        messageText.text = "Score increased! Current Score: " + score;
    }







}
