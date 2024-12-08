using UnityEngine;
using UnityEngine.UI;

public class ClientObserver : MonoBehaviour
{
    [SerializeField] private Subject subject;
    [SerializeField] private Transform player;
    [SerializeField] private Text messageText;

    void Update()
    {
        // Check the distance for each observer
        foreach (Observer observer in subject.GetComponentsInChildren<Observer>())
        {
            // Add a debug log to show current distance to each observer
            float distance = Vector3.Distance(observer.transform.position, player.position);
            Debug.Log($"{observer.gameObject.name} - Current Distance to Player: {distance}");

            if (observer.IsWithinTriggerDistance())
            {
                Debug.Log($"{observer.gameObject.name} - Distance met, notifying observer.");
                observer.Notify(subject);
            }
        }
    }
    void Start()
    {
        if (subject == null || player == null || messageText == null)
        {
            Debug.LogError("One or more references are missing! Please set them in the Inspector.");
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
}



