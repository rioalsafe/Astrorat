using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class PlayerStat : MonoBehaviour
{
    [SerializeField]
    private Text goldText;

    [SerializeField]
    private float currentHP = 20;     // 최대 체력
    private int currentGold = 100;

    [SerializeField]
    private Player player;

    void Update()
    {

    }

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void TakeGold(int gold)
    {
        currentGold += gold;
        goldText.text = "Gold: " + currentGold;

        if (currentGold <= 0)
        {
            // ...
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
            // ...
        }

        // Player 오브젝트의 체력값 갱신
        player.health = (int)currentHP;

        // 체력바 업데이트
        player.GetComponent<HealthBarScript>().DamagePlayer();
    }
}
