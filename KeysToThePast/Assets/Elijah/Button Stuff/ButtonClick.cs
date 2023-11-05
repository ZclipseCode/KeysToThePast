using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonClick : MonoBehaviour
{

    [SerializeField] Animator ani;
    [SerializeField] GameObject button;

    private void Start()
    {
        ani.enabled = false;
    }

    public void Press()
    {
        ani.enabled = true;
        Invoke("Restart", 0.9f);
    }

    private void Restart() {
        ani.enabled = false;
        button.transform.rotation = new Quaternion(0,0,0,0);
        button.transform.localScale = new Vector3(1.634802f, 1.634802f, 1.634802f);
    }

}
