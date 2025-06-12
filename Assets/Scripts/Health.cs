using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] bool isPlayer;
    [SerializeField] int health = 50;
    [SerializeField] int scoreValue = 100;
    [SerializeField] ParticleSystem hitEffect;
    [SerializeField] bool applyCameraShake;

    CameraShake cameraShake;
    ScoreKeeper scoreKeeper;
    AudioPlayer audioplayer; 
    SpriteRenderer sr;
    int hitCount = 0;
    readonly Color[] hitColors = new Color[]
{
        new Color32(0xFF, 0xFF, 0xFF, 0xFF), // White
        new Color32(0xDB, 0xB9, 0xB9, 0xFF), // #DBB9B9
        new Color32(0xCB, 0x87, 0x87, 0xFF), // #CB8787
        new Color32(0xB0, 0x2C, 0x2C, 0xFF), // #B02C2C
};



    private void Awake()
    {
        cameraShake = Camera.main.GetComponent<CameraShake>();
        audioplayer = FindFirstObjectByType<AudioPlayer>();
        scoreKeeper = FindFirstObjectByType<ScoreKeeper>();
        sr = GetComponentInChildren<SpriteRenderer>();
        sr.color = hitColors[0]; // Start white
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        DamageDealer damageDealer = collision.GetComponent<DamageDealer>();
        if (damageDealer != null)
        {
            TakeDamage(damageDealer.GetDamage(), collision);

            PlayHitEffect();
            ShakeCamera();
            damageDealer.Hit();
        }

    }

    public int GetHealth()
    {
        return health;
    }
    void ShakeCamera()
    {
        if (cameraShake != null && applyCameraShake)
            cameraShake.Play();
    }

    private void TakeDamage(int damage, Collider2D collision)
    {
        var sr = gameObject.GetComponentInChildren<SpriteRenderer>();
        Color currentColor = sr.color;

        health -= damage;
        if (collision.GetComponentInChildren<SpriteRenderer>().name == "laserRed01_0" && health > 0)
        {

            //Debug.Log("Hit by the player");
            hitCount = Mathf.Clamp(hitCount + 1, 0, hitColors.Length - 1);
            scoreKeeper.ModifyScore(1);
            sr.color = hitColors[hitCount];
            Debug.Log(scoreKeeper.Score);
        }
        if (health <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        audioplayer.PlayExplosionClip();
        if(!isPlayer)
        {
            scoreKeeper.ModifyScore(scoreValue);
        }
        Debug.Log(scoreKeeper.Score);
        Destroy(gameObject);
    }

    void PlayHitEffect()
    {
        if (hitEffect != null)
        {
            ParticleSystem instance = Instantiate(hitEffect, transform.position, Quaternion.identity);
            Destroy(instance.gameObject, instance.main.duration + instance.main.startLifetime.constantMax);
        }
    }
}
