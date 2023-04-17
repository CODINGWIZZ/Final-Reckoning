using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;
using StarterAssets;
using UnityEngine.InputSystem;

public class ShooterController : MonoBehaviour
{
    [SerializeField] private CinemachineVirtualCamera aimVirtualCamera;
    [SerializeField] private float normalSensitivity;
    [SerializeField] private float aimSensitivity;
    [SerializeField] private LayerMask aimColliderLayerMask = new LayerMask();
    [SerializeField] private Transform debugTransform;
    [SerializeField] private GameObject pfBulletProjectile;
    [SerializeField] private Transform spawnBulletPosition;

    [SerializeField] private Transform vfxHitGreen;
    [SerializeField] private Transform vfxHitRed;

    public float speed;

    // private GameObject y;

    private ThirdPersonController thirdPersonController;
    private StarterAssetsInputs starterAssetsInputs;

    private void Awake() {
        thirdPersonController = GetComponent<ThirdPersonController>();
        starterAssetsInputs = GetComponent<StarterAssetsInputs>();
    }

    private void Update() {
        // if(starterAssetsInputs.aim) {
        //     aimVirtualCamera.gameObject.SetActive(true);
        //     thirdPersonController.SetSensitivity(aimSensitivity);
        // } else {
        //     aimVirtualCamera.gameObject.SetActive(false);
        //     thirdPersonController.SetSensitivity(normalSensitivity);
        // }

        Vector3 mouseWorldPosition = Vector3.zero;
        Vector2 screenCenterPoint = new Vector2(Screen.width / 2f + 200, Screen.height / 2f);

        int layerMask = LayerMask.GetMask("Default", "Enemy", "Ground");

        Ray ray = Camera.main.ScreenPointToRay(screenCenterPoint);
        Transform hitTransform = null;

        if(Physics.Raycast(ray, out RaycastHit raycastHit, 999f, layerMask)) {
            debugTransform.position = raycastHit.point;
            mouseWorldPosition = raycastHit.point;
            hitTransform = raycastHit.transform;
        }

        if(starterAssetsInputs.aim) {
            Vector3 worldAimTarget = mouseWorldPosition;
            worldAimTarget.y = transform.position.y;
            Vector3 aimDirection = (worldAimTarget - transform.position).normalized;
            thirdPersonController.SetSensitivity(aimSensitivity);
            thirdPersonController.SetRotateOnMove(false);

            transform.forward = Vector3.Lerp(transform.forward, aimDirection, Time.deltaTime * 20f); 
        } else {
            mouseWorldPosition = ray.GetPoint(10);
            thirdPersonController.SetSensitivity(normalSensitivity);
            thirdPersonController.SetRotateOnMove(true);
        }

        if(starterAssetsInputs.shoot) {
            // if(hitTransform != null) {
            //     // Hit something
            //     if(hitTransform.GetComponent<BulletTarget>() != null) {
            //         // Hit target
            //         Instantiate(vfxHitGreen, transform.position, Quaternion.identity);
            //     } else {
            //         // Hit something else
            //         Instantiate(vfxHitRed, transform.position, Quaternion.identity);
            //     }
            // }

            Vector3 aimDirection = (mouseWorldPosition - spawnBulletPosition.position).normalized;
            Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            // GameObject bullet = (GameObject)Instantiate(pfBulletProjectile, spawnBulletPosition.position, Quaternion.LookRotation(aimDirection, Vector3.up));
            starterAssetsInputs.shoot = false;
            // bullet.GetComponent<Rigidbody>().AddRelativeForce(0,0,speed * Time.deltaTime);
        }
    }
}
