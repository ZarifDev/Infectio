using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerShooting : MonoBehaviour {

    public Text contador;
	public GameObject bulletPrefab;
	int bulletLayer;
	public float maxAmmo = 30;
	public float currentAmmo;
	 Slider reloadSlider;
	 public float reloadTime = 1f;
	float reloadCooldownTimer;
	public bool isReloading;
	public float fireDelay = 0.25f;
	public float quickFireDelayDecrease = 0.08f;
	float currentQuickFireDelay;
	float cooldownTimer = 0;
	Player playerScript;
	public float damage = 1;
	public float bulletLifeTime = 1;
	[SerializeField] Transform[] firePoints;
	[SerializeField] float precisionVariation;
	public float bulletSpeedIncrease = 0;
	AudioSource audioSource;
	public AudioClip shootSound;
	public AudioClip reloadSound;
	void Awake() {
		audioSource = GetComponent<AudioSource>();
		PlayerBullet.damage = damage;
		PlayerBullet.lifeTime = bulletLifeTime;
		PlayerBullet.speedIncrease = bulletSpeedIncrease;
		playerScript = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		playerScript.velocidadeDeRecargaDaArma =  reloadTime; 
		playerScript.velocidadeDeRecargaAtual =  reloadTime;
		reloadSlider = playerScript.reloadSlider;
		reloadSlider.maxValue = reloadTime;
		currentAmmo = maxAmmo;

	}

	// Update is called once per frame
	void Update () {

	
	if(contador != null){
    contador.text = "Ammo: "+ currentAmmo.ToString() + "/"+ maxAmmo.ToString();
	}else
	{
	contador = GameObject.Find("Contador").GetComponent<Text>();
	}



	 if(Player.playerCantDoNothing == false)
      {
		cooldownTimer -= Time.deltaTime;
		reloadTime = playerScript.velocidadeDeRecargaAtual;
		reloadSlider.maxValue = reloadTime;
		if(Input.GetButtonUp("Fire1"))
			{	
			currentQuickFireDelay = quickFireDelayDecrease;
			audioSource.pitch =1;
			}
		
		if( Input.GetButton("Fire1") && cooldownTimer <= 0 && currentAmmo >0 && !isReloading) {
			Shoot();
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
		if(!isReloading){
		audioSource.pitch = 1;
		PlaySound(reloadSound);
		isReloading = true;
		}
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
	 void Shoot()
	{
	
			cooldownTimer = fireDelay-currentQuickFireDelay;

			for (int i = 0; i < firePoints.Length; i++)
			{
				playerScript.muzzleFlash.Play();
			float bulletVariation = Random.Range(-precisionVariation,precisionVariation);
			GameObject bulletGO = (GameObject)Instantiate(bulletPrefab,firePoints[i].transform.position,Quaternion.Euler(0,0,firePoints[i].rotation.eulerAngles.z + bulletVariation));
			}
			currentAmmo --;
			audioSource.pitch +=0.05f;
			currentQuickFireDelay = 0;
			PlaySound(shootSound);

	}
	void PlaySound(AudioClip clip)
	{
		audioSource.PlayOneShot(clip);
	}
}
