using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EndgameManager : MonoBehaviour
{

    private int totalClients;
    private int lostClients;
    private int assistedClients;
    private float totalMoneyBox;
    private float totalMoneyLostClient;
    private float totalMoney;
    private float maxQueueTime;
    private float minQueueTime;
    private float maxBoxesTime;
    private float minBoxesTime;

    //UI
    Text totalClientsText;
    Text lostClientsText;
    Text assistedClientsText;
    Text totalMoneyBoxText;
    Text totalMoneyLostClientText;
    Text totalMoneyText;
    Text maxQueueTimeText;
    Text minQueueTimeText;
    Text maxBoxesTimeText;
    Text minBoxesTimeText;
    public Button menuButton;
    public Button exitButton;


    // Start is called before the first frame update
    void Start()
    {
        totalClientsText = GameObject.Find("TotalClients").GetComponent<Text>();
        lostClientsText = GameObject.Find("LostClients").GetComponent<Text>();
        assistedClientsText = GameObject.Find("AssistedClients").GetComponent<Text>();
        totalMoneyBoxText = GameObject.Find("TotalMoneyBox").GetComponent<Text>();
        totalMoneyLostClientText = GameObject.Find("TotalMoneyLostClient").GetComponent<Text>();
        totalMoneyText = GameObject.Find("TotalMoney").GetComponent<Text>();
        maxQueueTimeText = GameObject.Find("MaxQueueTime").GetComponent<Text>();
        minQueueTimeText = GameObject.Find("MinQueueTime").GetComponent<Text>();
        maxBoxesTimeText = GameObject.Find("MaxBoxesTime").GetComponent<Text>();
        minBoxesTimeText = GameObject.Find("MinBoxesTime").GetComponent<Text>();

        // Load data
        totalClients = PlayerPrefs.GetInt("totalClients");
        lostClients = PlayerPrefs.GetInt("lostClients");
        assistedClients = PlayerPrefs.GetInt("assistedClients");
        totalMoneyBox = PlayerPrefs.GetFloat("totalMoneyBox");
        totalMoneyLostClient = PlayerPrefs.GetFloat("totalMoneyLostClient");
        totalMoney = PlayerPrefs.GetFloat("totalMoney");
        maxQueueTime = PlayerPrefs.GetFloat("maxQueueTime");
        minQueueTime = PlayerPrefs.GetFloat("minQueueTime");
        maxBoxesTime = PlayerPrefs.GetFloat("maxBoxesTime");
        minBoxesTime = PlayerPrefs.GetFloat("minBoxesTime");

        UpdateText();
        
    }

    private void UpdateText()
    {
        totalClientsText.text = "Clientes totales: " + totalClients.ToString();
        lostClientsText.text = "Clientes perdidos: " + lostClients.ToString();
        assistedClientsText.text = "Clientes asistidos: " + assistedClients.ToString();
        totalMoneyBoxText.text = "Dinero cajas perdido: " + totalMoneyBox.ToString("0.00") + "$";
        totalMoneyLostClientText.text = "Dinero clientes perdido: " + totalMoneyLostClient.ToString("0.00") + "$";
        totalMoneyText.text = "Dinero total: " + totalMoney.ToString("0.00") + "$";
        maxQueueTimeText.text = "Tiempo maximo cola: " + maxQueueTime.ToString("0.00") + "min";
        minQueueTimeText.text = "Tiempo minimo cola: " + minQueueTime.ToString("0.00") + "min";
        maxBoxesTimeText.text = "Tiempo maximo cajas: " + maxBoxesTime.ToString("0.00") + "min";
        minBoxesTimeText.text = "Tiempo minimo cajas: " + minBoxesTime.ToString("0.00") + "min";
    }

    public void OnMenuButton()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene("Menu");
    }

    public void OnExitButton()
    {
        Application.Quit();
    }
}
