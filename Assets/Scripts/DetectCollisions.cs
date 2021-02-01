using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

/// <summary>
/// The DetectCollisions class.
/// Does what it says. It detects collisions.
/// </summary>
public class DetectCollisions : MonoBehaviour
{

    #region Custom Methods

    /// <summary>
    /// The OnTriggerEnter class.
    /// This method is invoked when the Farmer catches a poop object.
    /// <para> When the farmer catches a poop object, we call the addCatchedPoop method from the GameManager to increase the catchedPoop variable. </para>
    /// </summary>
    /// <param name="other"> We need to recieve a Collider object. </param>
    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("colission detected");
        GameManager.Instance.addCathedPoop();
        //Destroy(other.gameObject);
        gameObject.SetActive(false);
    }

    #endregion

}
