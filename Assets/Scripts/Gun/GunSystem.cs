using System.Numerics;
using TMPro;
using UnityEngine;

public class GunSystem : MonoBehaviour
{
    //bullet
    public GameObject bullet;
    //bullet force
    public float shootForce, upwardForce;
    public int reloadSFXIndex = 0;
    public int gunShootSFXIndex = 0;
    //gun statistics
    public int damage;
    public float timeBetweenShooting, spread, range, reloadTime, timeBetweenShots;
    public int magazineSize, bulletsPerTap;
    public bool allowButtonHold;
    int bulletsLeft, bulletsShot;
    int invBullets;

    //bools
    bool shooting, readyToShoot, reloading;

    //references
    public Camera fpsCam;
    public Transform attackPoint;
    public RaycastHit rayHit;
    public LayerMask whatIsEnemy;
    public InventoryManager inventoryManager;

    //graphics
    //public GameObject muzzleFlash, bulletHoleGraphic;
    //public CamShake camShake;
    //public float camShakeMagnitude, camShakeDuration;
    public TextMeshProUGUI text;

    private void Awake()
    {
        invBullets = inventoryManager.bulletCount;
        bulletsLeft = magazineSize;
        readyToShoot = true;
    }
    private void Update()
    {
        MyInput();
        text.SetText(bulletsLeft + " / " + invBullets);
        UnityEngine.Debug.DrawRay(fpsCam.transform.position, fpsCam.transform.forward, UnityEngine.Color.green);
    }

    //shooting input
    private void MyInput()
    {
        if (allowButtonHold) shooting = Input.GetKey(KeyCode.Mouse0);
        else shooting = Input.GetKeyDown(KeyCode.Mouse0);

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magazineSize && !reloading && inventoryManager.bulletCount > 0) 
        {
            Reload();
        }

        //shooting
        if (readyToShoot && shooting && !reloading && bulletsLeft > 0)
        {
            bulletsShot = bulletsPerTap;
            Shoot();
            SoundManager.instance.PlaySFX(gunShootSFXIndex);
        }
    }

    private void Shoot()
    {
        readyToShoot = false;

        //bullet spread
        float x = Random.Range(-spread, spread);
        float y = Random.Range(-spread, spread);

        //calculating direction with spread
        Ray ray = fpsCam.ViewportPointToRay(new UnityEngine.Vector3(0.5f, 0.5f, 0));
        RaycastHit hit;

        UnityEngine.Vector3 targetPoint;
        if (Physics.Raycast(ray, out hit))
            targetPoint = hit.point;
        else
            targetPoint = ray.GetPoint(75);

        UnityEngine.Vector3 directionWithoutSpread = targetPoint - attackPoint.position;

        UnityEngine.Vector3 directionWithSpread = directionWithoutSpread + new UnityEngine.Vector3(x, y, 0);


        //Make bullet spawn
        GameObject currentBullet = Instantiate(bullet, attackPoint.position, UnityEngine.Quaternion.identity);

        //Rotate bullet to shoot direction
        currentBullet.transform.forward = directionWithSpread.normalized;

        //Add forces to the bullet
        currentBullet.GetComponent<Rigidbody>().AddForce(directionWithSpread.normalized * shootForce, ForceMode.Impulse);
        currentBullet.GetComponent<Rigidbody>().AddForce(fpsCam.transform.up * upwardForce, ForceMode.Impulse);

        bulletsLeft--;
        bulletsShot--;

        Invoke("ResetShot", timeBetweenShooting);

        if (bulletsShot > 0 && bulletsLeft > 0)
            Invoke("Shoot", timeBetweenShots);
    }

    private void ResetShot()
    {
        readyToShoot = true;
    }

    //reloading
    private void Reload()
    {
        reloading = true;
        SoundManager.instance.PlaySFX(reloadSFXIndex);
        Invoke("ReloadFinished", reloadTime);
    }
    private void ReloadFinished()
    {
        if (invBullets >= bulletsLeft)
        {
        bulletsLeft = magazineSize;
        }
        if (invBullets < magazineSize)
        {
            magazineSize = invBullets;
        }
        reloading = false;
    }
}
