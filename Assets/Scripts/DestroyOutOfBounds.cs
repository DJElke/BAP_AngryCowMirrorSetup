using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOutOfBounds : MonoBehaviour
{
    
    #region Variables

    /// <value> A float which sets the bound </value>
    private float bound = -4.0f;

    #endregion

    #region Standard Methods

    /// <summary>
    /// The Update method.
    /// This method will destroy the poop objects when they have passed the farmer.
    /// <para> This method will also invoke the addMissedPoop method from the GameManager to increase the missedPoop variable. </para>
    /// </summary>
    void Update()
    {
        //if the poop is behind the farmer, destroy the poop
        if (transform.position.z <= bound)
        {
            GameManager.Instance.addMissedPoop();
            //Destroy(gameObject);
            gameObject.SetActive(false);
        }
    }

    #endregion
}
