using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class mousehover : MonoBehaviour
{

    public Vector3 originalScale;
    public Vector3 currentScale;
    bool expandAnimation;
    bool shrinkAnimation;
    void Start()
    {
        expandAnimation = false;
        shrinkAnimation = false;
        originalScale = gameObject.transform.localScale;       
    }
    void OnMouseOver()
    {
        //Debug.Log("expandAnimation: " + expandAnimation);
        //if animation is not done yet then start the animation, if not dont start it
        if (expandAnimation == false)
        {         
            StartCoroutine(ScaleUpOverTime(0.5f));
        }        
        //If your mouse hovers over the GameObject with the script attached, output this message
        //Debug.Log("Mouse is over GameObject.");
    }

    void OnMouseExit()
    {
        //Debug.Log("shrinkanimation: " + shrinkAnimation);
        if (shrinkAnimation == true)
        {
            StartCoroutine(ScaleDownOverTime(0.5f));
        }     
        //The mouse is no longer hovering over the GameObject so output this message each frame
        //Debug.Log("Mouse is no longer on GameObject.");
    }
 
    void Update()
    {
       // transform.localScale = Vector3.Lerp(transform.localScale, targetScale, speed * Time.deltaTime);
    }

    IEnumerator ScaleDownOverTime(float time)
    {         
        Vector3 destinationScale = new Vector3(0.02882062f, 0.02882062f, 0.02882062f);
        Vector3 expandedScale = new Vector3(0.03772331f, 0.03772331f, 0.03772331f);
        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(expandedScale, destinationScale, currentTime / time);
            currentScale = gameObject.transform.localScale;
            currentTime += Time.deltaTime;
            if (currentTime >= time)
            {   
                //reset the shrink animation
                shrinkAnimation = false;
                //now reset done animation
                expandAnimation = false;
            }
            yield return null;
        } while (currentTime <= time);
    }


    IEnumerator ScaleUpOverTime(float time)
    {       
        Vector3 destinationScale = new Vector3(0.03772331f, 0.03772331f, 0.03772331f);

        float currentTime = 0.0f;

        do
        {
            gameObject.transform.localScale = Vector3.Lerp(originalScale, destinationScale, currentTime / time);
            currentScale = gameObject.transform.localScale;
            currentTime += Time.deltaTime;            
            if (currentTime >= time)
            {
                //Debug.Log("current time" + currentTime + " time" + time);
                expandAnimation = true;
                //now that this animation is done, i allow shrink animation
                shrinkAnimation = true;
            }
            yield return null;
        } while (currentTime <= time);      
    }
}

