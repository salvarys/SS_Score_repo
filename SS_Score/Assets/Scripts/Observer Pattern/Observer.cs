using UnityEngine;
using UnityEngine.UI;

public abstract class Observer : MonoBehaviour
{
    public float distanceToTrigger = 5f;  // Distance from the player to trigger the event
    protected Transform player;            // Reference to the player
    protected Text messageText;            // Reference to the UI text element for displaying messages

    // Method to be implemented by derived classes
    public abstract void Notify(Subject subject);

    // Set the player and messageText references
    public virtual void SetupObserver(Transform playerTransform, Text messageDisplay)
    {
        player = playerTransform;
        messageText = messageDisplay;
    }

    // Change the access modifier to public to allow ClientObserver to call this method
    public bool IsWithinTriggerDistance()
    {
        if (player == null) return false;
        return Vector3.Distance(transform.position, player.position) <= distanceToTrigger;
    }
}
