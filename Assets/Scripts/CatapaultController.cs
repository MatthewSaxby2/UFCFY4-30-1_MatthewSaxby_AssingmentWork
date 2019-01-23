using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CatapaultController : MonoBehaviour {

    private float startPoint;
    private float endPoint;
    private float force;
    public float forceMultiplier;
    public Text powerTextDisplay;
    public KeyCode fireButton = KeyCode.Space;


    // Getting the Rigibody of the projectile
    public Rigidbody porjectile;
    void Awake()
    {
        porjectile = gameObject.GetComponent<Rigidbody>();
    }

    void Update ()
    {
        Fire();
        PowerText();
    }

    public void Fire ()
    {

        // when space is pressed down the counter starts
        if (Input.GetKeyDown(fireButton))
        {
            startPoint = Time.time;
        }
        // When space is released the counter stops note that GetKeyDown/GetKeyUp does not do anything while keeping pressed
        if (Input.GetKeyUp(fireButton))
        {
            endPoint = Time.time;
            force = (endPoint - startPoint) * forceMultiplier;  // here you compare the 2 values I had to multiply by 20 to get it up (that's what she says) but you might have to alter this eqution to get what you want        
        }      
        
        // the result is applied to the object rigidbody, only up in this case here again yo need to work it out
        porjectile.AddForce(Vector3.up * force);

        // force is decreased in time to get the object falling down
        force = force * 0.9f;        
        
        // THIS IS FOR DEBUGING
        //Debug.Log("Start: " + startPoint + " End: " + endPoint + " Force: " + force);
    }
    public void PowerText ()
    {
        // Thsi displays the power (or force) being applied to the projctile
        powerTextDisplay.text = force.ToString();
        while (Input.GetKey(fireButton))
        {

        }
    }
}
