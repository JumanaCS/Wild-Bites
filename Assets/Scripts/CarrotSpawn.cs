using UnityEngine;
using UnityEngine.UI;

public class CarrotSpawn : MonoBehaviour
{
    public GameObject carrotSlices;
    public float spawnIncrement = 2f; 
    public float currentXPoisition = 8.32f;

    private bool isSpawn = true;

    public Vector3 spawnRotation = new Vector3(0f,180f,0f);
    void Update()
    {
        if (Input.GetKey(KeyCode.Space) && isSpawn)
            {

            Vector2 spawnPosition = new Vector2(currentXPoisition,-0.17f);

            Quaternion rotation = Quaternion.Euler(spawnRotation);

            Instantiate(carrotSlices, spawnPosition, rotation);

            currentXPoisition += spawnIncrement;

            isSpawn = false;

            Invoke("EnableSpawn", 0.1f);

        }
    }

    void EnableSpawn()
    {
        isSpawn = true;
    }
}


