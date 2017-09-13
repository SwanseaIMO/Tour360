using UnityEngine;
using VRStandardAssets.Utils;

namespace VRStandardAssets.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    [ExecuteInEditMode]
    public class TelportVrScript : MonoBehaviour
    {
        [SerializeField] private Transform dolly;
        [SerializeField] private Transform destination;
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        [SerializeField] private Renderer m_Renderer;
        [SerializeField] private bool AutoAlign = false;
		public float DistanceMultiplyer = 5.0f;

        private void Awake ()
        {
            m_Renderer.material = m_NormalMaterial;
            if (destination != null)
            {
                ///Debug.Log(destination.position);

                if (AutoAlign == true)
                {
                    ///Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
                    Vector3 vector_sphere = destination.position - transform.parent.parent.position;
					this.transform.position = (transform.parent.parent.position + vector_sphere.normalized * DistanceMultiplyer);
                }
            }
        }

        private void update()
        {
            m_Renderer.material = m_NormalMaterial;
            if (destination != null)
            {
                if (AutoAlign == true)
                {
                    ///Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
                    Vector3 vector_sphere = destination.position - transform.parent.parent.position;
                    this.transform.position = (transform.parent.parent.position + vector_sphere.normalized * 5.0f);
                }
            }
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
            //Debug.Log("Show over state");
            m_Renderer.material = m_OverMaterial;
        }


        //Handle the Out event
        private void HandleOut()
        {
           // Debug.Log("Show out state");
            m_Renderer.material = m_NormalMaterial;
        }


        //Handle the Click event
        private void HandleClick()
        {
           // Debug.Log("Show click state");
            m_Renderer.material = m_ClickedMaterial;
            /// move camera to new position ; 
            if (destination != null)
            {
               // Debug.Log(destination.position);
                dolly.transform.position = destination.position;
               // Debug.Log("postion click");
            }
            ///
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
            //Debug.Log("Show double click");
            m_Renderer.material = m_DoubleClickedMaterial;
            if (destination != null)
            {
                /// move camera to new position ; 
               // Debug.Log(destination.position);
                dolly.transform.position = destination.position;
               // Debug.Log("postion click");
            }
        }

        // draw lines between links
        void OnDrawGizmos()
        {
            if (destination != null)
            {
                Gizmos.color = Color.red;
                //Vector3 direction = transform.TransformDirection(Vector3.forward) * 5;
                Vector3 direction = destination.position - transform.parent.parent.position;
                Vector3 directionHalf = direction.normalized * (direction.magnitude * 0.5f);
                ///Debug.Log(" Grand parent: " + transform.parent.parent.name);
                Gizmos.DrawRay(transform.parent.parent.position, directionHalf);
            }
        }

    }

}