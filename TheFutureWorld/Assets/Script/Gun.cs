using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField]
    [Range(0.1f, 1.5f)]
    private float fireRate = 0.3f;
    [SerializeField]
    [Range(1, 10)]
    private int damage = 1;

    [SerializeField]
    private ParticleSystem muzzleParticle;
    [SerializeField]
    GameObject bullethole;
    
    private float timer;
    public float lifetime = 1f;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= fireRate)
        {
            if (Input.GetButton("Fire1"))
            {
                timer = 0f;
                Fire();
            }
        }
        if (timer >= lifetime)
        {
            Destroy(bullethole);
        }
    }

    private void Fire()
    {
        //Debug.DrawRay(firePoint.position, firePoint.forward * 100, Color.red, 2f);
        muzzleParticle.Play();
        Ray ray = Camera.main.ViewportPointToRay(Vector3.one * 0.5f);
        Debug.DrawRay(ray.origin, ray.direction * 100, Color.red, 2f);
        //Ray ray = new Ray(firePoint.position, firePoint.forward);
        RaycastHit hitinfo;

        if (Physics.Raycast(ray, out hitinfo, 100))
        {
            //Destroy(hitinfo.collider.gameObject);
            var health = hitinfo.collider.GetComponent<Health>();
            if (health != null)
            {
                health.TakeDamage(damage);
            }
            if(health == null)
            {
                Instantiate(bullethole, hitinfo.point, Quaternion.FromToRotation(Vector3.up, hitinfo.normal));
            }
        }
    }
}
