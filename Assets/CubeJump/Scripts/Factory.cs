using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Factory : MonoBehaviour
{
    #region "Variables"
    public GameObject prefab;
    public GameObject prefab2;
    public GameObject prefab3;
    public GameObject prefab4;
    public GameObject background;
    int randomInt;
    #endregion

    public GameObject GetNewInstance()
    {
        randomInt = Random.Range(0, 4);

        if (randomInt == 0)
        {
            return Instantiate(prefab);
        }
        if (randomInt == 1)
        {
            return Instantiate(prefab2);
        }
        if (randomInt == 2)
        {
            return Instantiate(prefab3);
        }
        if (randomInt == 3)
        {
            return Instantiate(prefab4);
        }

        return Instantiate(background);

    }
}
