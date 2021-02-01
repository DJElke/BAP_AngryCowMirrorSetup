using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The Object Pool class.
/// This class instantiates prefabs beforehand.
/// </summary>
public class ObjectPool : MonoBehaviour
{
    #region Variables

    /// <value> An instance of the GameObject </value>
    public GameObject objectPrefab;
    /// <value> An integer to set the size of the pool </value>
    public int poolSize;
    /// <value> A list of the GameObjects to pool </value>
    private List<GameObject> objectPool = new List<GameObject>();

    #endregion

    #region Standard Methods

    /// <summary>
    /// The Start method.
    /// This method will fill the pool with GameObjects.
    /// <para> The CreateNewObject method is called as much times of the size set in the poolSize variable. </para>
    /// </summary>
    void Start()
    {
        for (int x = 0; x < poolSize; x++)
        {
            CreateNewObject();
        }
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// The CreateNewObject method.
    /// This method will instantiate a new prefab of the desired object to pool.
    /// </summary>
    /// <returns>The CreateNewObject method returns a GameObject</returns>
    private GameObject CreateNewObject()
    {
        GameObject obj = Instantiate(objectPrefab);
        obj.SetActive(false);
        objectPool.Add(obj);
        return obj;
    }

    //find an object that's not active
    //make a new one if there are none
    //set it to active
    /// <summary>
    /// The GetObject method.
    /// This method will find a GameObject that's not active.
    /// <para> If the method doesn't find any active GameObjects, it will invoke the method CreateNewObject and set the newly made object to active. </para>
    /// </summary>
    /// <returns>The GetObject method returns a GameObject</returns>
    public GameObject GetObject()
    {
        GameObject obj = objectPool.Find(x => x.activeInHierarchy == false);
        if (obj == null)
        {
            obj = CreateNewObject();
        }
        obj.SetActive(true);
        return obj;
    }

    #endregion
}
