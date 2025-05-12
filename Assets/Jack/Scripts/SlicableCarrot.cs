using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SlicableCarrot : MonoBehaviour
{
    private GameObject slicedObject;
    [SerializeField] private GameObject unslicedObject;

    public void setSlicedObject(GameObject slicedObject){
        this.slicedObject = slicedObject;
    }

    public GameObject getSlicedObject(){
        return slicedObject;
    }

    public void Slice(){
        Debug.Log("slice!");
        unslicedObject.SetActive(false);
        slicedObject.SetActive(true);
    }
}
