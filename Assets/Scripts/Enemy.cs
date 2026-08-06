using UnityEngine;
using System.Collections;
using UnityEngine.Events;

public class Enemy : MonoBehaviour
{
 private Health health;
 protected Animator animator;
 private Collider objectCollider;
 protected bool isDead => health.CurrentHealth >= 0;
 private UnityEvent <Transform> onDeath = new UnityEvent<Transform>();
 public UnityEvent <Transform> OnDeath => onDeath;
 [SerializeField]
 protected Transform target;
 [SerializeField]
 protected string desroyAnimationName = "Destroy";
 [SerializeField]
 private string desroySoundName = "Asteroid_Explode";
 [SerializeField]
 private string appearSoundName;
 public Transform Target {set{target = value;}}
 protected enum State {Active, Dead}
 protected State currentState;
 private void Awake()
   {
      health = GetComponent<Health>();
      animator = GetComponent<Animator>();
      objectCollider = GetComponent<Collider>();
   }
 public virtual void OnEnable()
   {
             
      SoundManager.instance.Play("Asteroid_Appear");
      health.InitializeHealth();
      currentState = State.Active;
   }
   public virtual void Destroy()
   {
      StopAllCoroutines();
      StartCoroutine(DestroyCoroutine());
   }
   private IEnumerator DestroyCoroutine()
   {
      SoundManager.instance.Play(desroySoundName);
      onDeath?.Invoke(transform);
      objectCollider.enabled = false;
      animator.Play(desroyAnimationName, 0, 0f);
      yield return animator.WaitForCurrentAnimation();
      gameObject.SetActive(false);
   }
   public virtual void PositionEnemy(){}
}
