using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("References")]
    public Mana manaScript;
    [Header("Move")]
    [SerializeField] private float speed;
    [Header("Shoot")]
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float fireSpeed;
    [SerializeField] private float lastFired;
    [SerializeField] private float shootCost;

    private void Update()
    {
        Move();
        Rotate();
        Shoot();
    }

    private void Move()
    {
        // WASD movement
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical);
        transform.Translate(movement * -speed * Time.deltaTime, Space.World);
    }

    private void Rotate()
    {
        RaycastHit hit;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hit))
        {
            transform.LookAt(new Vector3(hit.point.x, transform.position.y, hit.point.z));
        }
    }

    private void Shoot()
    {
        if (Input.GetButton("Fire1"))
        {
            if (manaScript.mana >= shootCost)
            {
                SpawnBullet();
            }
        }
    }

    private void SpawnBullet()
    {
        if (lastFired + fireSpeed < Time.time)
        {
            lastFired = Time.time;
            GameObject a = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation) as GameObject;
            a.transform.SetParent(GameObject.Find("Clones").transform);
            manaScript.LoseMana(shootCost);
        }
    }
}


// transform.position += transform.right * (MobileInputManager.Instance.joystick.Axis.x * Time.DeltaTime);
// Vector2.joystickAxis = MobileInputManager.GetJoystickAxis();