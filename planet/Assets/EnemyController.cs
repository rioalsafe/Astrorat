using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    [SerializeField]
    private static PlayerHP playerHP;

    void Awake()
    {
        
    }

    public void AttackEnemy()
    {
        playerHP.TakeDamage(1);
    }
}
