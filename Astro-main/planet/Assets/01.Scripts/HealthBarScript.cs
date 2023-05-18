using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class HealthBarScript : MonoBehaviour
{
    public Slider healthBarSlider;
    public TextMeshProUGUI healthBarValueText;

    private Player playerObject;

    void Start()
    {
        playerObject = GameObject.Find("PlayerBody").GetComponent<Player>();
    }

    void Update()
    {
        int currHealth = playerObject.health;
        int maxHealth = playerObject.maxHealth;

        healthBarValueText.text = currHealth.ToString() + "/" + maxHealth.ToString();
        healthBarSlider.value = currHealth;
        healthBarSlider.maxValue = maxHealth;
    }

    public void DamagePlayer()
    {
        Update();
    }
}
