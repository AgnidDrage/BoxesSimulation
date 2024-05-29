using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEngine;

public class ClientBehaviour : MonoBehaviour
{

    public float baseSpeed = 0.2f;
    public Transform waitPos;
    public Transform destroyerPos;
    public CircleCollider2D cl;
    public BoxCollider2D bc;
    public GameManager gameManager;
    [SerializeField]
    public NormalDistribution normalDistribution;
    private bool isOnWaitPos = false;
    [SerializeField]
    private bool isOnBox = false;
    [SerializeField]
    private GameObject targetBox;
    [SerializeField]
    private double timeToWait;
    private bool timeToDie = false;



    private void Awake()
    {

    }

    // Start is called before the first frame update
    void Start()
    {
        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();
        normalDistribution = GameObject.Find("NormalDist").GetComponent<NormalDistribution>();
        waitPos = GameObject.Find("WaitPos").transform;
        destroyerPos = GameObject.Find("DestroyerPos").transform;
        timeToWait = normalDistribution.GenerateRandomValue();

        StartCoroutine(QueueWait());
    }

    // Update is called once per frame
    void Update()
    {

    }

    private void FixedUpdate()
    {
        if (isOnWaitPos == false && isOnBox == false)
        {
            GoToWaitPos();
        }
        if (isOnWaitPos == true && isOnBox == false)
        {
            GoToBox();
        }
        if (timeToDie == true)
        {
            Die();
        }
    }

    private void GoToWaitPos()
    {
        float speed = baseSpeed;
        // Detect if client have another client in front using the tag "Client"
        Collider2D[] hitColliders = Physics2D.OverlapCircleAll(cl.transform.position, cl.radius);
        foreach (var hitCollider in hitColliders)
        {
            if (hitCollider.tag == "Client")
            {
                // The client stops
                speed = 0f;
            }
            if (hitCollider.tag == "Waitpos")
            {
                // The client is on the WaitPos
                isOnWaitPos = true;
            }
        }

        // Move player to the Waitpos fixing the y
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(waitPos.position.x, transform.position.y, waitPos.position.z), speed * Time.timeScale);
    }

    private void GoToBox()
    {

        if (targetBox == null)
        {
            foreach (GameObject box in gameManager.boxesToActivate)
            {
                if (box.GetComponent<BoxBehaviour>().isActivated == true)
                {
                    // Set the box to be in use
                    targetBox = box;
                    targetBox.GetComponent<BoxBehaviour>().isActivated = false;
                    break;
                }
            }
        }

        if (targetBox != null)
        {
            Transform targetTransform = targetBox.transform;
            float speed = baseSpeed;
            // Detect if client reched the box
            if (transform.position == targetTransform.position)
            {
                // The client is on the box
                isOnBox = true;
                isOnWaitPos = false;
                StartCoroutine(WaitOnBox());
            }

            // Move player to the Waitpos fixing the y
            transform.position = Vector3.MoveTowards(transform.position, new Vector3(targetTransform.position.x, targetTransform.position.y, targetTransform.position.z), speed * Time.timeScale);
        }
    }

    IEnumerator WaitOnBox()
    {
        yield return new WaitForSeconds((float)timeToWait);
        // Set the box to be activated
        targetBox.GetComponent<BoxBehaviour>().isActivated = true;
        gameManager.assistedClients++;
        gameManager.clientCounter--;
        timeToDie = true;
    }

    private void Die()
    {
        cl.enabled = false;
        bc.enabled = false;
        // Move client to the DestroyerPos and destroy the client
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(destroyerPos.position.x, destroyerPos.position.y, destroyerPos.position.z), baseSpeed * Time.timeScale);
        if (transform.position == destroyerPos.position)
        {
            Destroy(gameObject);
        }
    }

    IEnumerator QueueWait()
    {
        yield return new WaitForSeconds(30);
        if (isOnWaitPos == false && isOnBox == false)
        {
            Destroy(gameObject);
            gameManager.lostClients++;
            gameManager.clientCounter--;
        }
    }
}
