using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnvironmentManager : MonoBehaviour
{
    
    #region Variables

    /// <value> Integer to set the amount of catched objects </value>
    private int catchedPoop;
    /// <value> Integer to set the amount of missed objects </value>
    private int missedPoop;

    /// <value> Bool to know if the first level is completed </value>
    private bool firstCompleted = false;

    /// <value> Instance of the Farmer GameObject </value>
    [SerializeField]
    private GameObject farmer;
    /// <value> Material object </value>
    [SerializeField]
    private Material blue;

    /// <value> The renderer </value>
    private Renderer rend;

    #endregion

    #region Standard Methods

    /// <summary>
    /// The Start method.
    /// Gets the renderer and sets the enabled property of this render on true.
    /// </summary>
    void Start()
    {
        rend = farmer.GetComponent<Renderer>();
        rend.enabled = true;
    }

    /// <summary>
    /// The Update method.
    /// Updates the environment.
    /// <para> We need to recieve the catchedPoop and missedPoop data from the GameManager. </para>
    /// <para> If the catchedPoop integer is equal to five and the firstCompleted boolean is false then we change the color of the Farmer's outfit. </para>
    /// </summary>
    void Update()
    {
        catchedPoop = GameManager.Instance.getCatchedPoop();
        missedPoop = GameManager.Instance.getMissedPoop();

        if(catchedPoop == 5 && !firstCompleted)
        {
            Debug.Log("clothes changed!");
            var mats = rend.materials;
            mats[1] = blue;
            rend.materials = mats;
            firstCompleted = true;
        }
    }

    #endregion

}
