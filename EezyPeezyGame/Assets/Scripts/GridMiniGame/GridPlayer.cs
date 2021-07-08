using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GridPlayer : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask stopMovement;

    [SerializeField] private List<Vector3> playerPositions = new List<Vector3>();
    [SerializeField] private Vector3 oldPos;
    [SerializeField] private bool setNewLocation;
    public int nextSpot = 0;
    // Start is called before the first frame update
    void Start()
    {
        movePoint.parent = null;
        oldPos = movePoint.position;
       
    }

    // Update is called once per frame
    void Update()
    {
       
       //If player has set enough positions for movement
        if (playerPositions.Count==5)
        {
            //If player has reached the final position on positions list, clear list 
            if (Vector3.Distance(transform.position, playerPositions[4]) <= 0.05f)
            {
                playerPositions.Clear();
                nextSpot = 0;
                return;
            }
            //Look for first position on positions list and move there
            transform.position = Vector3.MoveTowards(transform.position, playerPositions[nextSpot], moveSpeed * Time.deltaTime);
            //Go through all positions in list and check if player is close to x position and move player there
            for (int i = 0; i < playerPositions.Count; i++)
            {
                if (Vector3.Distance(transform.position, playerPositions[nextSpot]) <= 0.05f)
                {
                    nextSpot++;
                    transform.position = Vector3.MoveTowards(transform.position, playerPositions[nextSpot], moveSpeed * Time.deltaTime);
                }
            }
        }
        //Depending on player input, move empty object in scene and add its position to positions list
        if (Vector3.Distance(oldPos, movePoint.position) <= 0.05f)
        {
            if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
            {
                movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f)*4;
                playerPositions.Add(movePoint.position);
                setNewLocation = true;

            }
            else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
            {
                movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f)*4;
                playerPositions.Add(movePoint.position);
                setNewLocation = true;
            }
            
        }
        //Wait a moment to set new position or else there is multiple inputs to positions list
        if(setNewLocation)
        {
            StartCoroutine(Wait());
        }
        
    }

    IEnumerator Wait()
    {
        setNewLocation = false;
        yield return new WaitForSeconds(0.3f);
        oldPos = movePoint.position; 
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall, resetting scene");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            Debug.Log("Level finished");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);

        }
    }
}
