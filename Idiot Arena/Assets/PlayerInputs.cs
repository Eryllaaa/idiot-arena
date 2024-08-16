using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using Unity.Netcode;

public class PlayerInputs : NetworkBehaviour
{
    public GameObject playerObject;

    PlayerController playerController;
    CameraManager cameraManager;

    void Start()
    {
        playerController = playerObject.GetComponent<PlayerController>();
        cameraManager = playerObject.GetComponent<Player>().cameraHolder.GetComponent<CameraManager>();
    }

    void Update()
    {
        if (!playerObject.GetComponent<Player>().playerPrefab.GetComponent<PlayerNetworkManager>().IsOwner) {
            return;
        }
        Inputs();
    }

    private void Inputs() {
        if (Input.GetMouseButton((int)MouseButton.Right)) {
            playerController.OnRightClick();
        }
        if (Input.GetKeyDown(KeyCode.Y)) {
            cameraManager.FollowToggle();
        }
        if (Input.GetKeyDown(KeyCode.Space)) {
            cameraManager.SetSnapToPlayer();
        }
        else if (Input.GetKeyUp(KeyCode.Space)){
            cameraManager.StopSnapToPlayer();
        }
    }
}
