using UnityEngine;

public class GunRotation : MonoBehaviour
{

    public int rotationOffset = 90;
    SpriteRenderer sr;
    public GameObject[] weapons;

    

    public int rotationFlipAngle;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
        
    }

    void Update()
    { 
        Vector3 difference = Camera.main.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        difference.Normalize();

        float rotZ = Mathf.Atan2(difference.y, difference.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ + rotationOffset);
        FlipWeapon(Vector2.SignedAngle(transform.right, Vector2.right));
    }

    void FlipWeapon(float rotation)
    {
        if (rotation < -90f || rotation > 90f)
        {
            sr.flipY = true;
            foreach (GameObject gm in weapons)
            {
                gm.gameObject.GetComponent<SpriteRenderer>().flipY = true;
            }
        }
        else
        {
            sr.flipY = false;
            foreach (GameObject gm in weapons)
            {
                gm.gameObject.GetComponent<SpriteRenderer>().flipY = false;
            }
        }
    }

    
   
}
