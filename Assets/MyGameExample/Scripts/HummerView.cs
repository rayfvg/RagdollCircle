using UnityEngine;

public class HummerView : MonoBehaviour
{
    private Animator _animator;
    public AudioSource HummerHit;

    private void Awake()
    {
        _animator = GetComponent<Animator>();
    }

    public void StartHitView()
    {
        _animator.SetTrigger("hit");
        HummerHit.Play();

    }
    public void SwitchIdleView() => _animator.SetTrigger("idle");
}
