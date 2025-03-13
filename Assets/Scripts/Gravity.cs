using UnityEngine;

public class Gravity : MonoBehaviour
{
    Rigidbody rb;
    const float G = 0.006674f; // Gravitational constant 6.674 force in Universe

    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
    }
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
