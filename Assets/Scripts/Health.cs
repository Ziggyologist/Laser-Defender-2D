using System;
using UnityEngine;

public class Health : MonoBehaviour
{
    [SerializeField] int health = 50;
    [SerializeField] ParticleSystem hitEffect;

    [SerializeField] bool applyCameraShake;
    CameraShake cameraShake;

    AudioPlayer audioplayer; 
    SpriteRenderer sr;
    int hitCount = 0;
    private readonly Color[] hitColors = new Color[]
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

            Debug.Log("Hit by the player");
            hitCount = Mathf.Clamp(hitCount + 1, 0, hitColors.Length - 1);
            sr.color = hitColors[hitCount];
        }
        if (health <= 0)
        {
            audioplayer.PlayExplosionClip();
            Destroy(gameObject);
        }
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
