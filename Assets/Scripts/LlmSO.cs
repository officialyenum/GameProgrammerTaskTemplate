using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "LlmSO Object", fileName = "New LLM")]
public class LlmSO : ScriptableObject
{
    [SerializeField] string attacker = "New Attacker Name";
    [SerializeField] string opponent = "New Opponent Name";
    [SerializeField] string[] outcome = new string[2];
  
    public string GetAttacker() {
        return attacker; 
    }

    public string GetOpponent() {
        return opponent;
    }

    public string GetOutcome(int index) {
        return outcome[index];
    }
}
