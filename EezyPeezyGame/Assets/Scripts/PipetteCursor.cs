using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script controls the cursor in the medicine measuring game. It changes the default cursor into pipette and changes the pipette sprite depending on which medicine jar the player clicks.

public class PipetteCursor : MonoBehaviour
{
    public Texture2D pipetteEmpty, pipetteRed, pipetteBlue, pipetteYellow;
    public Vector2 hotSpot = Vector2.zero;

    private GameManagerMedicine GMM;

    

    void Start()
    {
        // At the beginning the pipette is empty
        GMM = GetComponent<GameManagerMedicine>();
        Cursor.SetCursor(pipetteEmpty, hotSpot, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        // when pressing the left mouse button a ray is casted from the mouse position
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                          Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            
            // checking the tag of ray cast hit target and if pressed, it changes the corresponding colored pipette cursor
            if (hit.transform.gameObject.CompareTag("Red"))
            {
                Debug.Log("rayhit red");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Red");
                    Cursor.SetCursor(pipetteRed, hotSpot, CursorMode.ForceSoftware);
                }
            }

            if (hit.transform.gameObject.CompareTag("Blue"))
            {
                Debug.Log("rayhit blue");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Blue");
                    Cursor.SetCursor(pipetteBlue, hotSpot, CursorMode.ForceSoftware);
                }
            }

            if (hit.transform.gameObject.CompareTag("Yellow"))
            {
                Debug.Log("rayhit Yellow");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Yellow");
                    Cursor.SetCursor(pipetteYellow, hotSpot, CursorMode.ForceSoftware);
                }
            }

            if (hit.transform.gameObject.CompareTag("Empty"))
            {
                Debug.Log("rayhit Empty");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Empty");
                    Cursor.SetCursor(pipetteEmpty, hotSpot, CursorMode.ForceSoftware);
                }
            }
        }
    }


}
