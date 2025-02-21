using NodeCanvas.Framework;
using ParadoxNotion.Design;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class GoToTargetAT : ActionTask {


        private NavMeshAgent navAgent;

        public BBParameter<Transform> targetTransform;
        Vector3 lastPosition;
        public float sampleDistance;
        Vector3 targetOffSet;

        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            navAgent = agent.GetComponent<NavMeshAgent>();
            return null;
        }

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {



            navAgent.destination = targetTransform.value.position;

            NavMeshHit hit;  //  Gary gets a hit on the targets position
            NavMesh.SamplePosition(targetTransform.value.position, out hit, sampleDistance, NavMesh.AllAreas);
            lastPosition = hit.position;

            navAgent.destination = lastPosition;  //  the destination for Gary is the targets position

        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {

            Debug.Log("going to target");
            
           
            //  if the distance between Gary and the targets position is less than 3, end the action
            if (Vector3.Distance(agent.transform.position, targetTransform.value.position) <= 3)
            {
                Debug.Log("here");

                EndAction(true);
            }

        }

        //Called when the task is disabled.
        protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}

	}
}