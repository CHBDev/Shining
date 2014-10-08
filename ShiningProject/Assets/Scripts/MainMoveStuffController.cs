using UnityEngine;
using System.Collections;

public class MainMoveStuffController : MonoBehaviour
{


		public static MainMoveStuffController singleton;
	
	
		void Awake ()
		{
				if (singleton == null) {
						
						singleton = this;
				} else if (singleton != this) {
						gameObject.SetActive (false);
						Destroy (gameObject);
				}
		}

	
		public void doMoveMePositionAndScale (GameObject aThing, Vector2 StartPos, Vector2 EndPos, float time1, Vector2 endScale)
		{
		
				AnimationCurve theXPath = AnimationCurve.Linear (0, StartPos.x, time1, EndPos.x);
				AnimationCurve theYPath = AnimationCurve.Linear (0, StartPos.y, time1, EndPos.y);
		
				AnimationCurve theScaleX = AnimationCurve.Linear (0, aThing.transform.localScale.x, time1, endScale.x);
				AnimationCurve theScaleY = AnimationCurve.Linear (0, aThing.transform.localScale.y, time1, endScale.y);
		
		
		
		
		
				AnimationClip clip = new AnimationClip ();
		
				clip.SetCurve ("", typeof(Transform), "localPosition.x", theXPath);
				clip.SetCurve ("", typeof(Transform), "localPosition.y", theYPath);
				clip.SetCurve ("", typeof(Transform), "localScale.x", theScaleX);
				clip.SetCurve ("", typeof(Transform), "localScale.y", theScaleY);
		
		
		
		
				if (aThing.GetComponent ("Animation") == null) {
						aThing.AddComponent ("Animation");
				}
		
				Animation theAnimation = aThing.GetComponent<Animation> ();
		
		
				theAnimation.AddClip (clip, "clip");
		
		
		
				//theAnimation ["clipX"].blendMode = AnimationBlendMode.Additive;
				//theAnimation ["clipY"].blendMode = AnimationBlendMode.Additive;
				//theAnimation.Play ("clipY");
				//theAnimation.Play ("clipY");
				theAnimation.Play ("clip");
				//TempGO.animation.wrapMode = WrapMode.PingPong;
		
		
		}



		// Use this for initialization
		void Start ()
		{
	
		}
	
		// Update is called once per frame
		void Update ()
		{
	
		}
}
