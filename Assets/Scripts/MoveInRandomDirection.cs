using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// The MoveInRandomDirection class.
/// This class will move a object in a random direction.
/// </summary>
public class MoveInRandomDirection : MonoBehaviour
{
    #region Variables

    /* SPEED VARIABLES */
    /// <value> Float to set the desired speed of the movement </value>
    public float speed = 1.0f;

    /// <value> An object of Vector3 for the target position </value>
    private Vector3 targetPosition;

    /* TARGET VARIABLES */
    /// <value> Float to set te x-range of the target </value>
    private float targetRangeX = 6.0f; //6.0
    /// <value> Float to set the minimum y-range of the target </value>
    private float targetRangeMinY = 3.0f;
    /// <value> Float to set the maximum y-range of the target </value>
    private float targetRangeMaxY = 8.0f;
    /// <value> Float to set the z-position of the target </value>
    private float targetPosZ = -4.0f;

    #endregion

    #region Standard Methods

    /// <summary>
    /// The Start method.
    /// Sets the targetPosition to a new Vector 3 object with the target variables.
    /// </summary>
    void Start()
    {
        targetPosition = new Vector3(Random.Range(-targetRangeX, targetRangeX), Random.Range(targetRangeMinY, targetRangeMaxY), targetPosZ);
    }

    /// <summary>
    /// The Update method.
    /// Transforms the position so the objects move.
    /// </summary>
    void Update()
    {
        //transform.Translate(Vector3.forward*Time.deltaTime*speed);
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
    }

    #endregion
}
