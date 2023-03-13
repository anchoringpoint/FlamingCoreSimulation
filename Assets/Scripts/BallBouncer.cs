using System;
using UnityEngine;
using TMPro;
public class BallBouncer : MonoBehaviour
{
    [SerializeField]
    [Tooltip("Just for debugging, adds some velocity during OnEnable")]
    private Vector3 initialVelocity;

    [SerializeField]
    private float minVelocity = 10f;

    public GameObject winTextObject;
    public TextMeshProUGUI countText;
    private  bool isGhost=false;
    [SerializeField] private  Trajectory _trajectory;
    private Vector3 lastFrameVelocity;
    private Rigidbody rb;
    public int counter;
    private  int pickUpCounter;
    public WorldMask worldMask;
    Vector2 LastMousePos;
    Vector2 NowMousePos;
    Vector2 distance;
    private void OnEnable()
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = initialVelocity*minVelocity;
        
    }

    private void Start()
    {
        pickUpCounter = 0;
        SetCountText();
        winTextObject.SetActive(false);
    }
    
    void SetCountText()
    {
        countText.text = "Count: " + pickUpCounter.ToString();
        if(pickUpCounter>= 4)
        {
            winTextObject.SetActive(true);
        }
    }
    public void init(Vector3 velocity, bool isGhost)
    {
        rb = GetComponent<Rigidbody>();
        rb.velocity = velocity;
        this.isGhost = isGhost;
    }
    private void Update()
    {
        lastFrameVelocity = rb.velocity;
   
        if(Input.GetMouseButtonDown(0))
        {
            GetComponent<LineRenderer>().enabled = true;
            LastMousePos = Input.mousePosition;
  
            Time.timeScale = 0.01f;
        }
        if (Input.GetMouseButton(0))
        {
            NowMousePos = Input.mousePosition;
       
            distance = NowMousePos - LastMousePos;
            //rb.AddForce(new Vector3(distance.x, 0, distance.y) *(5f));
            Vector3 velocity=new Vector3(distance.x, 0, distance.y) *(minVelocity*0.03f);
            _trajectory.SimulateTrajectory(this,transform.position,velocity);
        }

        if (Input.GetMouseButtonUp(0))
        {
            Time.timeScale = 1;
            distance = NowMousePos - LastMousePos;
            //rb.AddForce(new Vector3(distance.x, 0, distance.y) *(5f));
            rb.velocity=new Vector3(distance.x, 0, distance.y) *(minVelocity*0.03f);
            GetComponent<LineRenderer>().enabled = false;
        }
        
    }

    
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("PickUp"))
        {
            other.gameObject.SetActive(false);
            pickUpCounter++;
            SetCountText();
        }
        if (other.gameObject.CompareTag("ReversePlayerDirTrap"))
        {
            
            other.gameObject.SetActive(false);
            minVelocity = -minVelocity;
        }
    

    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
            collision.gameObject.SetActive(false);
    }
}