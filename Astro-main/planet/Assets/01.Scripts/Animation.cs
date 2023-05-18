using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Spine.Unity;

public class Animation : MonoBehaviour
{
    private SkeletonAnimation skeletonAnimation;
    // Start is called before the first frame update
    void Start()
    {
        skeletonAnimation = GetComponent<SkeletonAnimation>();
        skeletonAnimation.AnimationState.SetAnimation(0, "Idle", true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
