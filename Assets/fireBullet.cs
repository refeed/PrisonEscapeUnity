using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fireBullet : MonoBehaviour
{
    public float timeBetweenBullets = 0.15f;
    public GameObject projectile;

    float nextBullet;

    AudioSource gunMuzzleAS;
    public AudioClip shootSound;
    public AudioClip reloadSound;

    // Start is called before the first frame update
    void Awake()
    {
        nextBullet = 0f;
        gunMuzzleAS = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        playerControllerScript myPlayer = transform.root.GetComponent<playerControllerScript>();

        if (Input.GetAxisRaw("Fire1") > 0 && nextBullet < Time.time) {
            nextBullet = Time.time + timeBetweenBullets;
            Vector3 rot;
            if (myPlayer.GetFacing() == -1f)
            {
                rot = new Vector3(0, -90, 0);
            }
            else rot = new Vector3(0, 90, 0);

            Instantiate(projectile, transform.position, Quaternion.Euler(rot));

            playSound(shootSound);
        }
    }

    void playSound(AudioClip playTheSound) {
        gunMuzzleAS.clip = playTheSound;
        gunMuzzleAS.Play();
    }
}
