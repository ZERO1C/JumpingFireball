using UnityEngine;
using UnityEngine.UI;

public class DoorController : MonoBehaviour
{
    private Animation doorAnim;

    private void Start()
    {
        doorAnim = transform.parent.gameObject.GetComponent<Animation>();
    }

    private void OnTriggerEnter(Collider other)
    {
        doorAnim.Play("Door_Open");
    }

}
