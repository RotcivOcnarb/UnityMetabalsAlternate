using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterDroper : MonoBehaviour
{
    public Camera mainCamera;
    public GameObject metaballPrefab;
    // Start is called before the first frame update
    float timer = 0;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        timer += Time.deltaTime;
        if(Input.GetMouseButton(0)){
            for(int i = 0; i < 3; i ++){
                Vector3 mouseWorldPos = mainCamera.ScreenToWorldPoint(Input.mousePosition);
                mouseWorldPos.z = Random.Range(0.03f, 0.06f);

                mouseWorldPos += new Vector3(Random.Range(-0.2f, 0.2f), 0, 0);

                Vector3 position = transform.position;
                position.z = mouseWorldPos.z;

                GameObject g = Instantiate(metaballPrefab, position, metaballPrefab.transform.rotation);
                g.GetComponent<SpriteRenderer>().color = Color.HSVToRGB((Mathf.Sin(timer)+1)/2, 1, 1);


                g.GetComponent<Rigidbody2D>().velocity = (mouseWorldPos - position).normalized * 10f;
            }
        }

    }
}
