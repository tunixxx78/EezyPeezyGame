using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricWireScript : MonoBehaviour
{
    private float[] rotations = { 0, 90, 180, 270 };

    public float[] correctRotation;
    [SerializeField] private bool isPlaced = false;

    private int possibleRoations = 1;

    ElectricWiresGameManager wireGameManager;

    [SerializeField] Sprite filledPipe;

    private void Awake()
    {
        wireGameManager = GameObject.Find("ElectricWireGameManager").GetComponent<ElectricWiresGameManager>();
    }

    private void Start()
    {
        
        possibleRoations = correctRotation.Length;

        int rand = Random.Range(0, rotations.Length);
        transform.eulerAngles = new Vector3(0, 0, rotations[rand]);

        if (possibleRoations > 1)
        {
            if ((int)transform.eulerAngles.z == correctRotation[0] || (int)transform.eulerAngles.z == correctRotation[1])
            {
                isPlaced = true;
                wireGameManager.CorrectMove();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = filledPipe;
            }

        }
        else
        {
            if (transform.eulerAngles.z == correctRotation[0])
            {
                isPlaced = true;
                wireGameManager.CorrectMove();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = filledPipe;
            }
        }


    }

    private void OnMouseDown()
    {
        transform.Rotate(new Vector3(0, 0, 90));

        if (possibleRoations > 1)
        {
            if ((int)transform.eulerAngles.z == correctRotation[0] || (int)transform.eulerAngles.z == correctRotation[1] && isPlaced == false)
            {
                Debug.Log(transform.eulerAngles.z);
                isPlaced = true;
                wireGameManager.CorrectMove();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = filledPipe;

            }
            else if (isPlaced == true)
            {
                Debug.Log(transform.eulerAngles.z);
                isPlaced = false;
                wireGameManager.WrongMove();
            }
        }
        else
        {
            if ((int)transform.eulerAngles.z == correctRotation[0] && isPlaced == false)
            {
                Debug.Log(transform.eulerAngles.z);
                isPlaced = true;
                wireGameManager.CorrectMove();
                this.gameObject.GetComponent<SpriteRenderer>().sprite = filledPipe;

            }
            else if (isPlaced == true)
            {
                Debug.Log(transform.eulerAngles.z);
                isPlaced = false;
                wireGameManager.WrongMove();
            }
        }

    }
}
