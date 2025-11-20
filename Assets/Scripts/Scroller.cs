using UnityEngine;

public class Scroller : MonoBehaviour
{
    public static float SpeedMultiplier = 1;
    
    [Header("Movement")]
    public float speed = 5;
    
    [Header("Lifespan")]
    public bool selfDestruct = false;
    public Vector3 startPoint = new(11, 3.6f, 0);
    public Vector3 endPoint = new(-11, 3.6f, 0);
    

    void Update()
    {
        transform.Translate(Vector2.left * speed * SpeedMultiplier * Time.deltaTime);
        
        if (transform.position.x < endPoint.x) 
            if(selfDestruct) Destroy(gameObject);
            else transform.position = startPoint;
    }
}
