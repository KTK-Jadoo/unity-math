using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public float speed;
    public Camera gameCamera;
    public Transform objectToPlace;
    Ray ray;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 displacement = new Vector3(Input.GetAxisRaw("Horizontal"), 0, Input.GetAxisRaw("Vertical"));
        
        Vector3 velocity = displacement.normalized * speed;

        transform.Translate(velocity * Time.deltaTime);



        ray = gameCamera.ScreenPointToRay(Input.mousePosition);

        RaycastHit hitInfo;

        if (Physics.Raycast(ray, out hitInfo))
        {
            objectToPlace.transform.SetPositionAndRotation(hitInfo.point, Quaternion.FromToRotation(Vector3.up, hitInfo.normal));
        }


    }
}
