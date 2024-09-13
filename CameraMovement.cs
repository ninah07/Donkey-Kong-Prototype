using UnityEngine; 

public class CameraMovement : MonoBehaviour
{

    public Transform character;
    Vector3 offset; 

    void Start()
    {
        offset = transform.position - character.position;  
    }

    void Update()
    {
        Vector3 targetPos = character.position + offset;
        targetPos.x = 0;
        transform.position = targetPos; 
    }
}
