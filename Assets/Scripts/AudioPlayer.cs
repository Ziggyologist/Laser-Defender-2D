using System;
using UnityEngine;

public class AudioPlayer : MonoBehaviour
{
    [Header("Shooting")]
    [SerializeField] AudioClip shootingClip;
    [SerializeField] [Range(0f,1f)] float shootingVolume = 0.4f;

    [Header("Explosion")]
    [SerializeField] AudioClip explosionClip;
    [SerializeField][Range(0f, 1f)] float explosionVolume = 0.8f;

    static AudioPlayer instance; //singleton

    private void Awake()
    {
        ManageSingleton();
    }

    private void ManageSingleton()
    {
        //int instanceCount = FindObjectsByType(GetType(), FindObjectsSortMode.None).Length;
        //if(instanceCount > 1) //alternative to the singleton pattern
        if (instance !=null)
        {
            gameObject.SetActive(false);
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

    }

    public void PlayShootingClip()
    {
        if (shootingClip != null)
        {
            AudioSource.PlayClipAtPoint(shootingClip, Camera.main.transform.position, shootingVolume);
        }
    }

    public void PlayExplosionClip()
    {
        if (explosionClip != null)
        {
            AudioSource.PlayClipAtPoint(explosionClip, Camera.main.transform.position, explosionVolume);
        }
    }
}
