using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnWalls : MonoBehaviour
{
    [Header("The Prefab of the wall that will be instanciated")]
    public GameObject Wall;
    [Header("The time the last tile will be removed")]
    public float timeToDestroy = 2f;

    [SerializeField]
    private Factory Factory;

    private Vector3 nextPosition;
    private bool spawn;

    void Start()
    {//makes spawn true in order to get into de trigger to spawn the next one
        spawn = true;
        Factory = FindObjectOfType<Factory>();
    }
    private void Update()
    {
        if (!spawn)
        {//Destroying the las tile
            Destroy(gameObject, timeToDestroy);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Spawn" && spawn)
        {//when player gets to the trigger spawn next tile once
            //Debug.Log("Spawning next tile");
            var inst = Factory.GetNewInstance();
            nextPosition = new Vector3(transform.position.x, transform.position.y + 11.13881f, transform.position.z);
            inst.transform.position = nextPosition;
            spawn = false;
        }
    }
}