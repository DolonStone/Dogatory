using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Orienter : MonoBehaviour
{
    private Transform parentTransform;
    private Animator animator;
    [SerializeField] private List<RuntimeAnimatorController> animatorControllers;
    void Start()
    {
        parentTransform = this.transform.parent;
        animator = GetComponent<Animator>();
        var state = animator.GetCurrentAnimatorStateInfo(0);
        animator.Play(state.fullPathHash, 0, Random.Range(0f, 1f));
    }


    void Update()
    {
        this.transform.rotation = Quaternion.Euler(0, 0, -parentTransform.rotation.z);
        this.transform.localPosition = new Vector3(0, 0, 0);
    }
    public void ChangeColour(int number)
    {
        if (animator == null)
        {
            animator = GetComponent<Animator>();
        }
        animator.runtimeAnimatorController = animatorControllers[number-1];
    }
}
