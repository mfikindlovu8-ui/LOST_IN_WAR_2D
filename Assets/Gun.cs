using System.Runtime.CompilerServices;
using System.Collections.Generic;
using UnityEngine;


public class Gun : MonoBehaviour
{
    [SerializeField] int Damage;

    [SerializeField] float shootingCooldown;
    [SerializeField] float spread;
    [SerializeField] float shootForce;
    [SerializeField] float reloadTime;


    [SerializeField] bool isAutomatic;
    [SerializeField] bool AutoReload;
    [SerializeField] int magSize;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] LayerMask whatIsEnemy;

    private float amountOfSpread;

    private int bulletsLeft;

    private bool shooting;
    private bool reloading;
    private bool canShoot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
        bulletsLeft = magSize;
        canShoot = true;
        canShoot = true;

    }

    // Update is called once per frame
    private void Update()
    {
        if (isAutomatic)
        {
            shooting = Input.GetKey(KeyCode.Space);
        }
        else
        {
            shooting = Input.GetKeyDown(KeyCode.Space);
        }

        if (Input.GetKeyDown(KeyCode.R) && bulletsLeft < magSize && !reloading)
        {
            Reload();
        }

        if (AutoReload && bulletsLeft <= 0 && !reloading)
        {
            Reload();
        }
        else
        {

            if (canShoot && shooting && !reloading && bulletsLeft > 0)
            {
                Shoot();
                bulletsLeft--;
            }
        }
    }


    private void Reload()
    {
        reloading = true;
        Invoke("FinishReload", reloadTime);
    }

    private void FinishReload()
    {
        reloading = false;
        bulletsLeft = magSize;
    }
    private void Shoot()
    {
        canShoot = false;

        //Spread
        amountOfSpread = Random.Range(-spread, spread);

        Quaternion rotAfterSpread = Quaternion.Euler(firePoint.position.x, firePoint.position.y, +amountOfSpread);

        //Spawn Bullet
        GameObject bulletCopy = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletCopy.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shootForce, ForceMode2D.Impulse);
        bulletCopy.transform.rotation = rotAfterSpread;

        bulletsLeft--;
        Invoke("ResetShot", shootingCooldown);
    }

    private void ResetShot()
    {
        canShoot = true;
    }
}

