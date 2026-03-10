using System;
using UnityEngine;

public class Truck : Vehicle // INHERITANCE
{
    // POLYMORPHISM
    protected override void GetImpact(Collision c)
    {
        Vector3 toPlayer = c.transform.position - transform.position;
        c.rigidbody.AddForce(toPlayer.normalized * impactForce, ForceMode.Impulse);
    }
}
