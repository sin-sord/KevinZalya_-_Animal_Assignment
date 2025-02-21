using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Actions {

	public class DrinkAT : ActionTask {

        //	BLACKBOARD
        public BBParameter<float> BarValue;
        public BBParameter<Transform> targetTransform;
        public float maxThresholdBar;
        public float refillRate;

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

            Debug.Log("Refilling bar");

            //  if Gary is at the target position, refill the thirst bar  
            BarValue.value += refillRate * Time.deltaTime;

            if (BarValue.value >= maxThresholdBar)
            {
                BarValue.value = maxThresholdBar;
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