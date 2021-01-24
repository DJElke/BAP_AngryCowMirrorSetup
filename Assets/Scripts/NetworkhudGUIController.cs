using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using Mirror;

[DisallowMultipleComponent]
[RequireComponent(typeof(NetworkManager))]
public class NetworkhudGUIController : MonoBehaviour
{
    // We need an instance to the Networkmanager to be able to use it
    NetworkManager manager;

    // When the script is called, get the networkmanager
    public void Awake()
    {
        manager = GetComponent<NetworkManager>();
    }

    // When btnCow is clicked, make the cow the host
    public void cowClicked()
    {
        if(!NetworkClient.active)
        {
            if(Application.platform != RuntimePlatform.WebGLPlayer)
            {
                manager.StartHost();
            }
            Debug.Log("host connected");
        }
    }

    // When btnFarmer is clicked, make the farmer the host
    public void farmerClicked()
    {
        if(!NetworkClient.active)
        {
            manager.StartClient();
            Debug.Log("client connected");
        }
    }

}
