using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class ArrivedCT : ConditionTask {


        //  AUDIO
        private AudioSource audioSource;
		public AudioClip roarSound;

		//	BLACKBOARD
        public BBParameter<Transform> targetTransform;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){

           // audioSource = agent.GetComponent<AudioSource>();
            return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable()
		{
            audioSource.PlayOneShot(roarSound);
            Debug.Log("Heading to target");
        }


		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {

			if (Vector3.Distance(agent.transform.position, targetTransform.value.position) <= 0.5f)
            {
				Debug.Log("i smell it");
                return true;
            }
			else
			{
				return false;
			}
		}
	}
}