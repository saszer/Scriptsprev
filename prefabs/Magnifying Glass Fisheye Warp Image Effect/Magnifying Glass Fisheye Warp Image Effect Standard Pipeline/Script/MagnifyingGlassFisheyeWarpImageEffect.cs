using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagnifyingGlassFisheyeWarpImageEffect : MonoBehaviour
{
    public enum  WarpType
    {
        POW, 
        EXP2
    }

    public bool detectMouseButtonDown = false;

    [Range(0.025f, 1f)]
    public float radius = 0.15f;

    [Range(-3, 3)]
    public float distortion = 0.5f;

    [Range(0.025f, 2f)]
    public float scaleArea = 1;

    public WarpType warpType = WarpType.POW;

    public bool isMagnifyingGlass = false;

    private Shader shader = null;

    private Material mtrl = null;

    private void Awake()
    {
        shader = Shader.Find("Hidden/MagnifyingGlassFisheyeWarpImageEffect");
        if (!shader.isSupported)
        {
            enabled = false;
            return;
        }

        mtrl = new Material(shader);
    }

    private void OnRenderImage(RenderTexture src, RenderTexture dest)
    {
        if (mtrl == null || mtrl.shader == null || !mtrl.shader.isSupported)
        {
            enabled = false;
            return;
        }

        if(Input.GetMouseButton(0) || !detectMouseButtonDown)
        {
            mtrl.SetFloat("_Radius", radius);
            mtrl.SetVector("_Mouse", Input.mousePosition);
            mtrl.SetFloat("_Distortion", distortion);
            mtrl.SetFloat("_ScaleArea", scaleArea);
            if(isMagnifyingGlass)
            {
                mtrl.EnableKeyword("IS_MAGNIFYING_GLASS");
            }
            else
            {
                mtrl.DisableKeyword("IS_MAGNIFYING_GLASS");
            }
            if(warpType == WarpType.POW)
            {
                mtrl.EnableKeyword("WARP_TYPE_POW");
                mtrl.DisableKeyword("WARP_TYPE_EXP2");
            }
            else
            {
                mtrl.DisableKeyword("WARP_TYPE_POW");
                mtrl.EnableKeyword("WARP_TYPE_EXP2");
            }
            Graphics.Blit(src, dest, mtrl, 0);
        }
        else
        {
            Graphics.Blit(src, dest);
        }
    }

    private void OnDestroy()
    {
        shader = null;

        if (mtrl != null)
        {
            DestroyImmediate(mtrl);
            mtrl = null;
        }
    }
}
