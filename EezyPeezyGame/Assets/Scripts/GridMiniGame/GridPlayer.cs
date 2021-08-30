using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GridPlayer : MonoBehaviour
{
    
    [SerializeField] private float moveSpeed;
    [SerializeField] private Transform movePoint;
    [SerializeField] private LayerMask stopMovement;

    [SerializeField] private List<Vector3> playerPositions = new List<Vector3>();
    
    [SerializeField] private Vector3 oldPos;
    [SerializeField] private bool setNewLocation, allowMove, levelDone;
    [SerializeField] private GameObject leftArrow, rightArrow, upArrow, downArrow;

    [SerializeField] private GameObject[] locations;
    [SerializeField] private GameObject[] buildings;
    [SerializeField] private GameObject wrongWayPanel, gameFinishedPanel, ghost;

    public int nextSpot = 0;
    // Start is called before the first frame update
    void Start()
    {
        levelDone = false;
        allowMove = true;
        movePoint.parent = null;
        oldPos = movePoint.position;

        wrongWayPanel.SetActive(false);
        gameFinishedPanel.SetActive(false);

        Reshuffle(locations);

        for (int i = 0; i < locations.Length; i++)
        {
            buildings[i].transform.position = locations[i].transform.position;
        }
      
      
    }
    void Reshuffle(GameObject[] locations)
    {
        // Knuth shuffle algorithm :: courtesy of Wikipedia :)
        for (int t = 0; t < locations.Length; t++)
        {
            var tmp = locations[t];
            int r = Random.Range(t, locations.Length);
            locations[t] = locations[r];
            locations[r] = tmp;
        }
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
                allowMove = false;
                if (!levelDone) { Instantiate(ghost, transform); }
                
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
        if (allowMove && playerPositions.Count < 5)
        {
            //Depending on player input, move empty object in scene and add its position to positions list
            if (Vector3.Distance(oldPos, movePoint.position) <= 0.05f)
            {
                if (Input.GetKeyDown(KeyCode.A) || Input.GetKeyDown(KeyCode.LeftArrow))
                {
                    Instantiate(rightArrow, movePoint.transform);
                    if(movePoint.childCount>1)
                    {
                        Destroy(movePoint.GetChild(0).gameObject);
                    }

                }
                if (Input.GetKeyDown(KeyCode.D) || Input.GetKeyDown(KeyCode.RightArrow))
                {
                    Instantiate(leftArrow, movePoint.transform);
                    if (movePoint.childCount > 1)
                    {
                        Destroy(movePoint.GetChild(0).gameObject);
                    }

                }
                if (Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow))
                {
                    Instantiate(upArrow, movePoint.transform);
                    if (movePoint.childCount > 1)
                    {
                        Destroy(movePoint.GetChild(0).gameObject);
                    }

                }
                if (Input.GetKeyDown(KeyCode.S) || Input.GetKeyDown(KeyCode.DownArrow))
                {
                    Instantiate(downArrow, movePoint.transform);
                    if (movePoint.childCount > 1)
                    {
                        Destroy(movePoint.GetChild(0).gameObject);
                    }
                }
                if (Mathf.Abs(Input.GetAxisRaw("Horizontal")) == 1f)
                {
                   
                    movePoint.position += new Vector3(Input.GetAxisRaw("Horizontal"), 0f, 0f) * 2f;
                    playerPositions.Add(movePoint.position);
                    setNewLocation = true;
                   

                    

                }
                else if (Mathf.Abs(Input.GetAxisRaw("Vertical")) == 1f)
                {
                   
                    movePoint.position += new Vector3(0f, Input.GetAxisRaw("Vertical"), 0f) * 2.5f;
                    playerPositions.Add(movePoint.position);
                    setNewLocation = true;

                }
                //Wait a moment to set new position or else there is multiple inputs to positions list
                if (setNewLocation)
                {
                    StartCoroutine(Wait());
                   
                }
            }
        }
        
    }

    IEnumerator Wait()
    {
        allowMove = false;
        setNewLocation = false;
        yield return new WaitForSeconds(0.4f);
        oldPos = movePoint.position;
        allowMove = true;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Wall"))
        {
            Debug.Log("Hit wall, resetting scene");
            wrongWayPanel.SetActive(true);
            playerPositions.Clear();
            nextSpot = 0;
            Invoke("ResetGame", 3f);
        }
        if (collision.gameObject.CompareTag("LevelEnd"))
        {
            DataHolder.dataHolder.gridNavigationDone = true;
            levelDone = true;
            gameFinishedPanel.SetActive(true);
            FindObjectOfType<SFXManager>().PlanetExplotion();
            Invoke("NextScene", 2f);
        }

    }

    public void ResetGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void NextScene()
    {
        if (SceneManager.GetActiveScene().name == "MapNavigation2")
        {
            SceneManager.LoadScene("RocketArcade");
        }
        else
        {
            SceneManager.LoadScene("NewtonsHouse");
        }
        
    }
}
