using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camerawalk : MonoBehaviour {
        public GameObject A;
        Transform AT;
        void Start ()
        {
                
                Camera camera = GetComponent<Camera>();
                Rect rect = camera.rect;
                float scaleheight = ((float)Screen.width / Screen.height) / ((float)16 / 9); // (가로 / 세로)
                float scalewidth = 1f / scaleheight;
                if (scaleheight < 1)
                {
                    rect.height = scaleheight;
                    rect.y = (1f - scaleheight) / 2f;
                }
                else
                {
                    rect.width = scalewidth;
                    rect.x = (1f - scalewidth) / 2f;
                }
                camera.rect = rect;        
                
                AT=A.transform;
        }
        
        void Update () {
                transform.position = Vector2.Lerp(transform.position,AT.position,2f * Time.deltaTime);
                transform.Translate (0, 0, -10); //카메라를 원래 z축으로 이동
        }

        void OnPreCull() => GL.Clear(true, true, Color.black);
}