using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RaycastMagic : MonoBehaviour
{
    class Bullet {
        public float time;
        public Vector3 initialPosition;
        public Vector3 initialVelocity;
    }

    public bool isFiring = false;
    public int fireRate = 25;
    public float bulletSpeed = 1000.0f;
    public float bulletDrop = 0.0f;

    public ParticleSystem[] muzzleFlash;
    public ParticleSystem hitEffect;
    public TrailRenderer tracerEffect;

    public Transform raycastOrigin;
    public Transform raycastDestination;

    Ray ray;
    RaycastHit hitInfo;
    float accumulatedTime;
    List<Bullet> bullets = new List<Bullet>();

    Vector3 GetPosition(Bullet bullet) {
        Vector3 gravity = Vector3.down * bulletDrop;
        return (bullet.initialPosition) + (bullet.initialPosition * bullet.time) + (0.5f * gravity * bullet.time * bullet.time);
    }

    Bullet CreateBullet(Vector3 position, Vector3 velocity) {
        Bullet bullet = new Bullet();
        bullet.initialPosition = position;
        bullet.initialVelocity = velocity;
        bullet.time = 0.0f;

        return bullet;
    }



    public void StartFiring() {
        isFiring = true;
        accumulatedTime = 0.0f;
        FireBullet();
    }

    public void UpdateFiring(float deltaTime) {
        accumulatedTime += deltaTime;
        float fireInterval = 1.0f / fireRate;

        while(accumulatedTime >= 0.0f) {
            FireBullet();
            accumulatedTime -= fireInterval;
        }
    }

    private void FireBullet() {        
        foreach(var particle in muzzleFlash) {
            particle.Emit(1);
        }

        // ray.origin = raycastOrigin.position;
        // ray.direction = raycastDestination.position - raycastOrigin.position;

        // var tracer = Instantiate(tracerEffect, ray.origin, Quaternion.identity);
        // tracer.AddPosition(ray.origin);
        
        // if(Physics.Raycast(ray, out hitInfo)) {
        //     // Debug.DrawLine(ray.origin, hitInfo.point, Color.red, 1.0f);
        //     hitEffect.transform.position = hitInfo.point;
        //     hitEffect.transform.forward = hitInfo.normal;
        //     hitEffect.Emit(1);

        //     tracer.transform.position = hitInfo.point;
        // }

        Vector3 velocity = (raycastDestination.position - raycastOrigin.position).normalized * bulletSpeed;
        var bullet = CreateBullet(raycastOrigin.position, velocity);
        bullets.Add(bullet);
    }

    public void StopFiring() {
        isFiring = false;
    }
}
