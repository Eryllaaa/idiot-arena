using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Character Stat Sheet", menuName = "StatSheets/CharacterStats")]
public class CharacterStats : ScriptableObject
{
    public string characterName;
    public int maxHealth;
    public int movementSpeed;
}
