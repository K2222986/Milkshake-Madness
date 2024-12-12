using UnityEngine;

public class SceneChangeDetection : MonoBehaviour
{
    Music VolumeManager;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        VolumeManager.AttachSoundBar();
    }

    private void Awake()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
