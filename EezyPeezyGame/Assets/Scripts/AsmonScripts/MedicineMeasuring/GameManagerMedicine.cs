using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManagerMedicine : MonoBehaviour
{
    [SerializeField] private Image glassOfWater;
    [SerializeField] private Text[] medicineText;
    [SerializeField] private Button[] medicineJar;
    [SerializeField] private Button[] whichJar;

    private Button selectedButton;

    private float blueDropCount;
    private float redDropCount;
    private float yellowDropCount;

    public float redDropsNeeded;
    public float blueDropsNeeded;
    public float yellowDropsNeeded;

    public bool redJarActive = false;
    public bool blueJarActive = false;
    public bool yellowJarActive = false;


    private bool activeMedicine;


    void Start()
    {
        JarDropCount();
    }

    
    void Update()
    {
        
    }

    public void JarDropCount()
    {
        blueDropCount = Random.Range(1, 7);
        medicineText[1].text = blueDropCount.ToString("Blue: " + blueDropCount);
        blueDropsNeeded = blueDropCount;

        redDropCount = Random.Range(1, 7);
        medicineText[0].text = redDropCount.ToString("Red: " + redDropCount);
        redDropsNeeded = redDropCount;

        yellowDropCount = Random.Range(1, 7);
        medicineText[2].text = yellowDropCount.ToString("Yellow: " + yellowDropCount);
        yellowDropsNeeded = yellowDropCount;
    }

    public void AddingDrops()
    {
        
    }

    public void Drops()
    {
        redDropCount--;
        medicineText[0].text = redDropCount.ToString("Red: " + redDropCount);
        Debug.Log("Hyvä hyvä");
        if(redDropCount == 0)
        {
            Debug.Log("VITTU JEE");
            redJarActive = false;
        }

        blueDropCount--;
        medicineText[1].text = blueDropCount.ToString("Blue: " + blueDropCount);
        Debug.Log("SININEN");
        if(blueDropCount == 0)
        {
            Debug.Log("OUJEE");
            blueJarActive = false;     
        }
    }

    
        
}
