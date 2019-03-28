using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeDoorScript : MonoBehaviour
{
    public float health = 10f; //health variable, 50f is amount of hp


    public ObjectActiveScript Door; //variable voor de deur

    private void Start()
    {
        gameObject.SetActive(false);
    }

    public void TakeDamage(float amount) //because you need to call it from another class, you make the void public. The float amount is a function we want to give an argument, it's a way to feed data in to a function, in case we want to specify a certain amount of dmg
    {
        health -= amount; //subtracts amount of our health, amount is going to be equal to the dmg of our gun
        if (health <= 0f) // if health is equal or less than 0, the enemy dies/object gets destroyed
        {
            Die(); //make a separate function for Die()
        }
    }

    //Here we make the function working
    private void Die()
    {
        Door.OpenDoor();
        Debug.Log("die");
        Destroy(gameObject); //with this we destroy the object
    }

    
}
