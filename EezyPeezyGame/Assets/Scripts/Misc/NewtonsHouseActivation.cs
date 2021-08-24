using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewtonsHouseActivation : MonoBehaviour
{
    [SerializeField] private GameObject newtonsHouseActive;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(DataHolder.dataHolder.gridNavigationDone)
        {
            newtonsHouseActive.SetActive(true);
        }
        else
        {
            newtonsHouseActive.SetActive(false);

        }
    }
}
