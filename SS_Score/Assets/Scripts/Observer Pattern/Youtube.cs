using UnityEngine;

public class YouTube : Observer
{
    public string youtubeLink = "https://www.youtube.com/watch?v=dQw4w9WgXcQ";

    private void OnEnable()
    {
        EndTrigger.OnLevelCompleted += YoutubeVid;
    }

    private void OnDisable()
    {
        EndTrigger.OnLevelCompleted -= YoutubeVid;
    }

    public override void Notify(Subject subject)
    {
        if (IsWithinTriggerDistance())
        {
            messageText.text = "Level Complete! Opening YouTube video...";
            Application.OpenURL(youtubeLink);  // Opens the link in the browser
        }
    } 

    void YoutubeVid()
    {
        messageText.text = "Level Complete! Opening YouTube video...";
        Application.OpenURL(youtubeLink);
    }
}
