using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Anim
{
    public AnimationClip idle;
    public AnimationClip runForward;
    public AnimationClip runBackward;
    public AnimationClip runRight;
    public AnimationClip runLeft;
}

public class PlayerCtrl : MonoBehaviour {
    private float h = 0.0f;
    private float v = 0.0f;

    private Transform tr;
    public float moveSpeed = 10.0f;

    private float rotSpeed = 100.0f;

    public Anim anim;
    public Animation _animation;

	// Use this for initialization
	void Start () {
        tr = gameObject.GetComponent<Transform>();
        _animation = GetComponentInChildren<Animation>();
        _animation.clip = anim.idle;
        _animation.Play("idle");
    }
	
	// Update is called once per frame
	void Update() { 
        h = Input.GetAxis("Horizontal");
        v = Input.GetAxis("Vertical");

        Debug.Log("H = " + h);
        Debug.Log("V = " + v);

        Vector3 moveDir = (Vector3.forward * v) + (Vector3.right * h);

        tr.Rotate(Vector3.up * Time.deltaTime * rotSpeed * Input.GetAxis("Mouse X"));
        tr.Translate(moveDir.normalized * moveSpeed * Time.deltaTime);

        if (v >= 0.1f)
        {
            _animation.CrossFade(anim.runForward.name, 0.1f);
            Debug.Log("FUCK");

        }
        else if (v <= -0.1f)
        {
            _animation.CrossFade(anim.runBackward.name, 0.1f);
        }
        else if (h >= 0.1f)
        {
            _animation.CrossFade(anim.runRight.name, 0.1f);
        }
        else if (h <= -0.1f)
        {
            _animation.CrossFade(anim.runLeft.name, 0.1f);
        }
        else
        {
            _animation.CrossFade(anim.idle.name, 0.1f);
        }
    }

}
