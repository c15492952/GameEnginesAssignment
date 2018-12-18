﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeCircle : MonoBehaviour {
    public float scale = 10;
    List<GameObject> sphs = new List<GameObject>();
    public float radius = 1;
    public GameObject OrbPrefab;
    //public static GameObject CylinderPar;

    // Use this for initialization
    void Start () {
        CreateCubeCircle();
    }
	
	// Update is called once per frame
	void Update () {
        transform.Rotate(Vector3.down * Time.deltaTime*20);
        for (int i = 0; i < sphs.Count; i++)
        {
            Vector3 ts = sphs[i].transform.localScale;
            ts.y = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            ts.x = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            ts.z = Mathf.Lerp(ts.y, 1 + (MusicAnalyser.bands[i] * scale), Time.deltaTime * 3.0f);
            sphs[i].transform.localScale = ts;
        }
    }

    void CreateCubeCircle()
    {
        float theta = (Mathf.PI * 2.0f) / (float)MusicAnalyser.bands.Length;
        for(int i = 0; i < MusicAnalyser.bands.Length; i++)
        {
            Debug.Log(i);
            Vector3 pos = new Vector3(Mathf.Sin(theta * i) * 30, 0, Mathf.Cos(theta * i) * 30);
            pos = transform.TransformPoint(pos);
            Quaternion quat = Quaternion.AngleAxis(theta * i * Mathf.Rad2Deg, Vector3.up);
            quat = transform.rotation * quat;
            
            //GameObject sph = GameObject.CreatePrimitive(PrimitiveType.Sphere);
            GameObject sph = Instantiate(OrbPrefab);
            sph.SetActive(true);
            //sph.AddComponent<Renderer>;
            sph.transform.SetPositionAndRotation(pos, quat); ;
            sph.transform.parent = this.transform;
            sph.GetComponent<Renderer>().material.color = new Color(i + (float)MusicAnalyser.bands.Length, 1, 1);
            sph.AddComponent<SphereCollider>();
            sphs.Add(sph);
        }
    }
}
