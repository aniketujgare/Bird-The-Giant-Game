using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectablesScript : MonoBehaviour
{
    void OnEnable()
    {
        Invoke("DestroyCOllectable", 6f); 
    }
    void DestroyCOllectable()
    {
        gameObject.SetActive(false);
    }
}

