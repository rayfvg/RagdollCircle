using UnityEngine;

public class EnemyView : MonoBehaviour
{
    private Animator _animation;

    public void Initialize() => _animation = GetComponent<Animator>();

    public void EnableAnimator() => _animation.enabled = true;
    
    public void DisableAnimator() => _animation.enabled = false;
}
