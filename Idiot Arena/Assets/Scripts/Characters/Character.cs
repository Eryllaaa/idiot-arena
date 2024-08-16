using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using UnityEngine;
using UnityEngine.AI;

public class Character : MonoBehaviour
{
    public CharacterStats stats;

    public GameObject playerPrefab;
    public GameObject cameraHolder;
    PlayerInputs inputManager;
    public NavMeshAgent navMeshAgent;

    protected int maxHealth;
    protected int health;
    private float movementSpeed;

    public int Health {
        get {
            return health;
        }
        private set {
            health = value;
        }
    }

    public float MovementSpeed {
        get {
            return movementSpeed;
        }
        set {
            //movementSpeed is used to keep track of the value, nav.speed is the actual implementation
            movementSpeed = value;
            navMeshAgent.speed = value;
        }
    }

    public delegate void CharacterState();
    public CharacterState CurrentState;

    protected virtual void Start()
    {
        if (gameObject.transform.parent != null) {
            playerPrefab = gameObject.transform.parent.gameObject;
            cameraHolder = gameObject.transform.parent.gameObject.GetComponent<PlayerNetworkManager>().cameraHolder;
        }
        gameObject.GetComponent<CharacterController>().Ready();

        LoadStats();
        inputManager = new PlayerInputs(this, gameObject.GetComponent<CharacterController>());

        SetAlive();
    }

    protected virtual void Update()
    {
        inputManager.Update();
        CurrentState();
    }

    void LoadStats() {
        if (stats == null) {
            Debug.Log("---No Character Stats to load---");
            return;
        }
        maxHealth = stats.maxHealth;
        health = maxHealth;
        movementSpeed = stats.movementSpeed;

    }

    protected virtual void Alive() {

    }

    protected virtual void Dead() {

    }

    protected void SetAlive() {
        CurrentState = Alive;
        inputManager.SetAlive();
    }

    public CharacterState GetCurrentState() {
        return CurrentState;
    }

    protected virtual void OnDeath() {
        CurrentState = Dead;
        inputManager.SetDead();
    }
}
