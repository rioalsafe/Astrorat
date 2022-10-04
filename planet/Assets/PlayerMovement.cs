using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed=10f, jumpPower;
    private bool isGrounded = true;
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");

        if(isGrounded && Input.GetButtonDown("Jump"))
        {
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    void FixedUpdate()
    {
        body.AddForce(transform.right * horizontal * moveSpeed);
    }

    void OnTriggerStay2D(Collider2D obj)
    {
        if(obj.CompareTag("Planet"))
        {
            body.drag = 1f;

            float landplanetradius = obj.GetComponent<GravityPoint>().planetRadius;


            //중력이 작용하고있는 범위의 반지름 - 행성과 플레이어간 거리
            float distance = Mathf.Abs(obj.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, obj.transform.position)); 
           // Debug.Log(distance);
            //그 거리가 ~보다 작다면 
            if(distance < 1.7f)
            {
                isGrounded = true; 
            }
            else
            isGrounded = false;

            Debug.Log("행성간 거리" + distance);
            Debug.Log("현재 행성 거리" + landplanetradius);
            
        }
    }

    void OnTriggerExit2D(Collider2D obj)
    {
        if(obj.CompareTag("Planet"))
        {
        Debug.Log("Jump Test - On Exit");
        body.drag = 0.2f;
        }
    }
}
