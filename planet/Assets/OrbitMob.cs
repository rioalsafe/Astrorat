using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OrbitMob : MonoBehaviour
{
    public GameObject target;
    public float moveSpeed;
    public Vector3 direction = Vector3.up;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.RotateAround(target.transform.position, direction, moveSpeed * Time.deltaTime);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Debug.Log("Colliderd " + collision.name);
    }
}
