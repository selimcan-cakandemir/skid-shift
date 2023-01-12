using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static GameManager;

public class FinishLine : BaseObject
{
    public override void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) { GameManager.Instance.UpdateGameState(GameState.Victory); }
        Debug.Log("Collision");
    }

}
