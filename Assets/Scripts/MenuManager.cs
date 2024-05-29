
using UnityEngine;
using UnityEngine.UI;

public class MenuManager : MonoBehaviour
{
    [SerializeField] private Dropdown dropdown;

    public UnityEngine.UI.Button startButton;


    public void StartSimulation()
    {
        // Get the value of the dropdown menu
        int value = dropdown.value;
        // Set the amount of boxes to the value of the dropdown menu
        int amountOfBoxes = value + 1;
        // Save the amount of boxes to the player prefs
        PlayerPrefs.SetInt("amountOfBoxes", amountOfBoxes);
        // Load the game scene
        UnityEngine.SceneManagement.SceneManager.LoadScene("Simulation");
    }
}
