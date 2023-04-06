using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public int damage = 1;

    private Vector2 startPosition;
    private Rigidbody2D bullet;
    // Start is called before the first frame update

    void Start()
    {
        bullet = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void DisableObject()
    {
        gameObject.SetActive(false);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player")){
        Debug.Log("Colliderd " + collision.name);
        DisableObject();
        //여기서 호출
        }
    }
}
