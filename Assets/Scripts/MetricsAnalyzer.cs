
using UnityEngine;

public class MetricsAnalyzer : MonoBehaviour
{

    public GameManager gameManager;
    private float moneyPerBox = 1000f;
    public float totalMoneyBox;
    private float moneyPerLostClient = 10000f;
    public float totalMoneyLostClient;

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
}
