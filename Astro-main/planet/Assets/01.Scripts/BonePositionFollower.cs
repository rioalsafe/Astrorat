using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class BonePositionFollower : MonoBehaviour
{
    public SkeletonAnimation skeletonAnimation;
    public string boneName;
    public string enemyTag;
    private Transform enemyTransform;
    private Transform thisTransform;

    void Start()
    {
        
    }

    void Update()
    {
        GameObject thisObject = this.gameObject;
        GameObject enemyObject = GameObject.FindGameObjectWithTag(enemyTag);
        if (enemyObject != null)
        {
            enemyTransform = enemyObject.transform;
            thisTransform = thisObject.transform;
        }
        else
        {
            enemyTransform = null;
        }
        Vector2 object1Position = thisTransform.transform.position;
        Vector2 object2Position = enemyTransform.transform.position;
        Vector2 relativePosition = object2Position - object1Position;
        var bone = skeletonAnimation.Skeleton.FindBone(boneName);
        if (bone != null && enemyTransform != null)
        {
            bone.X = relativePosition.x;
            bone.Y = relativePosition.y - 5;
        }
    }
}