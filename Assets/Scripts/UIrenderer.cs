using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIrenderer : MonoBehaviour
{
    [SerializeField] private Text totalClientsText;
    [SerializeField] private Text totalMoneyText;
    [SerializeField] private Text maxQueueTimeText;
    [SerializeField] private Text maxBoxesTimeText;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private MetricsAnalyzer metricsAnalyzer;

    // Start is called before the first frame update
    void Start()
    {
        totalClientsText = GameObject.Find("TotalClients").GetComponent<Text>();
        totalMoneyText = GameObject.Find("TotalMoney").GetComponent<Text>();
        maxQueueTimeText = GameObject.Find("MaxQueueTime").GetComponent<Text>();
        maxBoxesTimeText = GameObject.Find("MaxBoxesTime").GetComponent<Text>();
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        metricsAnalyzer = GameObject.Find("Metrics").GetComponent<MetricsAnalyzer>();
    }

    // Update is called once per frame
    void Update()
    {
        UpdateTexts();
    }

    private void UpdateTexts()
    {
        float maxQueueTime = Mathf.Max(metricsAnalyzer.waitTimes.ToArray()); 
        float maxBoxesTime = Mathf.Max(metricsAnalyzer.waitBoxes.ToArray());
        totalClientsText.text = "Total Clients: " + gameManager.totalClients;
        totalMoneyText.text = "Total Money: " + (metricsAnalyzer.totalMoneyBox + metricsAnalyzer.totalMoneyLostClient) + "$";
        maxQueueTimeText.text = "Max Queue Time: " + maxQueueTime + "min"; ;
        maxBoxesTimeText.text = "Max Boxes Time: " + maxBoxesTime + "min";
    }
}
