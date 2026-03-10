using UnityEngine;

public class Bike : Vehicle // INHERITANCE
{
    public float waveAmplitude = 1f;
    public float waveSpeed = 1f;
    private float time = 0;

    private Vector3 offset;

    // POLYMORPHISM
    protected override void Move()
    {
        base.Move();

        Vector3 sinePos = -offset;

        float sine = Mathf.Sin(time * waveSpeed) * waveAmplitude;
        offset = transform.forward * sine;
        sinePos += offset;

        rb.MovePosition(rb.position + sinePos);
    }

    // POLYMORPHISM
    // Update is called once per frame
    protected override void Update()
    {
        base.Update();
        
        time += Time.deltaTime;
    }
}
