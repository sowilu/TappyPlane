using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour, IPausable
{
    public float cooldown = 2;
    public float speedMultiplayer = 1;
    public List<GameObject> obstaclePrefabs;
    
    
    void Start()
    {
        StartCoroutine(Spawn());
    }
    

    IEnumerator Spawn()
    {
        yield return new WaitForSeconds(cooldown);
        
        while (true)
        {
            if (IsPaused)
            {
                yield return new WaitForSeconds(cooldown);
                continue;
            }
            
            var prefab = obstaclePrefabs[Random.Range(0, obstaclePrefabs.Count)];
            var pos = prefab.transform.position;
            pos.x += Random.Range(-1.5f, 1.6f);
            pos.y += Random.Range(-0.7f, 0.8f);
            Instantiate(prefab, pos, Quaternion.identity);
                    
            yield return new WaitForSeconds(cooldown);
        }
        
    }

    public bool IsPaused { get; set; }
    public void OnPause()
    {
        IsPaused = true;
        Scroller.SpeedMultiplier = 0;
    }

    public void OnResume()
    {
        IsPaused = false;
        Scroller.SpeedMultiplier = speedMultiplayer;
    }
}
