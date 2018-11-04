using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//Switches between selected colors based on BPM limited beat information
public class ColorBeatAlternation : MonoBehaviour {

    public BPMtimer selectedBeatDetection;
    private SpriteRenderer mySpriteRenderer;

    //Colors used on beats 
    public Color[] beatcolors;
    private Color currentcolor;

    //Higher value lerps between the current beat color and fade color faster
    public float smoothnessChange;   

    [SerializeField]
    private int alternanceindex;

    void Start()
    {
        selectedBeatDetection.OnBPMBeat += OnBeat;
        mySpriteRenderer = GetComponent<SpriteRenderer>();
        currentcolor = beatcolors[beatcolors.Length - 1];
        alternanceindex = 0;        
    }

    void Update()
    {        
        mySpriteRenderer.material.color = currentcolor;
    }

    void OnBeat()
    {
        currentcolor = beatcolors[alternanceindex % beatcolors.Length];
        alternanceindex++;
    }

    
}
