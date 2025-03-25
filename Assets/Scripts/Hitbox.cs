using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Hitbox : MonoBehaviour
{

    [SerializeField] private GameObject sliced;
    [SerializeField] private SlicableCarrot slicable;


    public void OnMouseExit() {
        if(slicable.getSlicedObject() == null){
            slicable.setSlicedObject(sliced);
            slicable.Slice();
        }
    }
}
