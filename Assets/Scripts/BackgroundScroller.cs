using UnityEngine;

public class BackgroundScroller : MonoBehaviour, IPausable
{
    public bool IsPaused { get; set; }
    
    public Vector2 scrollSpeed = new Vector2(0.2f, 0f);
    public float paralaxScale = 0.5f;

    private Material runtimeMat;


    void Start()
    {
        runtimeMat = GetComponent<Renderer>().material;
    }

    void Update()
    {
        if (IsPaused) return;
        
        Vector2 offset = runtimeMat.mainTextureOffset + scrollSpeed * (Scroller.SpeedMultiplier * paralaxScale) * Time.deltaTime;
        runtimeMat.mainTextureOffset = offset;
    }

    public void OnPause()
    {
        IsPaused = true;
    }

    public void OnResume()
    {
        IsPaused = false;
    }
}