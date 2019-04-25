using UnityEngine;
using System.Collections;

public class NewMovement : MonoBehaviour
{
    private Animator animator;
    [SerializeField] private float runSpeed = 8f;                                       
    [SerializeField] private float strafeSpeed = 4f;                                    
    [SerializeField] private float jumpPower = 5f;                                      

    [SerializeField] private AdvancedSettings advanced = new AdvancedSettings();        
    [SerializeField] private bool lockCursor = true;

    [System.Serializable]
    public class AdvancedSettings                                                       
    {
        public float gravityMultiplier = 1f;                                           
        public PhysicMaterial zeroFrictionMaterial;                                     
        public PhysicMaterial highFrictionMaterial;                                    
        public float groundStickyEffect = 5f;                                           
    }

    private CapsuleCollider capsule;                                                    
    private const float jumpRayLength = 0.7f;                                          
    public bool grounded { get; private set; }
    private Vector2 input;
    private IComparer rayHitComparer;

    void Awake()
    {
        
        capsule = GetComponent<Collider>() as CapsuleCollider;
        grounded = true;
        rayHitComparer = new RayHitComparer();
        animator = GetComponentInChildren<Animator>();
        if (lockCursor)
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        else
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }

    void OnDisable()
    {
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
    }

    void Update()
    {
        if (Input.GetMouseButtonUp(0))
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


    public void FixedUpdate()
    {
        float speed = runSpeed;

        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");
        bool jump = Input.GetButton("Jump");
        animator.SetFloat("Speed", v);
        input = new Vector2(h, v);

       
        if (input.sqrMagnitude > 1) input.Normalize();

        
        Vector3 desiredMove = transform.forward * input.y * speed + transform.right * input.x * strafeSpeed;
        
        float yv = GetComponent<Rigidbody>().velocity.y;

        
        if (grounded && jump)
        {
            yv += jumpPower;
            grounded = false;
        }

        GetComponent<Rigidbody>().velocity = desiredMove + Vector3.up * yv;

        
        if (desiredMove.magnitude > 0 || !grounded)
        {
            GetComponent<Collider>().material = advanced.zeroFrictionMaterial;
        }
        else
        {
            GetComponent<Collider>().material = advanced.highFrictionMaterial;
        }


        
        Ray ray = new Ray(transform.position, -transform.up);

       
        RaycastHit[] hits = Physics.RaycastAll(ray, capsule.height * jumpRayLength);
        System.Array.Sort(hits, rayHitComparer);


        if (grounded || GetComponent<Rigidbody>().velocity.y < jumpPower * .5f)
        {
            
            grounded = false;
            
            for (int i = 0; i < hits.Length; i++)
            {
                
                if (!hits[i].collider.isTrigger)
                {
                    
                    grounded = true;

                    
                    GetComponent<Rigidbody>().position = Vector3.MoveTowards(GetComponent<Rigidbody>().position, hits[i].point + Vector3.up * capsule.height * .5f, Time.deltaTime * advanced.groundStickyEffect);
                   
                    GetComponent<Rigidbody>().velocity = new Vector3(GetComponent<Rigidbody>().velocity.x, 0, GetComponent<Rigidbody>().velocity.z);
                    break;
                }
            }
        }

        Debug.DrawRay(ray.origin, ray.direction * capsule.height * jumpRayLength, grounded ? Color.green : Color.red);


  
        GetComponent<Rigidbody>().AddForce(Physics.gravity * (advanced.gravityMultiplier - 1));
    }


 
    class RayHitComparer : IComparer
    {
        public int Compare(object x, object y)
        {
            return ((RaycastHit)x).distance.CompareTo(((RaycastHit)y).distance);
        }
    }

}