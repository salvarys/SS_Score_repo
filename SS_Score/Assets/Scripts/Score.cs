using UnityEngine.UI;
using UnityEngine;

public class Score : MonoBehaviour
{
    public delegate void distanceReached();
    public static event distanceReached OnDistanceReached; 
    
    public Transform player;
    public Text scoreText;
    public Text messageText;
    public int score = 0; 

    void Update() 
    {
        if( player.position.z > 100) {
            
            OnDistanceReached?.Invoke(); 
            score += 1;
            messageText.text = "Score increased! Current Score: " + score;
        }
        


        scoreText.text = player.position.z.ToString("0");
    }
}
