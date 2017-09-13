using UnityEngine;
using VRStandardAssets.Utils;

namespace InfoBoard.Examples
{
    // This script is a simple example of how an interactive item can
    // be used to change things on gameobjects by handling events.
    public class InfoBoard : MonoBehaviour
    {
		/*[SerializeField] private Transform Compass;
		[SerializeField] private Transform dolly;
        [SerializeField] private float rotate;
        [SerializeField] private Material m_NormalMaterial;                
        [SerializeField] private Material m_OverMaterial;                  
        [SerializeField] private Material m_ClickedMaterial;               
        [SerializeField] private Material m_DoubleClickedMaterial;*/         
        [SerializeField] private VRInteractiveItem m_InteractiveItem;
        //[SerializeField] private Renderer m_Renderer_1;
        //[SerializeField] private Renderer m_Renderer_2;
		public AudioSource voiceOver;
		private bool clicked;
		private Vector3 lastRotation;
		private Vector3 lastScale;
		private Vector3 parentLastRotation;





      /*  private void Awake ()
        {
            m_Renderer_1.material = m_NormalMaterial;
            m_Renderer_2.material = m_NormalMaterial;
            Debug.Log(rotate);
        }*/


        private void OnEnable()
        {
           // m_InteractiveItem.OnOver += HandleOver;
           // m_InteractiveItem.OnOut += HandleOut;
            m_InteractiveItem.OnClick += HandleClick;
            m_InteractiveItem.OnDoubleClick += HandleDoubleClick;
        }


        private void OnDisable()
        {
         //   m_InteractiveItem.OnOver -= HandleOver;
          //  m_InteractiveItem.OnOut -= HandleOut;
            m_InteractiveItem.OnClick -= HandleClick;
            m_InteractiveItem.OnDoubleClick -= HandleDoubleClick;
        }


        //Handle the Over event
     /*   private void HandleOver()
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
        }*/


        //Handle the Click event
        private void HandleClick()
        {
			clicked =!clicked;

			if(clicked)
			{
				//transform.localScale += new Vector3 (0, 0.2f, 0.4f);
				lastRotation =  this.transform.localEulerAngles;
				lastScale = this.transform.localScale;
				transform.localScale = transform.localScale*2.5f;
				transform.localEulerAngles = new Vector3 (0,lastRotation.y, 0);
				parentLastRotation = transform.parent.localEulerAngles;
				Vector3 angles = transform.parent.localEulerAngles; 
				transform.parent.localEulerAngles = new Vector3 (0,angles.y, angles.z);
				voiceOver.Play ();

			}
			else{
				//transform.localScale -= new Vector3 (0, 0.2f, 0.4f);
				//transform.localScale = transform.localScale*0.4f;
				//transform.localEulerAngles = new Vector3 (0, -45f, 16f);
				transform.localScale = lastScale;
				transform.localEulerAngles = lastRotation;
				transform.parent.localEulerAngles = parentLastRotation;
				voiceOver.Stop ();
			}
						
			
        }


        //Handle the DoubleClick event
        private void HandleDoubleClick()
        {
			clicked = !clicked;

			if(clicked)
			{
				//transform.localScale += new Vector3 (0, 0.2f, 0.4f);
				lastRotation =  this.transform.localEulerAngles;
				lastScale = this.transform.localScale;
				transform.localScale = transform.localScale*2.5f;
				transform.localEulerAngles = new Vector3 (0, lastRotation.y, 0);
				parentLastRotation = transform.parent.localEulerAngles;
				Vector3 angles = transform.parent.localEulerAngles; 
				transform.parent.localEulerAngles = new Vector3 (0, angles.y, angles.z);
				voiceOver.Play ();

			}
			else{
				//transform.localScale -= new Vector3 (0, 0.2f, 0.4f);
				//transform.localScale = transform.localScale*0.4f;
				//transform.localEulerAngles = new Vector3 (0, -45f, 16f);
				transform.localScale = lastScale;
				transform.localEulerAngles = lastRotation;
				transform.parent.localEulerAngles = parentLastRotation;
				voiceOver.Stop ();
			}
					
    }
	}
}