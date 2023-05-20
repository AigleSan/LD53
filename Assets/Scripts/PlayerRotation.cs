using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerRotation : MonoBehaviour
{
    public float rotationSpeed;

    [HideInInspector] public Quaternion playerRotation;

    void Update()
    {
        LookAtMouse();
    }

    void LookAtMouse()
    {
        Plane playerPlane = new Plane(Vector3.up, transform.position);
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        float hitdist;

        if (playerPlane.Raycast(ray, out hitdist))
        {
            Vector3 targetpoint = ray.GetPoint(hitdist);
            Quaternion targetrotation = Quaternion.LookRotation(targetpoint - transform.position);
            transform.rotation = Quaternion.Slerp(
                transform.rotation,
                targetrotation,
                rotationSpeed * Time.deltaTime
            );
            playerRotation = transform.rotation;
        }
    }
}
