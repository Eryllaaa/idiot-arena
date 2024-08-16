using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputs
{
    Character character;
    CharacterController characterController;
    public delegate void CharacterState();
    private CharacterState characterState;

    public PlayerInputs(Character character, CharacterController playerController) {
        this.character = character;
        this.characterController = playerController;
        SetAlive();
    }

    public void Update()
    {
        characterState();
    }

    private void Inputs() {
        if (Input.GetMouseButton((int)MouseButton.Right)) {
            characterController.OnRightClick();
        }
    }

    private void Alive() {
        if (Input.GetMouseButton((int)MouseButton.Right)) {
            characterController.OnRightClick();
        }
    }

    private void Dead() {

    }

    private void Idle() {

    }

    public void SetAlive() {
        characterState = Alive;
    }

    public void SetDead() {
        characterState = Dead;
    }

    public void SetIdle() {
        characterState = Idle;
    }
}
