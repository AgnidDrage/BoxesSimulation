using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{

    public int amountOfBoxes = 5;
    [SerializeField]
    private BoxManager boxManager;
    public List<GameObject> boxesToActivate;

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
        
    }
}
