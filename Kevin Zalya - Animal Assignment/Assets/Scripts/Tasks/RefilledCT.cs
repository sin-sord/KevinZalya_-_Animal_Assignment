using NodeCanvas.Framework;
using ParadoxNotion.Design;
using UnityEngine;


namespace NodeCanvas.Tasks.Conditions {

	public class RefilledCT : ConditionTask {


        public BBParameter<float> barValue;

        public float hungerThreshold;
        //Use for initialization. This is called only once in the lifetime of the task.
        //Return null if init was successfull. Return an error string otherwise
        protected override string OnInit(){
			return null;
		}

		//Called whenever the condition gets enabled.
		protected override void OnEnable() {
			
		}

		//Called whenever the condition gets disabled.
		protected override void OnDisable() {
			
		}

		//Called once per frame while the condition is active.
		//Return whether the condition is success or failure.
		protected override bool OnCheck() {
			Debug.Log("Bar refilled");

			//  if the hunger/thirst bar reaches the max value then go to the next action
            float value = barValue.value;
            bool hungerFull = value >= hungerThreshold;

            return hungerFull;
        }
	}
}