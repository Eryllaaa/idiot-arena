using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Globalization;

public class PlayerController : MonoBehaviour
{
    public GameObject playerObject;
    public NavMeshAgent navMeshAgent;

    Camera cam;

    void Start()
    {
        cam = playerObject.GetComponent<Player>().cameraHolder.GetComponent<Camera>();
    }

    public void OnRightClick() {
        if (Input.GetMouseButtonDown(1)) {
            Ray movePosition = cam.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(movePosition, out RaycastHit hitInfo)) {
                navMeshAgent.SetDestination(hitInfo.point);
            }
        }
    }
}
