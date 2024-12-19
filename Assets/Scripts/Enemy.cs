using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private EnemyView _view;
    [SerializeField] private RagdollHandler _ragdollHandler;

    private void Awake()
    {
        _view.Initialize();
        _ragdollHandler.Initialize();
    }

    public void TakeDamage(Vector3 force, Vector3 hitPoint)
    {
        Debug.Log("Hit");
        EnableRagdollBehavoiur();
        _ragdollHandler.Hit(force, hitPoint);
    }

    public void EnableRagdollBehavoiur()
    {
        _view.DisableAnimator();
        _ragdollHandler.Enable();
    }
}
