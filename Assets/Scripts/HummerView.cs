using UnityEngine;

public class HummerView : MonoBehaviour
{
    private Animator _animator;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartHitView() => _animator.SetTrigger("hit");
    public void SwitchIdleView() => _animator.SetTrigger("idle");
}
