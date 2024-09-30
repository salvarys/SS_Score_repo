using UnityEngine;

public class Spawner : Observer
{
    public GameObject objectToSpawn;
    public int numberOfObjects = 3;

    public override void Notify(Subject subject)
    {
        if (IsWithinTriggerDistance())
        {
            for (int i = 0; i < numberOfObjects; i++)
            {
                Instantiate(objectToSpawn, new Vector3(Random.Range(-10, 10), 1, Random.Range(-10, 10)), Quaternion.identity);
            }
            messageText.text = "Objects spawned!";
        }
    }
}
