using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerShooting : MonoBehaviour {

	public Vector3 bulletOffset = new Vector3(0.5f, 0, 0);

	public GameObject bulletPrefab;
	int bulletLayer;
	public float maxAmmo = 30;
	public float currentAmmo;
	public Slider reloadSlider;
	 public float reloadTime = 1f;
	float reloadCooldownTimer;
	public bool isReloading;
	public float fireDelay = 0.25f;
	public float quickFireDelayDecrease = 0.08f;
	float currentQuickFireDelay;
	float cooldownTimer = 0;
	Player playerScript;
	public float damage = 1;

	void Start() {
		PlayerBullet.damage = damage;
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.velocidadeDeRecargaDaArma =  reloadTime; 
		playerScript.velocidadeDeRecargaAtual =  reloadTime;
		reloadSlider.maxValue = reloadTime;
		currentAmmo = maxAmmo;
		bulletLayer = gameObject.layer;
	}

	// Update is called once per frame
	void Update () {
		
	 if(Player.playerCantDoNothing == false)
      {
		cooldownTimer -= Time.deltaTime;
		reloadTime = playerScript.velocidadeDeRecargaAtual;
		reloadSlider.maxValue = reloadTime;
		if(Input.GetButtonUp("Fire1"))
			{	
			currentQuickFireDelay = quickFireDelayDecrease;
			}
		
		if( Input.GetButton("Fire1") && cooldownTimer <= 0 && currentAmmo >0 && !isReloading) {
			// SHOOT!
			
			cooldownTimer = fireDelay-currentQuickFireDelay;
			
			Vector3 offset = transform.rotation * bulletOffset;

			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab, transform.position + offset, transform.rotation);
			currentAmmo --;
			bulletGO.layer = bulletLayer;
				currentQuickFireDelay = 0;
		}
	
		if(currentAmmo <=0 || Input.GetButtonDown("Fire2") && currentAmmo != maxAmmo|| isReloading)
		{
		ReloadGun();
		}
		reloadSlider.gameObject.SetActive(isReloading);
	}
	}
	void ReloadGun()
	{
		isReloading = true;
		reloadCooldownTimer += Time.deltaTime;
		reloadSlider.value = reloadCooldownTimer;
		if(reloadCooldownTimer >= reloadTime )
		{
			currentAmmo = maxAmmo;
			reloadCooldownTimer = 0;
			reloadSlider.value = 0;
			isReloading = false;
			
		}
	}

}
