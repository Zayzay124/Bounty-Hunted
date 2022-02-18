using UnityEngine;
using UnityEngine.SceneManagement;


public class PlayerMovement : MonoBehaviour
{

    public CharacterController controller;

    public int attackDamage = 50;

    public float speed = 8f;
    public float gravity = -9.81f;
    public float jumpHeight = 2f;
    public float groundDistance = 0.4f;
    public float attackRange = 0.5f;
    public float bulletsLoaded = 8;
    //public float bulletsSpare = 8;

    public LayerMask groundMask;
    public LayerMask enemyLayers;
    
    public Transform groundCheck;
    public Transform attackPoint;

    bool isGrounded;

    Vector3 velocity;
    Vector3 origPosition;

    Collider  col;
    Rigidbody rb;

    public GameObject player;
    public GameObject bulletPrefab;
    public GameObject CheckPoint;
    public GameObject WeaponHolder;
    //public GameObject Revolver;
    public GameObject bulletSpawn;

    public AudioSource Shooting;
    public float delay;
    public AudioSource Stabbing;

    Quaternion bulletRot = Quaternion.Euler(90, 0, 0);

    void Start()
    {
        origPosition = transform.position;
       // InvokeRepeating("RecoilRecovery", 1f, 0.1f);
    }

    void Update()
    {
        transform.rotation = Quaternion.Euler(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, 0f); // locks z-axis rotation

        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        Debug.Log(bulletsLoaded);

        if (isGrounded && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        controller.Move(move * speed * Time.deltaTime);

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
         
        CheckInput();

        //bulletSpawn.transform.position = new Vector3(Revolver.transform.position.x, Revolver.transform.position.y, Revolver.transform.position.z);
        //bulletSpawn.transform.rotation. = Revolver.transform.rotation.x;
        //  = new Vector3(, Revolver.transform.rotation.y, Revolver.transform.rotation.z);
    }

    void CheckInput()
    {
        if (WeaponHolder.GetComponent<WeaponSwitching>().selectedWeapon == 0 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Fire();
            AudioSource Shooting = GetComponent<AudioSource>();
            Shooting.Play();
        }
        else if (WeaponHolder.GetComponent<WeaponSwitching>().selectedWeapon == 1 && Input.GetKeyDown(KeyCode.Mouse0))
        {
            Slash();
            Stabbing.Play();
        }
    }


    void Fire() {
        GameObject bullet = Instantiate(bulletPrefab, bulletSpawn.transform.position, bulletSpawn.transform.rotation);
        //bullet goes foward because quatornian is always its spawn
    }

       
    void Slash()
    {
        //detects enemies
        Collider[] hitEnemies  = Physics.OverlapSphere(attackPoint.position, attackRange, enemyLayers);
        //damages them
        foreach(Collider enemy in hitEnemies)
        {
            //Debug.Log("we hit");
            enemy.GetComponent<EnemyMove>().TakeDamage(attackDamage);
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }

    public void GoLastCheck()
    {
        transform.position = CheckPoint.GetComponent<Reset>().lastCheckPos;
    }

    public void ResetPosition()
    {
        transform.position = origPosition;
        rb.velocity = Vector3.zero;
    }
}