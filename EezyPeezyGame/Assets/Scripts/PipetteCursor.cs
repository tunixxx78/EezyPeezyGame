using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipetteCursor : MonoBehaviour
{
    public Texture2D pipetteEmpty, pipetteRed, pipetteBlue, pipetteYellow;
    public Vector2 hotSpot = Vector2.zero;

    private GameManagerMedicine GMM;

    

    void Start()
    {
        GMM = GetComponent<GameManagerMedicine>();
        Cursor.SetCursor(pipetteEmpty, hotSpot, CursorMode.ForceSoftware);
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 origin = new Vector2(Camera.main.ScreenToWorldPoint(Input.mousePosition).x,
                                          Camera.main.ScreenToWorldPoint(Input.mousePosition).y);
            RaycastHit2D hit = Physics2D.Raycast(origin, Vector2.zero, 0f);

            

            if (hit.transform.gameObject.CompareTag("Red"))
            {
                Debug.Log("rayhit red");
                if (Input.GetMouseButtonDown(0))
                {
                    Debug.Log("Clicked Red");
                    Cursor.SetCursor(pipetteRed, hotSpot, CursorMode.ForceSoftware);
                    GMM.redActive = true;

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

            //if (hit.transform.gameObject.CompareTag("Empty"))
            //{
            //    Debug.Log("rayhit Empty");
            //    if (Input.GetMouseButtonDown(0))
            //    {
            //        Debug.Log("Clicked Empty");
            //        Cursor.SetCursor(pipetteEmpty, hotSpot, CursorMode.ForceSoftware);
            //    }
            //}
        }
    }


}
