using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBeatMovement : MonoBehaviour {
    public int life;
    public BPMtimer selectedBeatDetection;
    public KeyCode left, right;
    public GameObject leftsensor, rightsensor;

    private delegate void Movement();
    Movement Moveonbeat;

	// Use this for initialization
	void Start () {
        selectedBeatDetection.OnBPMBeat += OnBeat;
        life = 3;
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(left))
        {
            Moveonbeat = moveLeft;
            if (leftsensor.GetComponent<TriggerSensor>().isInside)
            {
                Moveonbeat += leftAttack;
            }
        }
        else if (Input.GetKeyDown(right))
        {
            Moveonbeat = moveRight;
            if (rightsensor.GetComponent<TriggerSensor>().isInside)
            {
                Moveonbeat += rightAttack;
            }
        }

        if(life <= 0)
        {
            Destroy(this.gameObject);
        }
    }


    void moveRight()
    {
        this.transform.Translate(1, 0, 0);        
    }

    void moveLeft()
    {
        this.transform.Translate(-1, 0, 0);
    }

    void rightAttack()
    {
        Destroy(rightsensor.GetComponent<TriggerSensor>().colidedObject);
    }

    void leftAttack()
    {
        Destroy(leftsensor.GetComponent<TriggerSensor>().colidedObject);
    }

    void OnBeat()
    {
        if(Moveonbeat != null)
            Moveonbeat();
        Moveonbeat = null;
    }
}
