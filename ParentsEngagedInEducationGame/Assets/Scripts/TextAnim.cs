using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TextAnim : MonoBehaviour
{
    List<Animator> animators;
    public float WaitBetweenCharacters = 0.15f;

    // Start is called before the first frame update
    void Start()
    {
        animators = new List<Animator>(GetComponentsInChildren<Animator>());
        StartCoroutine(TextWobble());
    }

    IEnumerator TextWobble()
    {
        while (true)
        {
            foreach (var animator in animators)
            {
                animator.SetTrigger("TextWobble");
                yield return new WaitForSeconds(WaitBetweenCharacters);
            }
        }
    }
}
