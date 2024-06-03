using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

    public int amountOfBoxes;
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
    public Text labelCountdown;
    [SerializeField] private Dropdown timeVelocityDropdown;
    public int lostClients = 0;
    public int assistedClients = 0;
    public int totalClients = 0;
    public int clientCounter = 0;
    public MetricsAnalyzer metricsAnalyzer;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        // Get the amount of boxes from the player prefs
        amountOfBoxes = PlayerPrefs.GetInt("amountOfBoxes");

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

        // Calculate total clients
        totalClients = lostClients + assistedClients;

        // Check if the game is over
        if (clientCounter == 0 && isOpen == false || Input.GetKeyDown(KeyCode.Escape))
        {
            metricsAnalyzer.SaveData();
            UnityEngine.SceneManagement.SceneManager.LoadScene("EndSim");
        }

    }

    private void FixedUpdate() 
    {
        // Change the time velocity
        switch (timeVelocityDropdown.value)
        {
            case 0:
                Time.timeScale = 1;
                break;
            case 1:
                Time.timeScale = 2;
                break;
            case 2:
                Time.timeScale = 4;
                break;
        }

    }

    private void SpawnEnemy()  //Spawn object (Enemy) function
    {

        if (Random.value <= 0.358)
        {
            clientCounter++;
            totalClients++;
            Instantiate(client, spawnPoint.position, Quaternion.identity);
        }
    }

    private void OnGUI()
    {
        labelCountdown.text = "Remaining time: " + timeRemanining.ToString("F0") + " minutes";
    }


}
