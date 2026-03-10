using System;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public bool hasDied = false;
    private Rigidbody rb;
    public float speed = 3f;
    public bool lastBase = false;


    public int traverseCount = 0;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Base1") && lastBase)
        {
            lastBase = false;
            ScoreIncrease();
        }

        if (other.CompareTag("Base2") && !lastBase)
        {
            lastBase = true;
            ScoreIncrease();
        }
        
    }

    private void ScoreIncrease()
    {
        traverseCount++;
        HUDManager.instance.Score = traverseCount;
    }

    // ABSTRACTION
    private void Move(float value)
    {
        rb.MovePosition(transform.position + Vector3.forward * value * speed * Time.deltaTime);
    }

    public void Die()
    {
        hasDied = true;
        HUDManager.instance.EnableRestart();
    }

    // Update is called once per frame
    void Update()
    {
        if (hasDied) return;

        float move = Input.GetAxis("Vertical");
        Move(move);
    }
}
