using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Shooting : MonoBehaviour
{

    public GameObject bulletPrefab;
    public GameObject spawn;
    public GameObject turret;
    public Vector3 direction;
    private float speed = 10f;
    public ScoreCounter bulletCountScript;
    public Toggle hardMode;
    public RawImage image;

    public AudioClip shootSound;
    public AudioSource shootSource;

    // Start is called before the first frame update
    void Start()
    {
        shootSource = GetComponent<AudioSource>();
        hardMode.isOn = false;
    }

    // Update is called once per frame
    void Update()
    {

        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hit;

        Vector3 target = new Vector3(40, 0, 600);

        if (Physics.Raycast(ray, out hit))
        {
            target = hit.point;
        }

        direction = (target - spawn.transform.position);
        Vector3 aimDirection = direction;
        aimDirection.y = 0;
        direction.Normalize();

        turret.transform.rotation = Quaternion.LookRotation(aimDirection);

        if (Input.GetMouseButtonDown(0))
        {
            if (!hardMode.isOn && !image.enabled)
            {
                Shoot();
                bulletCountScript.AddBullet();
            }
            if(hardMode.isOn && !image.enabled && bulletCountScript.bulletCount < 164)
            {
                Shoot();
                bulletCountScript.AddBullet();
            }
        }

    }

    void Shoot()
    {

        GameObject bullet = Instantiate(bulletPrefab, spawn.transform.position, Quaternion.identity);

        Rigidbody bulletRb = bullet.GetComponent<Rigidbody>();

        bulletRb.velocity = direction * speed;

        shootSource.PlayOneShot(shootSound);

        Destroy(bullet, 3f);
    }
}
