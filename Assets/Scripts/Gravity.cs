using NUnit.Framework;
using System.Collections.Generic; // for List
using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f; // Gravitational constant 6.674 force in Universe
    // Array for containing all the items
    public static List<Gravity> gravityObjectList;

    // Set speed for orbiting the planet
    [SerializeField] bool planet = false; // if it's not a planet = orbit
    [SerializeField] int oribitSpeed = 1000;
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        if (gravityObjectList == null) { 
        gravityObjectList = new List<Gravity>();
        }// if not created then create first
        gravityObjectList.Add(this);

        // orbiting
        if (!planet)
        {
            rb.AddForce(Vector3.left * oribitSpeed);
        }// End if not a planet
    }//End Awake

    private void FixedUpdate()
    {
        // Use Planet in each Array that contatin gravity attract each other
        foreach (var obj in gravityObjectList)
        { 
         if (obj != this) 
            {
                Attract(obj);
            }// end if for Attract other not yourself!
        }
    }// End FixedUpdate

    void Attract(Gravity other)
    { 
     Rigidbody otherRb = other.rb;
     
        // Distance = PositionA - PositionB
        Vector3  direction = rb.position - other.rb.position;
        float distance = direction.magnitude; // magnitude use to tell only distance
        float forceMagnitude = G * ((rb.mass * otherRb.mass) / Mathf.Pow(distance, 2));
        Vector3 finalForce = forceMagnitude * direction.normalized; // normalize use to tell direction
        // addforce with direction!
        otherRb.AddForce(finalForce);
    }// End Method Attract
}// End Gravity
