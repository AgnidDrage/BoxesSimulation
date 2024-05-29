using System;
using System.Collections.Generic;
using UnityEngine;

public class BoxManager : MonoBehaviour
{
    private List<GameObject> boxes = new List<GameObject>();
    public bool IsInitialized { get; private set;} = false;
    static System.Random rnd = new System.Random(DateTime.Now.Millisecond);


    private void Start()
    {
        // Get all direct child objects
        foreach (Transform child in transform)
        {
            // Add boxes to the list
            boxes.Add(child.gameObject);
        }
        IsInitialized = true;
    }

    public List<GameObject> getBoxes(int count)
    {
        List<GameObject> randomBoxes = new List<GameObject>();
        for (int i = 0; i < count; i++)
        {
            // Get a random box
            int randomIndex = rnd.Next(boxes.Count);
            GameObject randomBox = boxes[randomIndex];
            // Remove the box from the list
            boxes.RemoveAt(randomIndex);
            // Add the box to the list
            randomBoxes.Add(randomBox);
        }
        return randomBoxes;
    }

}