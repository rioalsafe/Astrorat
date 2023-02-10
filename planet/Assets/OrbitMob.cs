using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMob : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public Vector3 direction = Vector3.up;
    public EnemyController enemyController;
    [SerializeField]
    public int Damage = 1;
    [SerializeField]
    public int Gold = 1;

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, direction, moveSpeed * Time.deltaTime);

    }

    private void OnTriggerEnter2D(Collider2D collision)

      { if(collision.CompareTag("Flymob"))
   Debug.Log("Colliderd " + collision.name);
    }
}
