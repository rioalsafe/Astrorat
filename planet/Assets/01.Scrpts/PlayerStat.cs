using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    private int currentGold = 100;

    [SerializeField]
    private float currentHP = 20;     // 최대 체력

    void Update()
    {

    }

    private void Awake()
    {
        
    }

    public void TakeGold(int gold)
    {

        currentGold += gold;
        Debug.Log("gold : " + currentGold);


        if (currentGold <= 0)
        {

        }
    }

    public void TakeDamage(int damage)
    {
        // 현재 체력을 damage만큼 감소
        currentHP -= damage;
        Debug.Log("HP : " + currentHP);

        // 체력이 0이 되면 게임오버
        if (currentHP <= 0)
        {
        }
    }
}