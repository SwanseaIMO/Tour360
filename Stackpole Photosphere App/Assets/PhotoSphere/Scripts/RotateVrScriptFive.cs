using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class RotateVrScriptFive : MonoBehaviour
    {
		[SerializeField] private Transform Compass;
		[SerializeField] private Transform dolly;
        [SerializeField] private float rotate;
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer_1;
        [SerializeField] private Renderer m_Renderer_2;


        private void Awake ()
        {
            m_Renderer_1.material = m_NormalMaterial;
            m_Renderer_2.material = m_NormalMaterial;
            Debug.Log(rotate);
        }


        private void OnEnable()
        {
            m_InteractiveItem.OnOver += HandleOver;
            m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
            m_InteractiveItem.OnOver -= HandleOver;
            m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
        private void HandleOver()
        {
            Debug.Log("Show over state");
            m_Renderer_1.material = m_OverMaterial;
            m_Renderer_2.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
            Debug.Log("Show out state");
            m_Renderer_1.material = m_NormalMaterial;
            m_Renderer_2.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
            Debug.Log("Show click state");
            m_Renderer_1.material = m_ClickedMaterial;
            m_Renderer_2.material = m_ClickedMaterial;
            /// move camera to new position ; 
            Debug.Log(rotate);
            dolly.transform.eulerAngles = dolly.transform.eulerAngles + new Vector3(0, rotate, 0);
			Compass.transform.eulerAngles = Compass.transform.eulerAngles + new Vector3(0, -rotate, 0);
            Debug.Log("rotate click");
            ///
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            Debug.Log("Show double click");
            m_Renderer_1.material = m_DoubleClickedMaterial;
            m_Renderer_2.material = m_DoubleClickedMaterial;
            /// move camera to new position ; 
            Debug.Log(rotate);
            dolly.transform.eulerAngles = dolly.transform.eulerAngles + new Vector3(0, rotate, 0);
			Compass.transform.eulerAngles = Compass.transform.eulerAngles + new Vector3(0, -rotate, 0);
            Debug.Log("rotate click");
        }
    }

}