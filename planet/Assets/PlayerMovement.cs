using System.Collections;
using System.Collections.Generic;
using UnityEngine;



//플레이어 이동 클래스
//플레이어 이동시 자연스러운 중력연출 일부 중력조절함 
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D body;
    public float moveSpeed=10f, jumpPower;
    private bool isGrounded = true; //행성표면 착지 유무
    private float horizontal;

    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {  
        //점프
        if(isGrounded && Input.GetButtonDown("Jump")) 
        {//행성표면이고 점프키(spacebar)를 눌렀을때 동작
            body.AddForce(transform.up * jumpPower, ForceMode2D.Impulse);
        }
    }

    // 기존 Update()함수보다 좋다고해서 사용
    void FixedUpdate()
    {
        //수평이동
        horizontal = Input.GetAxisRaw("Horizontal");
        body.AddForce(transform.right * horizontal * moveSpeed);
    }

    //오브젝트 충돌감지
    void OnTriggerStay2D(Collider2D obj)
    {
        //충돌한 오브젝트가 Planet 일시
        if(obj.CompareTag("Planet"))    
        { 
            body.drag = 1f;

            float landplanetradius = obj.GetComponent<GravityPoint>().planetRadius;


            //(중력이 작용하고있는 범위 - 행성과 플레이어간 거리)
            float distance = Mathf.Abs(obj.GetComponent<GravityPoint>().planetRadius - Vector2.Distance(transform.position, obj.transform.position)); 
            // Debug.Log(distance);

            //행성표면 착지 판별
            if(distance < 1.7f)
            {
                isGrounded = true; 
            }
            else
            isGrounded = false;

           // Debug.Log("행성간 거리" + distance);
           // Debug.Log("현재 행성 거리" + landplanetradius);
            
        }
    }

    //오브젝트 충돌판정 해제
    void OnTriggerExit2D(Collider2D obj)
    {
        //감지된 오브젝트가 Planet 일시
        if(obj.CompareTag("Planet"))
        {
        Debug.Log("Jump Test - On Exit");
        body.drag = 0.2f;
        }
    }
}
