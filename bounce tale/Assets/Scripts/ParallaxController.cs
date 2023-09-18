using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxController : MonoBehaviour
{
    private float Length, startPos;
    public GameObject cam;
    public float ParallaxEffect;
    void Start()
    {
        startPos=transform.position.x;
        Length = GetComponent<SpriteRenderer>().bounds.size.x;
    }

    void Update()
    {
        //float temp=(cam.transform.position.x*(3-ParallaxEffect));
        float distance = (  cam.transform.position.x*ParallaxEffect);

        transform.position = new Vector3(startPos+distance,transform.position.y,transform.position.z);

      /*  if(temp>startPos+Length)
            startPos+=Length;

        else if(temp>startPos-Length)
            startPos-=Length;*/

    }
    /*Transform cam;//mainCamera
    float distance;//distance between the camera and its current position
    Vector3 camStartPos;

    GameObject[] background;
    Material[]mat ;
    float []backSpeed;

    float fathestBack;

    [Range(0.1f, 0.5f)]
    public float Parallaxspeed=0.2f; 

     void Start()
    {
        cam=Camera.main.transform;
        camStartPos=cam.position;

        int backCount=transform.childCount;
        mat=new Material [backCount];
        backSpeed = new float [backCount];
        background=new GameObject[backCount];

        for(int i=0; i<backCount; i++)
        {
            background[i]=transform.GetChild(i).gameObject;
            mat[i]=background[i].GetComponent<Renderer>().material;

        }
        backSpeedCalculate(backCount);
    }

    void backSpeedCalculate(int backCount)
    {
        for(int i=0; i<backCount; i++)//find the farhtheast background
        {
            if((background[i].transform.position.z-cam.position.z)>fathestBack)
            {
                fathestBack=background[i].transform.position.z-cam.position.z;
            }
        }
        for(int i=0; i<backCount; i++)//set the speed of background
        {
            backSpeed[i]=1-(background[i].transform.position.z-cam.position.z)/fathestBack;
        }
    }

    private void LateUpdate()
    {
        distance=cam.position.x-cam.position.x;
        transform.position=new Vector3(cam.position.x,transform.position.y,0);

        for (int i = 0; i < background.Length; i++)
        {
            float speed = backSpeed[i]*Parallaxspeed;
            mat[i].SetTextureOffset("_MainTex", new Vector2(distance,0)*speed);
        }
    }*/
}
