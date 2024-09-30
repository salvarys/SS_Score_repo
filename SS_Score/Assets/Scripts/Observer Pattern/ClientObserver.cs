using UnityEngine;
using UnityEngine.UI;

public class ClientObserver : MonoBehaviour
{
    private Subject subject;
    private Transform player;
    private Text messageText;

    void Start()
    {
        // Find the Subject and Player in the scene
        subject = FindObjectOfType<Subject>();
        player = GameObject.FindWithTag("Player").transform;
        messageText = GameObject.Find("MessageText").GetComponent<Text>();

        if (subject == null || player == null || messageText == null)
        {
            Debug.LogError("Subject, Player, or MessageText not found! Make sure they exist in the scene.");
            return;
        }

        // Register all observers in the scene and setup references
        Observer[] allObservers = FindObjectsOfType<Observer>();
        foreach (Observer observer in allObservers)
        {
            subject.RegisterObserver(observer);
            observer.SetupObserver(player, messageText);
        }

        Debug.Log("All observers registered and set up successfully.");
    }

    void Update()
    {
        // Check the distance for each observer
        foreach (Observer observer in subject.GetComponentsInChildren<Observer>())
        {
            if (observer.IsWithinTriggerDistance())
            {
                observer.Notify(subject);
            }
        }
    }
}
