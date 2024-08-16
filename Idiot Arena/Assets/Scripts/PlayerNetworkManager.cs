using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetworkManager : NetworkBehaviour
{
    public GameObject playerObject;
    public GameObject cameraHolder;

    void Start()
    {
        for (int i = 0; i < gameObject.transform.childCount; i++) {
            if (!gameObject.transform.GetChild(i).name.Contains("Camera")) {
                playerObject = gameObject.transform.GetChild(i).gameObject;
            }
        }
        cameraHolder.GetComponent<CameraManager>().Ready();
    }

    void Update()
    {
        
    }

    public override void OnNetworkSpawn() {
        if (!IsOwner) {
            enabled = false;
            playerObject.GetComponent<Character>().enabled = false;
            playerObject.GetComponent<CharacterController>().enabled = false;
            cameraHolder.SetActive(false);
            return;
        }
    }
}
