using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using System.Globalization;

public class CharacterController : MonoBehaviour
{
    public NavMeshAgent navMeshAgent;

    Camera cam;

    void Start()
    {
    }

    public void Ready() {
        cam = gameObject.GetComponent<Character>().cameraHolder.GetComponent<Camera>();
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
