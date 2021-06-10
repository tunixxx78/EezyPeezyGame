using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyBrush : MonoBehaviour
{
    public void GetRidOfBrushClone()
    {
        Destroy(this.gameObject);
    }
}
