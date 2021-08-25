using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameManagerMedicine : MonoBehaviour
{
    [SerializeField] private GameObject emptyVial;
    [SerializeField] private TMP_Text[] medicineText;
    [SerializeField] private Button[] medicineJar;
    [SerializeField] private Button[] whichJar;

    private PipetteCursor pcScript;

    private Button selectedButton;

    private float blueDropCount;
    public float redDropCount;
    private float yellowDropCount;

    public float redDropsNeeded;
    public float blueDropsNeeded;
    public float yellowDropsNeeded;

    public int redDrops;
    public int blueDrops;
    public int yellowDrops;

    public bool redActive = false;
    public bool blueActive = false;
    public bool yellowActive = false;


    private bool activeMedicine;


    void Start()
    {
        pcScript = GetComponent<PipetteCursor>();
        JarDropCount();
    }

    
    void Update()
    {
        
    }

    public void JarDropCount()
    {
        blueDropCount = Random.Range(1, 7);
        medicineText[1].text = blueDropCount.ToString();
        blueDropsNeeded = blueDropCount;

        redDropCount = Random.Range(1, 7);
        medicineText[0].text = redDropCount.ToString();
        redDropsNeeded = redDropCount;

        yellowDropCount = Random.Range(1, 7);
        medicineText[2].text = yellowDropCount.ToString();
        yellowDropsNeeded = yellowDropCount;
    }

    public void AddingDrops()
    {
        
    }

    



    public void Drops()
    {
        redDropCount--;
        medicineText[0].text = redDropCount.ToString("" + redDropCount);
        Debug.Log("Hyvä hyvä");
        if (redDropCount == 0)
        {
            Debug.Log("VITTU JEE");
            redActive = false;
        }
        

        //blueDropCount--;
        //medicineText[1].text = blueDropCount.ToString("" + blueDropCount);
        //Debug.Log("SININEN");
        //if(blueDropCount == 0)
        //{
        //    Debug.Log("OUJEE");
        //    blueActive = false;     
        //}
    }


}
