using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class HuntAT : ActionTask {

        //  AUDIO
        private AudioSource audioSource;
        public AudioClip walkSound;

        private NavMeshAgent navAgent;

		public BBParameter<Transform> goatTransform;
		Vector3 lastPosition;
		public float sampleDistance;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {
			
			navAgent = agent.GetComponent<NavMeshAgent>();
            audioSource = agent.GetComponent<AudioSource>();
            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {

			navAgent.destination = goatTransform.value.position;
          //  audioSource.PlayOneShot(walkSound);

		}

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            Debug.Log("Hunting goat");

            NavMeshHit hitGoat;  //  Carno gets a hit on the goats position
			NavMesh.SamplePosition(goatTransform.value.position, out hitGoat, sampleDistance, NavMesh.AllAreas);
			lastPosition = hitGoat.position;

			navAgent.destination = lastPosition;  //  the destination for Carno is the goats position

            audioSource.loop = true;

			EndAction(true);
			
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
	}
}