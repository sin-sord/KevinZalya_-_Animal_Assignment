using NodeCanvas.Framework;
using ParadoxNotion.Design;
using TMPro;
using UnityEngine;
using UnityEngine.AI;


namespace NodeCanvas.Tasks.Actions {

	public class RoamAT : ActionTask {
       
        //  BLACKBOARD
        public BBParameter<float> hungerFloat;
        public BBParameter<float> thirstFloat;
        public BBParameter<Vector3> targetPosition;
        public float hungerUsage;
        public float thirstUsage;

        //  WANDER
        private NavMeshAgent navAgent;
        public float roamRadius;
        Vector3 finalDestination;


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

            Vector3 roamTarget = Random.insideUnitSphere * roamRadius;
            
            roamTarget += agent.transform.position;

            NavMeshHit hit;

            NavMesh.SamplePosition(roamTarget, out hit, roamRadius, 1);
            finalDestination = hit.position;

            navAgent.SetDestination(hit.position);

        }

		//Called once per frame while the action is active.
		protected override void OnUpdate() {

            hungerFloat.value -= hungerUsage * Time.deltaTime;
            thirstFloat.value -= thirstUsage * Time.deltaTime;


            if (Vector3.Distance(agent.transform.position, finalDestination) < 1f)
            {
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