using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectActiveScript : MonoBehaviour

{
    public int AmountTargets; //hoeveelheid targets
    public int AmountDestroyed; //hoeveelheid kapotte targets

    public GameObject CubeDoor;


    public void OpenDoor() //functie die je aanroept om de deur te laten verdwijnen
    {
        gameObject.SetActive(false);
    }

    public void CheckIfAllDestroyed()
    {
        if (AmountTargets == AmountDestroyed)
        {
            CubeDoor.SetActive(true);
        }
    }
}
