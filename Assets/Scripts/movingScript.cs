using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class movingScript : MonoBehaviour
{
    public float kecepatan;
    Rigidbody rb;
    Animator anim;
    public Transform PlayerPutaran;
    
    // Start is called before the first frame update
 
    private void Awake()
    {
        rb = GetComponent<Rigidbody>();
        anim = GetComponent<Animator>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float gerak = Input.GetAxis("Horizontal");
        rb.velocity = Vector3.right * kecepatan * gerak;
        anim.SetFloat("MoveSpeed", Mathf.Abs(gerak), 0.1f, Time.deltaTime);
        PlayerPutaran.localEulerAngles = new Vector3(0, gerak * -90, 0);
    }
}