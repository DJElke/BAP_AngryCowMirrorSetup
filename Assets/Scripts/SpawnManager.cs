using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The SpawnManager class.
/// Used to spawn objects into the scene.
/// </summary>
public class SpawnManager : MonoBehaviour
{
    #region Variables

    /// <value> An instance of an ObjectPool object </value>
    public ObjectPool poopPool;

    /// <value> A float variabele for the X-value spawn position </value>
    private float spawnPosX;
    /// <value> A float variabele for the Y-value spawn position </value>
    private float spawnPosY;
    /// <value> A float variabele for the Z-value spawn position </value>
    private float spawnPosZ;

    /// <value> A float variabele which is the delay at the start of the spawning </value>
    private float startDelay = 3;
    /// <value> A float variabele which is the interval during the spawning </value>
    private float spawnInterval = 1.5f;

    #endregion

    #region Standard Methods

    /// <summary>
    /// The Start method.
    /// This method is called before the first frame update.
    /// <para> This method will use the InvokeRepeating(string methodName, float time, float repeatRate) method to spawn the objects. </para>
    /// </summary>
    void Start()
    {
        InvokeRepeating("SpawnPoop", startDelay, spawnInterval);
    }

    #endregion

    #region Custom Methods

    /// <summary>
    /// The SpawnPoop method.
    /// This method will spawn poop objects into the game. We need to set the position for the object.
    /// <para> We need a Vector3 object spawnPos which use the variables spawnPosX/Y/Z. </para>
    /// <para> We make a GameObject for the poop and set the transform.position of that object tot the Vector3 spawnPos we made earlier. </para>
    /// </summary>
    void SpawnPoop()
    {
        spawnPosX = transform.position.x;
        spawnPosY = transform.position.y;
        spawnPosZ = transform.position.z;

        Vector3 spawnPos = new Vector3(spawnPosX, spawnPosY, spawnPosZ);
        //Instantiate(poopPrefab, spawnPos, poopPrefab.transform.rotation);

        GameObject poop = poopPool.GetObject();
        poop.transform.position = spawnPos;
    }

    #endregion
}
