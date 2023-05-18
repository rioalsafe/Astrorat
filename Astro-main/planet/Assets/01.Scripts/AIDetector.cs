using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;



//구현방식
//RayCast로 선탐지 -> 원 범위로 후탐지 -> 탐지 -> 사격
//코루틴으로 반복

public class AIDetector : MonoBehaviour
{
    // 시야 반경
    [Range(1, 15)]
    [SerializeField] //해당 맴버변수를 Inspector로 사용하기 위해 선언
    private float viewRadius = 11;

    // 탐지 체크 주기
    [SerializeField]
    private float detectionCheckDelay = 0.1f;

    // 타겟
    [SerializeField]
    private Transform target;

    // 플레이어 레이어 마스크
    [SerializeField]
    private LayerMask playerLayerMask;

    // 가시성 레이어
    [SerializeField]
    private LayerMask visibilityLayer;

    //스켈레톤 오브젝트
    public SkeletonAnimation skeletonAnimation;
    public GameObject thisObject;
    public string boneName;
    public string enemyTag;
    private Transform enemyTransform;
    private Transform thisTransform;

    public Vector2 Direction;
    // public GameObject Gun;

    //총알
    public GameObject bullet;
    public float FireRate;
    float nextTimeToFire = 0;
    public float Force;
    //public Transform Shootpoint;
    //aim bone
    //private string aimbone = Aim;

    // 타겟이 가시화면 내 있는지 여부
    [field: SerializeField]
    public bool TargetVisible { get; private set; }

    //타겟 식별 람다식
    public Transform Target
    {
        get => target;
        set
        {
            target = value;
            TargetVisible = false;
        }
    }

    //코루틴 시작
    private void Start()
    {
        StartCoroutine(DetectionCoroutine());
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
    }

    //매 프레임마다 타겟식별 체크
    private void Update()
    {
        if (Target != null)
        TargetVisible = CheckTargetVisible();

    }

    //레이케스트로 타겟 식별 함수
    private bool CheckTargetVisible()
    {

        var result = Physics2D.Raycast(transform.position, Target.position - transform.position, viewRadius, visibilityLayer);
        if (result.collider != null)
        {
            return (playerLayerMask & (1 << result.collider.gameObject.layer)) != 0;
        }
        Debug.Log("No object hit"); // 디버그 로그 출력
        return false;
    }

    //타겟탐지
    private void DetectTarget()
    {
        if (Target == null)
        {
            CheckIfPlayerInRange();
        }
        else if (Target != null)
        {
            
            DetectIfOutOfRange();
            CheckIfPlayerInRange();
            Debug.Log("나감");
        }
    }

    //타겟이 시야에서 살아졌는지 체크
    private void DetectIfOutOfRange()
    {
        if (Target == null || Target.gameObject.activeSelf == false || Vector2.Distance(transform.position, Target.position) > viewRadius + 1)
        {
            skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
            Target = null;
            Debug.Log("탈출함"); // 디버그 메시지 출력
        }
    }
 //   skeletonAnimation.AnimationState.SetAnimation(0, "Attack", true);
    //타겟이 시야에 있는지 충돌 체크
    private void CheckIfPlayerInRange()
    {
        GameObject enemyObject = GameObject.FindGameObjectWithTag(enemyTag);
        Collider2D collision = Physics2D.OverlapCircle(transform.position, viewRadius, playerLayerMask);
        if (collision != null)
        {
            
            Target = collision.transform;
            if (Target != null)
            {
                Vector2 TargetPos = Target.position;
                GameObject thisObject = this.gameObject;
                Vector2 TurretPos = thisObject.transform.position;
                Direction = TargetPos - TurretPos;

                var bone = skeletonAnimation.Skeleton.FindBone(boneName);
                if (bone != null)
                {
                    bone.X = Direction.x;
                    bone.Y = Direction.y - 5;
                }

            }
            if (Time.time > nextTimeToFire)
            {
                nextTimeToFire = Time.time + 1 / FireRate;
                shoot();
            }
        }
    }

    //총알 발사
    void shoot()
    {
        Transform myTransform = transform;
        GameObject BulletIns = Instantiate(bullet, myTransform.position + new Vector3(0f, 1f, 0f), Quaternion.identity);
        BulletIns.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
    }

    IEnumerator DetectionCoroutine()
    {
        yield return new WaitForSeconds(detectionCheckDelay);
        DetectTarget();
        StartCoroutine(DetectionCoroutine());
    }

    //사격범위 그리기
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, viewRadius);
    }
}