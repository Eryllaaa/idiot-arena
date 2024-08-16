using Unity.VisualScripting;
using UnityEngine;

public class PlayerInputs
{
    Character character;
    CharacterController characterController;
    public delegate void CharacterState();


    public PlayerInputs(Character character, CharacterController playerController) {
        this.character = character;
        this.characterController = playerController;
    }

    public void Update()
    {
        Inputs();
    }

    private void Inputs() {
        if (Input.GetMouseButton((int)MouseButton.Right)) {
            characterController.OnRightClick();
        }
    }
}
