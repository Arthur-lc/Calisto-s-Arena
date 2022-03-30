using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Killable : MonoBehaviour
{
    [SerializeField] public float hp = 1f;
    [SerializeField] public bool isInvunerable = false;
    [System.NonSerialized] public float maxHp;
    [System.NonSerialized] public AudioSource audioSource;
    [System.NonSerialized] public bool isDead = false;

    private void Start() {
        audioSource = GetComponent<AudioSource>();
        maxHp = hp;
    }

    public virtual void TakeDamage(float damageTaken) {
        ImpulseManager.Instance.Shake(damageTaken / maxHp);
        hp -= damageTaken;

        if (hp <= 0)
        {
            Die();
        }
        else
        {
            audioSource.Play();
        }

        Events.onCauseDamage.Invoke(damageTaken);
    }

    public virtual void Die() {
        if (!isDead)
        {
            isDead = true;
            Debug.Log("CHAMANDO TODS OS CORNOS");
            Events.onEnemyDied.Invoke();
            GameObject particle = GameManager.Pool.GetPooledObject();
            particle.transform.position = this.transform.position;
            particle.SetActive(true);
            Destroy(this.gameObject);
        }
    }

    /*public async Invunerable() {
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), true);
        yield return new WaitForSeconds (.5f);
        Physics2D.IgnoreLayerCollision(LayerMask.NameToLayer("Player"), LayerMask.NameToLayer("Enemy"), false);
    }*/
}
