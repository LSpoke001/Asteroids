using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveBack : MonoBehaviour
{
    public GameObject backGround;
    public float speed = 2f;
    
    private MeshRenderer mesh;
    private Vector2 offset;
    private float newPos;

    private void Start()
    {
        mesh = backGround.GetComponent<MeshRenderer>();
        offset = mesh.material.GetTextureOffset("_MainTex");
    }

    private void Update()
    {
        newPos += speed * Time.deltaTime;
        newPos = Mathf.Clamp01(newPos);
        if (speed > 0 && newPos == 1)
        {
            newPos = 0;
        }
        Vector2 newOffset = new Vector2(offset.x,newPos);
        mesh.material.SetTextureOffset("_MainTex", newOffset);
    }
}
