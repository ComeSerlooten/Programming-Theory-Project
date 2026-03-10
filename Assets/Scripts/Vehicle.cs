using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vehicle : MonoBehaviour
{
    protected Rigidbody rb;
    public Vector3 direction;
    public float speed;

    public float collisionTimeDeath = 5f;
    public bool hasCollided = false;

    public float impactForce = 10f;

    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    protected void OnCollisionEnter(Collision collision)
    {
        if (!collision.gameObject.CompareTag("Vehicle") && !collision.gameObject.CompareTag("Player")) return;
        StartCoroutine(DeletePostCollision());
        hasCollided = true;

        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<PlayerController>().Die(); //ABSTRACTION
            GetImpact(collision);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Destroyer")) Destroy(this.gameObject);
    }

    protected virtual void GetImpact(Collision c)
    {
        Vector3 toPlayer = c.transform.position - transform.position;
        c.rigidbody.AddExplosionForce(impactForce, c.contacts[0].point, 1, .5f, ForceMode.Impulse);
    }
    
    IEnumerator DeletePostCollision()
    {
        yield return new WaitForSeconds(collisionTimeDeath);
        Destroy(this.gameObject);
    }
    
    protected virtual void Move()
    {
        rb.MovePosition(transform.position + direction * (speed * Time.deltaTime));
    }

    // POLYMORPHISM
    protected virtual void Move(Vector3 _dir)
    {
        rb.MovePosition(transform.position + _dir * (speed * Time.deltaTime));
    }
    
    // Update is called once per frame
    protected virtual void Update()
    {
        if (!hasCollided)
        {
            Move();
        }
    }
}