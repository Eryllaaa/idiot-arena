using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Unity.Netcode;

public class PlayerNetworkManager : NetworkBehaviour
{
    public GameObject player;
    public GameObject cameraHolder;

    void Start()
    {
        
    }

    void Update()
    {
        
    }

    public override void OnNetworkSpawn() {
        if (!IsOwner) {
            enabled = false;
            player.GetComponent<Player>().enabled = false;
            player.GetComponent<PlayerController>().enabled = false;
            player.GetComponent<PlayerInputs>().enabled = false;
            cameraHolder.SetActive(false);
            return;
        }
    }
}
