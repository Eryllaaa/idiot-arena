using System.Globalization;
using UnityEngine;
using Unity.Netcode;
using UnityEngine.SceneManagement;

public class CameraManager : MonoBehaviour
{
    public GameObject playerObject;
    Transform playerTransform;

    public readonly Vector3 cameraStartPos = new Vector3(0, 10, -12);
    Vector3 cameraOffset = new Vector3(0, 0, -6);

    public int FreeCamMouseMargin = 10;
    public float freeCamSpeedX = 25;
    public float freeCamSpeedY = 15;
    public float cameraSmoothing = 6f;

    private delegate void FollowState();
    private FollowState followState;

    private FollowState previousState;

    void Start()
    {
        playerTransform = playerObject.transform;
        playerTransform = gameObject.transform.parent.GetChild(0).transform;
        
        followState = Following;
        gameObject.transform.position = cameraStartPos;
    }
    
    void Update() {
        DoAction();
    }

    private void DoAction() {
        followState();
    }

    public void FollowToggle() {
        if (followState == Following) {
            SetFreeCam();
        }
        else if (followState == FreeCam) {
            SetFollowing();
        }
        else if (followState == SnapToPlayer) {
            SetFreeCam();
        }
    }

    private void Following() {
        gameObject.transform.position = EaseInOutMovement(gameObject.transform.position - cameraOffset, playerTransform.position) + cameraOffset;
        gameObject.transform.position = new Vector3(gameObject.transform.position.x, cameraStartPos.y, gameObject.transform.position.z);
    }

    private Vector3 EaseInOutMovement(Vector3 cameraPosition, Vector3 playerPosition) {
        return Vector3.Lerp(cameraPosition, playerPosition, cameraSmoothing * Time.deltaTime);
    }

    private void FreeCam() {
        Vector3 camVelocity = new Vector3();
        if (Input.mousePosition.x >= Screen.width + FreeCamMouseMargin) {
            camVelocity += new Vector3(freeCamSpeedX, 0, 0);
        }
        else if (Input.mousePosition.x <= FreeCamMouseMargin) {
            camVelocity -= new Vector3(freeCamSpeedX, 0, 0);
        }
        if (Input.mousePosition.y >= Screen.height + FreeCamMouseMargin) {
            camVelocity += new Vector3(0, 0, freeCamSpeedY);
        }
        else if (Input.mousePosition.y <= FreeCamMouseMargin) {
            camVelocity -= new Vector3(0, 0, freeCamSpeedY);
        }
        gameObject.transform.position += camVelocity * Time.deltaTime;
    }

    private void SnapToPlayer() {
        Following();    
    }
    public void StopSnapToPlayer() {
        if (previousState == null) {
            return;
        }
        followState = previousState;
    }

    public void SetSnapToPlayer() {
        if (followState == FreeCam) {
            previousState = FreeCam;
        }
        else {
            previousState = null;
        }
        followState = SnapToPlayer;
    }

    public void SetFreeCam() {
        followState = FreeCam;
    }

    public void SetFollowing() {
        followState = Following;
    }

    public bool IsSnapping() {
        return followState == SnapToPlayer;
    }
}
