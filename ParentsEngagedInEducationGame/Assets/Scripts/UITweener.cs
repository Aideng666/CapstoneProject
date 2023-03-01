using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public enum UIAnimationTypes
{
    Move,
    MoveX,
    MoveY,
    Scale,
    ScaleX,
    ScaleY,
    Rotate,
    RotateX,
    RotateY,
    Fade,
    Jump,
    Punch,
    Shake,
    Change
}

public enum DoTweenTypes
{

}

public class UITweener : MonoBehaviour
{
    public GameObject objectToAnimate;

    public UIAnimationTypes animType;
    



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
