using TMPro;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public AudioSource[] HitSounds;
    [SerializeField] private EnemyView _view;
    [SerializeField] private RagdollHandler _ragdollHandler;


    private void Awake()
    {
        _view.Initialize();
        _ragdollHandler.Initialize();
    }

    public void PLayHitSound()
    {
        int index = Random.Range(0, HitSounds.Length);
        HitSounds[index].Play();
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
