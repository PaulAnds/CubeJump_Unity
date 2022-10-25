using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shovel : MonoBehaviour
{

    public PlayerController player;
    public GameObject TargetFollow;

    private void Start()
    {
        TargetFollow = GameObject.Find("Player");
        player = FindObjectOfType<PlayerController>();
    }

    private void Update()
    {
        if (TargetFollow)
        {
            transform.position = new Vector3(0, TargetFollow.transform.position.y + 6.0f, 0);
        }
    }

    private void OnTriggerEnter(Collider _other)
    {

        if (player.powerJump)
        {

            if (_other.tag == "Obstacle")
            {
                Debug.Log("destroy Obstacle");
                Destroy(_other.gameObject);
            }

            if (_other.tag == "Enemy")
            {
                Debug.Log("destroy Enemy");
                Destroy(_other.gameObject);
            }

        }
    }
}
