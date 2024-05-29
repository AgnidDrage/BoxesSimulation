
using System.Collections.Generic;
using UnityEngine;

public class MetricsAnalyzer : MonoBehaviour
{

    public GameManager gameManager;
    private float moneyPerBox = 1000f;
    public float totalMoneyBox;
    private float moneyPerLostClient = 10000f;
    public float totalMoneyLostClient;

    // Lists
    public List<float> waitTimes = new List<float>();
    public List<float> waitBoxes = new List<float>();

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        totalMoneyBox = PlayerPrefs.GetInt("amountOfBoxes") * moneyPerBox;
    }

    // Update is called once per frame
    void Update()
    {
        totalMoneyLostClient = gameManager.lostClients * moneyPerLostClient;
    }

    public void SaveData()
    {
        float maxQueueTime = Mathf.Max(waitTimes.ToArray());
        float minQueueTime = Mathf.Min(waitTimes.ToArray());
        float MaxBoxesTime = Mathf.Max(waitBoxes.ToArray());
        float MinBoxesTime = Mathf.Min(waitBoxes.ToArray());

        PlayerPrefs.SetInt("totalClients", gameManager.totalClients);
        PlayerPrefs.SetInt("lostClients", gameManager.lostClients);
        PlayerPrefs.SetInt("assistedClients", gameManager.assistedClients);
        PlayerPrefs.SetFloat("totalMoneyBox", totalMoneyBox);
        PlayerPrefs.SetFloat("totalMoneyLostClient", totalMoneyLostClient);
        PlayerPrefs.SetFloat("totalMoney", totalMoneyBox + totalMoneyLostClient);
        PlayerPrefs.SetFloat("maxQueueTime", maxQueueTime);
        PlayerPrefs.SetFloat("minQueueTime", minQueueTime);
        PlayerPrefs.SetFloat("maxBoxesTime", MaxBoxesTime);
        PlayerPrefs.SetFloat("minBoxesTime", MinBoxesTime);
    }
}
