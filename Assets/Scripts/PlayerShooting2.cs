using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting2 : MonoBehaviour
{

    public Vector3 bulletOffset = new Vector3(0, 0.5f, 0);

    public GameObject bulletPrefab;
    int bulletLayer;
    public float maxAmmo = 30;
    public float currentAmmo;
    public Slider reloadSlider;
    public float reloadTime = 2f;
    float reloadCooldownTimer;
    public bool isReloading;
    public float fireDelay = 0.25f;
    float cooldownTimer = 0;
    public float reloadTimeMultiplier = 1f;

    void Start()
    {


        reloadSlider.maxValue = reloadTime;
        bulletLayer = gameObject.layer;
    }

    // Update is called once per frame
    void Update()
    {
        cooldownTimer -= Time.deltaTime;

        if (Input.GetButton("Fire1") && cooldownTimer <= 0 && currentAmmo > 0 && !isReloading)
        {
            // SHOOT!
            cooldownTimer = fireDelay;

            Vector3 offset = transform.rotation * bulletOffset;

            GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
            currentAmmo--;
            bulletGO.layer = bulletLayer;
        }

        if (currentAmmo <= 0 || Input.GetButtonDown("Fire2") && currentAmmo != maxAmmo || isReloading)
        {
            ReloadGun();
        }
        reloadSlider.gameObject.SetActive(isReloading);
    }
    void ReloadGun()
    {
        isReloading = true;
        reloadCooldownTimer += Time.deltaTime;
        reloadSlider.value = reloadCooldownTimer;
        if (reloadCooldownTimer >= reloadTime * reloadTimeMultiplier) 
        {
            currentAmmo = maxAmmo;
            reloadCooldownTimer = 0;
            reloadSlider.value = 0;
            isReloading = false;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("reloadAcceleratorMod"))
        {
            reloadTimeMultiplier = 1f / 3f; 
            Destroy(other.gameObject);
        }
    }
}
