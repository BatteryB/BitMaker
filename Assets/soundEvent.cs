using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

public class soundEvent : MonoBehaviour
{
    private AudioClip clip;
    private AudioSource source;
    private Renderer child;
    private Color original;

    async void Start()
    {
        Transform childTransform = transform.GetChild(0);
        child = childTransform.GetComponent<Renderer>();
        original = child.material.color;

        string[] obj = this.gameObject.name.Split('_');
        int count = 400 * int.Parse(obj[1]);
        source = gameObject.AddComponent<AudioSource>();
        clip = Resources.Load<AudioClip>(obj[2]);

        await Task.Delay(count);
        InvokeRepeating(nameof(TimerEvent), 1f, 6.4f);
    }

    void Update()
    {

    }

    void TimerEvent()
    {
        if (this.gameObject.tag == "active")
        {
            source.PlayOneShot(clip);
        }
        child.material.color = new Color32(0, 255, 0, 255);

        Invoke("RestoreOriginalColor", 0.4f);
    }

    void RestoreOriginalColor()
    {
        child.material.color = original;
    }
}
