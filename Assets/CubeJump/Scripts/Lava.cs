using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lava : MonoBehaviour
{

    private Rigidbody rb;
    public float lavaSpeed;
    public PlayerController player;

    private float rate;

    // Start is called before the first frame update
    void Start()
    {
        rate = 0f;
        lavaSpeed = 3f;
        player = FindObjectOfType<PlayerController>();
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        rate = rate + 0.0001f;
        rb.velocity = new Vector3(0, 1, 0) * lavaSpeed * rate; ;

        if (player.SpeedJump)
        {
            rb.velocity = new Vector3(0, 20, 0);
        }
    }

}
