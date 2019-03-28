using UnityEngine;

public class GunScript : MonoBehaviour
{
    //variables for gun
    public float damage = 10f; //amount of damage
    public float range = 100f; //optional, range of the distance you can hit objects/enemies
    public float fireRate = 15f; //limits the amount of times you can fire
    public float impactForce = 50f; //variable for the force you're going to use for the rigidbody

    public Camera fpsCam; //reference to Shoot(), from where you're shooting (main camera)
    public ParticleSystem muzzleFlash; //code for our particlesystem
    public GameObject impactEffect; //code for the effect impact

    private float nextTimeToFire = 0f; //made so we can fire right off the bat

    // Update is called once per frame
    void Update()
    {
        //if (Input.GetButtonDown("Fire1") && Time.time >= nextTimeToFire) //if you press left mousebutton, you will hit an object. Fire1 is a default button set up by Unity
        if (Input.GetButton("Fire1") && Time.time >= nextTimeToFire) //if you press left mousebutton, you will hit an object. Fire1 is a default button set up by Unity. Removed the down, so you can hold down the button to continuously fire
            {
            nextTimeToFire = Time.time + 1f / fireRate; //makes us shoot with an interval, the greater the fire rate the less time between shots
            Shoot(); //shooting code, make separate function
        }
    }

    void Shoot() //shooting code, this is what happens when you press left mousebutton
    {
        muzzleFlash.Play(); //let's our particle system play when we shoot

        //Shoot method, what we hit with ouy ray
        RaycastHit hit; 
        // if statement checks if it hits something. Everything between the curly brackets only occures if the statement is true
        if (Physics.Raycast(fpsCam.transform.position, fpsCam.transform.forward, out hit, range)) //shoot a ray, starting out at the position of our camera. Shoot it at the direction we are facing. out hit can gather information.
        {
            //you need colliders to check if you hit the object, otherwise the code won't see it
            Debug.Log(hit.transform.name); //checks if you hit something and gives you feedback in the console log

            Target target = hit.transform.GetComponent<Target>(); //We are going to find the target component on the object that we hit, we also made a variable named target, because not all objects that we hit are going to have a targetscript sitting on them. We don't want to shatter all items in the game.
            if (target != null) //check if we find a target component, we only want to do this if we actually have found a component
            {
                target.TakeDamage(damage); //We can only add TakeDamage because we made the function public, we use our damage variable to set the amount of dmg
            }

            if (hit.rigidbody != null) //checks if it hits the rigidbody (of the bag)
            {
                hit.rigidbody.AddForce(-hit.normal * impactForce); //the - makes the object go backwards
            }

            CubeDoorScript DoorTarget = hit.transform.GetComponent<CubeDoorScript>(); //We are going to find the target component on the object that we hit, we also made a variable named target, because not all objects that we hit are going to have a targetscript sitting on them. We don't want to shatter all items in the game.
            if (DoorTarget != null) //check if we find a target component, we only want to do this if we actually have found a component
            {
                DoorTarget.TakeDamage(damage); //We can only add TakeDamage because we made the function public, we use our damage variable to set the amount of dmg
            }

            GameObject impactGO = Instantiate(impactEffect, hit.point, Quaternion.LookRotation(hit.normal)); // we make this so the impact only occurs when you shoot
            Destroy(impactGO, 2f); //says that the gameobject is destroyed after 2 seconds
        }
    }
}
