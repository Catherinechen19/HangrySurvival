using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent (typeof(BoxCollider2D))]
public class EnemyController : MonoBehaviour
{
    //Reference to waypoints
    public List<Transform> points;
    [SerializeField] protected Transform pointA, pointB;
    //Int Value for the next point index
    public int nextID = 0;
    //Change value applied to ID
    int idChangeValue = 1;
    //speed
    public float speed = 30f;
    //target
    private Transform target;
    public GameObject GameOverText, RestartButton, blood;
    [SerializeField]private Animator anim;
    protected SpriteRenderer sprite;

    [SerializeField] private bool enemy2;

    private void Reset() 
    {
        Init();
    }

    void Init()
    {
        //BoxCollider Trigger
        GetComponent<BoxCollider2D>().isTrigger = true;

        //Create Root Object
        GameObject root = new GameObject(name + "_root");

        //Reset root position to enemy object 
        root.transform.position = transform.position;

        //set enemy object as child of root
        transform.SetParent(root.transform);

        //create waypoints object 
        GameObject waypoints = new GameObject("Waypoints");

        //reset waypoints position to root
        //Make waypoints object child of root
        waypoints.transform.SetParent(root.transform); 
        waypoints.transform.position = root.transform.position;

        //create 2 points (gameobj) & reset position to waypoint objects
        //set waypoint to child 
        GameObject p1 = new GameObject("Point A");
        p1.transform.SetParent(waypoints.transform);
        p1.transform.position = root.transform.position;

        GameObject p2 = new GameObject("Point B");
        p2.transform.SetParent(waypoints.transform);
        p2.transform.position = root.transform.position;

        //Init points list then add the points to it 
        points = new List<Transform>();
        points.Add(p1.transform);
        points.Add(p2.transform);

        //check target
        target = GameObject.FindWithTag("Player").transform;

        //menu
        GameOverText.SetActive (false);
        RestartButton.SetActive(false);

        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        NextPoint();
    }

    void NextPoint()
    {
        //NextPoint transform
        Transform goalPoint = points[nextID];

        if (enemy2)
        {
            //Flip enemy transform to the point direction
            if (goalPoint.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
        }
        else
        {
            //Flip enemy transform to the point direction
            if (goalPoint.transform.position.x > transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }


        //Move enemy towards the goal point 
        transform.position = Vector2.MoveTowards(transform.position, goalPoint.position, speed*Time.deltaTime);

        //Check distance between enemy and point to trigger the nextpoint
        if(Vector2.Distance(transform.position, goalPoint.position) < 1f)
        {
            //Check if we are at the end of the line (-1)
            if(nextID==points.Count -1)
            {
                idChangeValue = -1;
            }

            //Check if we are at the start of the line (+1)
            if(nextID== 0)
            {
                idChangeValue = 1;
            }

            //Apply the change on the nextID
            nextID += idChangeValue;
        }
    }

    private void OnTriggerEnter2D(Collider2D other) {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Collide");
            //gameObject.SetActive(false);
            GameOverText.SetActive(true);
            RestartButton.SetActive(true);
            //Instantiate(blood, transform.position, Quaternion.identity);
            
        }
    }
}
