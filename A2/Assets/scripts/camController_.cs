using UnityEngine;

public class camController_ : MonoBehaviour
{
    public float moveSmooth;
    public float rotSmooth;


    public Vector3 moveOffset;
    public Vector3 rotOffset;

    public Transform carTarget; 

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.T))
        {
            Debug.Log("Switching!");
            moveOffset.z = 2; moveOffset.y = 1; rotOffset.x=180;
        }if (Input.GetKeyUp(KeyCode.T))
        {
            moveOffset.z = -4; moveOffset.y = 5; rotOffset.x = 0;
        }
    }
    void FixedUpdate()
    {
        followTarget();
    }

    void followTarget()
    {
        HandleMovement();
        HandleRotation();
    }

    void HandleMovement()
    {
        Vector3 targetPos = new Vector3();

        targetPos=carTarget.TransformPoint(moveOffset);

        transform.position = Vector3.Lerp(transform.position, targetPos, moveSmooth*Time.deltaTime);
    }
    void HandleRotation()
    {
        var direction = carTarget.position - transform.position;
        var rotation = new Quaternion();

        rotation= Quaternion.LookRotation(direction+rotOffset,Vector3.up);

        transform.rotation = Quaternion.Lerp(transform.rotation,rotation,rotSmooth*Time.deltaTime);
    }

}
