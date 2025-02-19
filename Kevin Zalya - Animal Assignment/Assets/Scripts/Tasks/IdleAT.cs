using NodeCanvas.Framework;
using ParadoxNotion.Design;
using System.Timers;
using UnityEngine;
using UnityEngine.Rendering.VirtualTexturing;


namespace NodeCanvas.Tasks.Actions {

	public class IdleAT : ActionTask {

		//	ANIMATION
		private Animator animator;
		
		//  BLACKBOARD
		public BBParameter<float> hungerFloat;
		public BBParameter<float> thirstFloat;
//		public BBParameter<Vector3> targetPosition;
		public float hungerUsage;
		public float thirstUsage;

/*
		//  WANDER
		public float wanderDistance;
		public float wanderRadius;
		public float wanderSampleFrequency;
		public float wanderDirectionChangeFrequiency;

		private Vector3 randomPoint = Vector3.zero;
		private float timeSinceLastDirectionChange;
		private float timeSinceLastSample = 0;*/




        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit() {

            return null;
		}

		//This is called once each time the task is enabled.
		//Call EndAction() to mark the action as finished, either in success or failure.
		//EndAction can be called from anywhere.
		protected override void OnExecute() {


        }

        //Called once per frame while the action is active.
        protected override void OnUpdate() {
		
            hungerFloat.value  -= hungerUsage * Time.deltaTime;
            thirstFloat.value  -= thirstUsage * Time.deltaTime;
/*
			Vector3 circleCenter = agent.transform.position + agent.transform.forward * wanderDistance;

			timeSinceLastSample += Time.deltaTime;
			timeSinceLastDirectionChange += Time.deltaTime;

			if(timeSinceLastSample > wanderSampleFrequency) // update the position the character is moving in using randomPoint below
			{
				
				Vector3 destination = circleCenter + new Vector3(randomPoint.x, agent.transform.position.y, randomPoint.y);
				targetPosition.value = destination;
				timeSinceLastSample = 0;
				Debug.DrawLine(agent.transform.position, circleCenter, Color.red, 0.25f);
				DrawCircle(circleCenter, wanderRadius, Color.cyan, 10);
			}

			if(timeSinceLastDirectionChange > wanderDirectionChangeFrequiency)  //  updates the direction the character is moving in
            {
				
				randomPoint = Random.insideUnitCircle.normalized * wanderRadius;  //  changes the points to be random
				timeSinceLastDirectionChange = 0;  //  resets the timeSinceLastDirectionChange
			}*/
        }

		//Called when the task is disabled.
		protected override void OnStop() {
			
		}

		//Called when the task is paused.
		protected override void OnPause() {
			
		}
/*
		private void DrawCircle(Vector3 circleCenter, float radius, Color circleColor, int numberOfPoints)
		{
			// creates a circle on the ground for the characte to use to wander around
			int increment = 360 / numberOfPoints;
			for(int i = 0; i < 360; i+= increment)
			{
				//  increments the points of the circle
				Vector3 p1 = new Vector3(Mathf.Cos(i * Mathf.Deg2Rad), 0f, Mathf.Sin(i * Mathf.Deg2Rad)) * radius;
				Vector3 p2 = new Vector3(Mathf.Cos((i+increment) * Mathf.Deg2Rad), 0f, Mathf.Sin((i+increment) * Mathf.Deg2Rad)) * radius;

				//  draws a line of the circle
				Debug.DrawLine(circleCenter + p1, circleCenter + p2, circleColor, 0.25f);

			}
		}
*/

	}
}