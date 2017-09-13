using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class PhotoSphereCreation : MonoBehaviour{

    public Texture Photo;
    //private Texture Photo_old; // might use for  on change
    public Renderer rend;
    

    // Use this for initialization
    /// void Start(){ using update despite being expensive
    public void Start(){
        if (Photo != null){
            rend = GetComponent<Renderer>();
            rend.enabled = true;
            rend.sharedMaterial = MakePhotoTexture(Photo);
            //string path = AssetDatabase.GetAssetPath(Photo);
            //path = path.Substring(0, path.LastIndexOf(".")) + ".mat";
            //AssetDatabase.CreateAsset(MakePhotoTexture(Photo), path);
        }
    }

    //set photo as material texture 
    public static Material MakePhotoTexture(Texture PhotoTexture)
    {
        Shader shader = Shader.Find("Unlit/Monosphere");
        Material mat = new Material(shader);
        mat.SetTexture("_MainTex", PhotoTexture);
        return mat;
    }
}
