using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SingleMetaball : MonoBehaviour
{
    Rigidbody2D body;
    float timeSinceCreation;
    public GameObject metaballPrefab;
    public GameObject stainPrefab;
    // Start is called before the first frame update
    void Start()
    {
        body = GetComponent<Rigidbody2D>();
        timeSinceCreation = 0;
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceCreation += Time.deltaTime;

        if(timeSinceCreation > 10)
            Destroy(gameObject);
    }

    Vector2 Rotate(Vector2 v, float rad){
        return new Vector2(
            v.x * Mathf.Cos(rad) - v.y * Mathf.Sin(rad),
            v.x * Mathf.Sin(rad) + v.y * Mathf.Cos(rad)
        );
    }

    void OnCollisionEnter2D(Collision2D col){
        if(col.collider.gameObject.tag == "Floor" && timeSinceCreation > 0.1){
            
            if(transform.position.z > 0.02f && Random.Range(0f, 1f) < 0.3f){
                //normal da colisão.
                Vector2 normal = col.GetContact(0).normal;

                Vector2 reflection = col.relativeVelocity - 2*Vector2.Dot(col.relativeVelocity, normal)*normal;
                //reflete a direção de contato
                // cria outra metaball da mesma cor com metade do tamanho

                GameObject cpy = Instantiate(gameObject);
                cpy.transform.position = new Vector3(
                    transform.position.x,
                    transform.position.y,
                    transform.position.z / 4);

                reflection = Rotate(reflection, Random.Range(-0.01f, 0.01f));

                cpy.GetComponent<Rigidbody2D>().velocity = -reflection * 0.1f;
            }

            GameObject stain = Instantiate(stainPrefab, gameObject.transform.position, stainPrefab.transform.rotation);
            stain.GetComponent<SpriteRenderer>().color = GetComponent<SpriteRenderer>().color;
            stain.transform.position = new Vector3(
                stain.transform.position.x,
                stain.transform.position.y,
                stain.transform.position.z * 1.5f
            );

            //cria o stain no local de contato
            Destroy(gameObject);
        }
    }
}
