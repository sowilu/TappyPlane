using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Instructions : MonoBehaviour, IPausable
{
    public bool IsPaused { get; set; }

    private void Update()
    {
        if (Input.GetMouseButton(0))
            GameManager.Instance.Resume();
    }

    public void OnPause()
    {
    }

    public void OnResume()
    {
        gameObject.SetActive(false);
    }
}