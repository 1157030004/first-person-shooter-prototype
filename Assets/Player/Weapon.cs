using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    [SerializeField] Camera FPCamera;
    [SerializeField] float range = 100f;
    [SerializeField] float damage = 25f;
    [SerializeField] ParticleSystem muzzleFlash;

    void Update()
    {
        if(Input.GetButton("Fire1"))
        {
            Shoot();
        }
    }

    void Shoot()
    {
        PlayMuzzleFlash();
        ProcessRaycast();
    }

    void PlayMuzzleFlash()
    {
        muzzleFlash.Play();
    }

    void ProcessRaycast()
    {
        RaycastHit hit;
        if(Physics.Raycast(FPCamera.transform.position, FPCamera.transform.forward, out hit, range))
        {
            Debug.Log(hit.transform.name);
            //TODO: add some hit effect for visual player
            EnemyHealth target = hit.transform.GetComponent<EnemyHealth>();
            if(target == null) return;
            target.TakeDamage(damage);
        }else{
            return;
        }
    }
    
}
