using UnityEngine;

public class PourCollider : MonoBehaviour
{
    public Animator pouring;
    void OnTriggerEnter2D(Collider2D other) {
        if(other.CompareTag("DropArea")){
            pouring.SetTrigger("Pour");
        }

    }
}
