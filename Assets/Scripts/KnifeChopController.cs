using UnityEngine;

public class KnifeChopController : MonoBehaviour
{
    public Animator knifeAnimator;  // Reference to the Animator
    public float movementSpeed = 1f;
    public GameObject carrotMask;

    void Start()
    {
        // Get the Animator component if not assigned in the Inspector
        if (knifeAnimator == null)
        {
            knifeAnimator = GetComponent<Animator>();
        }
    }

    void Update()
    {
        // Trigger the chop animation on spacebar press
        if (Input.GetKeyDown(KeyCode.Space))
        {
            transform.Translate(Vector2.left * movementSpeed * Time.deltaTime);
            carrotMask.transform.Translate(Vector2.right * movementSpeed * Time.deltaTime);
            knifeAnimator.SetTrigger("Chop");  // Trigger the "Chop" animation
        }
    }
}
