using UnityEngine;

public class Bullet : MonoBehaviour
{

    private Transform target;

    public float speed = 70f;
    public int damage = 10;
    public float damageRange = 0f;
    public GameObject explosionPrefab;

    public void Start()
    {
        if(explosionPrefab != null && damageRange != null)
        {
            explosionPrefab.transform.localScale = new Vector3(damageRange, damageRange, damageRange);
        }
    }

    public void Seek(Transform _target)
    {
        target = _target;
    }

    // Update is called once per frame
    void Update()
    {

        if ( target == null )
        {
            Destroy(gameObject);
            return;
        }

        Vector3 dir = target.position - transform.position;
        float distanceThisFrame = speed * Time.deltaTime;

        if ( dir.magnitude <= distanceThisFrame )
        {
            HitTarget();
            return;
        }

        transform.Translate(dir.normalized * distanceThisFrame, Space.World);
    }

    void HitTarget()
    {
        if(damageRange > 0)
        {
            Explosion(target.gameObject);
        } else
        {
            target.gameObject.GetComponentInChildren<Health>().takeDamage(damage);
        }

        Destroy(gameObject);
    }

    void Explosion(GameObject enemy)
    {
        Collider[] collidersInRange = Physics.OverlapSphere(enemy.transform.position, damageRange);

        foreach (Collider currentCollider in collidersInRange)
        {
            if (currentCollider.tag.Equals("Enemy"))
            {
                float damagePercent = Vector3.Distance(currentCollider.gameObject.transform.position, transform.position) / damageRange * 5.0f ;
                currentCollider.gameObject.GetComponentInChildren<Health>().takeDamage(damage * damagePercent);
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                Debug.Log(currentCollider.gameObject.transform.position);
            }
        }
    }
}