using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    public PlayerStat playerStat;

    void Awake()
    {

    }

    public void AttackEnemy(int Damage)
    {
        playerStat.GetComponent<PlayerStat>().TakeDamage(Damage);
    }

    public void KillEnemy(int Gold)
    {
        playerStat.GetComponent<PlayerStat>().TakeGold(Gold);
    }
}