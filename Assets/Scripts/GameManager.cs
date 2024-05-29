using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int amountOfBoxes = 5;
    [SerializeField]
    private BoxManager boxManager;
    public List<GameObject> boxesToActivate;
    public Transform spawnPoint;
    public GameObject client;
    [SerializeField] float spawnTime = 1f; //timeframe variable
    private float tempCounter = 0f; //timeframe temp variable
    [SerializeField]
    private bool isOpen = true;  
    public float timeRemanining = 60*4; //timeframe variable

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Limit the Amount of Boxes to max 10 and min 1
        amountOfBoxes = Mathf.Clamp(amountOfBoxes, 1, 10);

        // Wait for the box manager to be initialized
        yield return new WaitUntil(() => boxManager.IsInitialized == true);

        boxesToActivate = boxManager.getBoxes(amountOfBoxes);

        foreach (GameObject box in boxesToActivate)
        {
            // Get child of the box
            GameObject activatedSprite = box.transform.GetChild(0).gameObject;
            GameObject deactivatedSprite = box.transform.GetChild(1).gameObject;

            // Activate the sprite
            activatedSprite.SetActive(true);
            // Deactivate the sprite
            deactivatedSprite.SetActive(false);

            // Set the box to be activated
            box.GetComponent<BoxBehaviour>().isActivated = true;
        }
    }

    // Update is called once per frame
    void Update()
    {
        // Open time management
        if (timeRemanining <= 0)
        {
            timeRemanining = 0;
            isOpen = false;
        }
        else
        {
            timeRemanining -= Time.deltaTime;
        }

        // Spawn time management
        if (tempCounter <= 0f && isOpen)  //check if the counter equals 0
        {
            SpawnEnemy();  //spawn the object
            tempCounter = spawnTime;  //reset the timer or cd
        }
        else
        {
            tempCounter -= Time.deltaTime;  //take down time 
        }

    }
    private void SpawnEnemy()  //Spawn object (Enemy) function
    {

        if (Random.value <= 0.358)
        {
            Instantiate(client, spawnPoint.position, Quaternion.identity);
        }
    }
}
