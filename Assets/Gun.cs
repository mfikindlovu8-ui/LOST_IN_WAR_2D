using System.Runtime.CompilerServices;

using UnityEngine;

public class Gun : MonoBehaviour
{
    [SerializeField] int Damage;

    [SerializeField] float shootingCooldown;
    [SerializeField] float spread;
    [SerializeField] float shootForce;

    
    [SerializeField] bool isAutomatic;

    [SerializeField] Transform firePoint;
    [SerializeField] GameObject bulletPrefab;
    [SerializeField] LayerMask whatIsEnemy;

    private float amountOfSpread;

   

    private bool shooting;
    private bool reloading;
    private bool canShoot;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    private void Start()
    {
      
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
    }
      

      private void Shoot()
    {
        canShoot = false;

        //Spread
        amountOfSpread = Random.Range(-spread, spread);

       
        
        //Spawn Bullet
        GameObject bulletCopy = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        bulletCopy.GetComponent<Rigidbody2D>().AddForce(firePoint.up * shootForce, ForceMode2D.Impulse);

    }
    }
