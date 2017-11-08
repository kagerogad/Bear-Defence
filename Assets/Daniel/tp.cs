using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class tp : PlaceableObject, IsDamageable
{

    [Header("Turret Attributes")]
    public string enemyTag;
    public float range;
    public float batteryRange;
    public float turnSpeed;
    public float rateOfFire = 1f;
    public float startDurability = 100f;
    public float durabilityLossPerShot = 10f;
    public bool useLazer = false;
    public LineRenderer lineRenderer;

    private float rateOfFire_;
    [Header("Turret References")]
    public Transform partToRotate;
    public Transform firingPoint1;
    public Transform firingPoint2;
    private Transform firingPoint;
    public Image durabilityBar;
    public GameObject wire;

    private Transform target;
    private bool isOn;
    private float durability;

    void Start()
    {
        rateOfFire_ = rateOfFire;
        durability = startDurability;
        firingPoint = firingPoint1;
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("UpdateBattery", 0f, 0.3f);
    }

    void Update()
    {
        if (target == null)
        {
            if (useLazer)
            {
                if (lineRenderer.enabled)
                {
                    lineRenderer.enabled = false;
                }
            }
            return;
        }

        if (!isOn)
        {
            if (lineRenderer != null && lineRenderer.enabled)
            {
                lineRenderer.enabled = false;
            }
        }

        rateOfFire_ -= Time.deltaTime;

        if (isOn && durability > 0f)
        {
            Aim(target);
            if (useLazer)
            {
            }
            else
            {
                if (rateOfFire_ <= 0f)
                {
                    Fire();
                    rateOfFire_ = rateOfFire;
                }
            }

        }
    }

    public void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;

        foreach (GameObject enemy in enemies)
        {

            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }

    }

    public void UpdateBattery()
    {
        GameObject[] batteries = GameObject.FindGameObjectsWithTag("Battery");
        float shortestDistance = Mathf.Infinity;
        GameObject nearestBattery = null;

        foreach (GameObject battery in batteries)
        {
            float distanceToBattery = Vector3.Distance(transform.position, battery.transform.position);
            if (distanceToBattery < shortestDistance)
            {
                shortestDistance = distanceToBattery;
                nearestBattery = battery;
            }
        }

        if (nearestBattery != null && shortestDistance <= batteryRange)
        {
            if (nearestBattery.GetComponent<Battery>().currentCharge >= 5f)
            {
                isOn = true;
                nearestBattery.GetComponent<Battery>().Discharge(5f);
            }
            else
            {
                isOn = false;
            }
        }
        else
        {
            isOn = false;
        }
    }




    public void Aim(Transform target)
    {
        Vector3 dir = target.transform.position - transform.position;
        Quaternion lookRotation = Quaternion.LookRotation(dir);

        Vector3 rotation = Quaternion.Lerp(partToRotate.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        Debug.Log(rotation);
        partToRotate.rotation = Quaternion.Euler(0f, rotation.y, 0f);
    }

    void Fire()
    {
        GameObject newBullet = ObjectPoolScript.instance.GetPoolObject();
        if (newBullet == null)
        {
            return;
        }
        if (firingPoint == firingPoint1)
        {
            firingPoint = firingPoint2;

        }
        else if (firingPoint == firingPoint2)
        {
            firingPoint = firingPoint1;
        }
        newBullet.transform.position = firingPoint.position;
        newBullet.transform.rotation = firingPoint.rotation;
        newBullet.SetActive(true);
        newBullet.GetComponent<Projectile>().SetTarget(target);
        durability -= durabilityLossPerShot;
        durabilityBar.fillAmount = durability / startDurability;
    }


    public void TakeDamage(float damageTaken)
    {

    }

    public void Heal(float amountHealed)
    {
        if (durability + amountHealed > startDurability)
        {
            durability = startDurability;
        }
        else
        {
            durability += amountHealed;
        }
        durabilityBar.fillAmount = durability / startDurability;
    }

    public void Die()
    {

    }



    void OnTriggerEnter(Collider col)
    {
        GameObject go = col.gameObject;
        if (go.CompareTag("Battery"))
        {
            isOn = true;
        }
    }

    void OnTriggerStay(Collider col)
    {
        GameObject go = col.gameObject;
        Battery bat = null;
        if (go.CompareTag("Battery"))
        {
            bat = go.GetComponent<Battery>();
        }
        if (bat != null)
        {
            bat.Discharge(.1f);
        }
    }

    void OnTriggerExit(Collider col)
    {
        GameObject go = col.gameObject;
        if (go.CompareTag("Battery"))
        {
            isOn = false;
        }
    }
}
