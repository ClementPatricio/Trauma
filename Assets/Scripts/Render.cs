using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class Render : MonoBehaviour
{
    public float intensity;
    private Material mat;
    int it = 0;
    // Start is called before the first frame update
    void Awake()
    {
        mat = new Material(Shader.Find("Shaders/ShaderGrey"));
        //Debug.Log("Resolution "+Screen.currentResolution);
        mat.SetFloat("height", Screen.currentResolution.height);
        mat.SetFloat("width", Screen.currentResolution.width);
    }

    private void OnRenderImage(RenderTexture source, RenderTexture destination)
    {
        /*if(intensity == 0)
        {
            Graphics.Blit(source, destination);
            return;
        }
        mat.SetFloat("_bwBlend", intensity);*/
        //Debug.Log("On Render Image");

        //mat.SetFloat("time", Mathf.Sin(Time.realtimeSinceStartup));
        mat.SetFloat("time", Mathf.Sin(Time.realtimeSinceStartup));
        Graphics.Blit(source, destination, mat);
    }

    public void Update()
    {
        //mat.SetFloat("time", Mathf.Sin(Time.realtimeSinceStartup*40.0f));
    }
}
