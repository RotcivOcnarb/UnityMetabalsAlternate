﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StainDissipator : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 pos = transform.position;
        pos.z -= Time.deltaTime * 0.01f;
        if(pos.z < 0)
            Destroy(gameObject);

        transform.position = pos;
    }
}
