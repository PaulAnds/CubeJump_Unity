using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    #region "Variables"
    public float transitionSpeed;
    private Vector3 newPos;
    public int points;
    private bool givePoints = true;
    private PlayerController player;
    #endregion

    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerController>();
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
        if (player.powerJump)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Player" && givePoints)
        {
            PlayerController.ability += 1;
            PlayerController.pill = 0;
            ScoreManager.AddPoints(points);
            givePoints = false;
        }
    }

}
