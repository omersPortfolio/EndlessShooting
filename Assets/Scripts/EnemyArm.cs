using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyArm : MonoBehaviour
{
    GameObject target; 
    public float enemyAimSpeed = 5.0f; // Speed at Which Enenmy locks on the Target
    Quaternion newRotation;
    float orientTransform;
    float orientTarget;
    public SpriteRenderer weapon;

    private void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player");
    }

    void Update()
    {
        if (target == null) return;

        orientTransform = transform.position.x;
        orientTarget = target.transform.position.x;

        // To Check on which side is the target , i.e. Right or Left of this Object
        if (orientTransform > orientTarget)
        {
            // Will Give Rotation angle , so that Arrow Points towards that target
            newRotation = Quaternion.LookRotation(transform.position - target.transform.position, -Vector3.up);
            weapon.flipY = true;
        }
        else
        {
            newRotation = Quaternion.LookRotation(transform.position - target.transform.position, Vector3.up);
           
            weapon.flipY = false;
        }

        // Here we have to freeze rotation along X and Y Axis, for proper movement of the arrow
        newRotation.x = 0.0f;
        newRotation.y = 0.0f;

        // Finally rotate and aim towards the target direction using Code below
        transform.rotation = Quaternion.Lerp(transform.rotation, newRotation, Time.deltaTime * enemyAimSpeed);

        // Another Alternative
        //transform.rotation = Quaternion.RotateTowards(transform.rotation, newRotation, Time.deltaTime * enemyAimSpeed);
    }
}
   
