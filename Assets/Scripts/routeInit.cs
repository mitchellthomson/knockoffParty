﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteAlways]
public class routeInit : MonoBehaviour
{
    [SerializeField]
    public List<Transform> starList = new List<Transform>();

    public void Awake()
    {
        int i = 0;
        starList.Clear();
        while(i<transform.childCount)
        {
            Transform child = transform.GetChild(i);

            if(child.GetComponent<spot>().isArrow==true)
            {
                child.GetComponent<spot>().prevSpot = transform.GetChild(i-1);
                i++;
                child = transform.GetChild(i);
            }

            if(child.GetComponent<spot>().isStar==true)
            {
                starList.Add(child);
            }
            
            if(i==transform.childCount-1)
            {
                child.GetComponent<spot>().nextSpot = transform.GetChild(1);
                child.GetComponent<spot>().prevSpot = transform.GetChild(i-1);
                child = transform.GetChild(1);
                child.GetComponent<spot>().prevSpot = transform.GetChild(i);
            }
            else if(child.GetComponent<spot>().isEndofArrow==true)
            {
                child.GetComponent<spot>().nextSpot = child.GetComponent<spot>().setSpot;
                child.GetComponent<spot>().prevSpot = transform.GetChild(i-1);
            }
            else if(child.GetComponent<spot>().isStartofArrow==true)
            {
                child.GetComponent<spot>().prevSpot = child.GetComponent<spot>().setSpot;
                child.GetComponent<spot>().nextSpot = transform.GetChild(i+1);
            }
            else
            {
                child.GetComponent<spot>().nextSpot = transform.GetChild(i+1);
                if(i!=0)
                {
                    child.GetComponent<spot>().prevSpot = transform.GetChild(i-1);
                }
            }
            i++;
        }

    }

}
