using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float transitionSpeed;
    private Vector3 newPos;
    public int points;
    private bool givePoints = true;


    // Start is called before the first frame update
    void Start()
    {
        newPos = new Vector3(1.65f, transform.position.y, transform.position.z);
    }

    // Update is called once per frame
    void Update()
    {
        gameObject.transform.position = Vector3.Lerp(transform.position, newPos, Time.deltaTime * transitionSpeed);
        if(gameObject.transform.position.x <= -1.69)
        {
            newPos = new Vector3(2f, transform.position.y, transform.position.z);
        }
        if (gameObject.transform.position.x >= 1.64)
        {
            newPos = new Vector3(-2f, transform.position.y, transform.position.z);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && givePoints)
        {
            PlayerController.ability += 1;
            Debug.Log(PlayerController.ability);
            ScoreManager.AddPoints(points);
            givePoints = false;
        }
    }

}
