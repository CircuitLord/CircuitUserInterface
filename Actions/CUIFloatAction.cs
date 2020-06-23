/*using System;
using System.Collections.Generic;
using CUI.DOTweenUtil;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;
using UnityEngine.Events;


namespace CUI.Actions {

	[Serializable]
	public class CUIFloatEvent : UnityEvent<float> {
	};
	
	public class CUIFloatAction : CUIAction {


		public CUIFloatEvent trigger;
		
		[OnValueChanged("OnStatesChanged")]
		[TableList]
		public List<State> states = new List<State>();
		
		

		public void OnStatesChanged() {
			basicStates.Clear();
			
			foreach (State state in states) {
				basicStates.Add(state);
			}

			SetupStates();
		}
		
		
		//[HideInInspector]
		//public RectTransform rectTransform;

		private float val = 0f;
		

		protected override void Reset() {
			base.Reset();

		}

		public override bool ActivateIndex(int index, bool instant = false, bool force = false) {
			if (!base.ActivateIndex(index, instant, force)) return false;
			
			State state = states[index];
			
			//Prepare tweensC

			if (instant) {
				trigger?.Invoke(state.value);
			}
			else {
				AddActiveTween(DOTween.To((f => {
					trigger?.Invoke(f);
				}), val, state.value, dur));
				
				StartEditorTweens();
			}
			
			val = state.value;
			
			return true;
		}


		[Serializable]
		public class State : CUIActionState {

			public float value;


			/*public override void Set() {

			}

			public override void GetReferences(GameObject go) {

			}#1#
		}
	}
}*/

using System;
using System.Collections.Generic;
using CUI.DOTweenUtil;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEditor.Graphs;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;


namespace CUI.Actions {
	
	
	[Serializable]
	public class CUIFloatEvent : UnityEvent<float> {
	};
	
	//[RequireComponent(typeof(Graphic))]
	public class CUIFloatAction : CUIAction {


		//Any properties with private and SerializeField
		[SerializeField] private float activatedValue = 1f;
		[SerializeField] private float deactivatedValue = 1f;
		
		
		private float val = 0f;

		// --- Any components you need references to, with [HideInInspector] ---
		public CUIFloatEvent trigger;

		public override bool Activate(bool instant = false, bool force = false) {
			if (!base.Activate(instant, force)) return false;
			
			//Apply the state instantly
			if (instant) {
				trigger?.Invoke(activatedValue);
			}
			
			//Create tweens and use AddActiveTween()
			else {
				
				AddActiveTween(DOTween.To((f => {
					trigger?.Invoke(f);
				}), val, activatedValue, dur));

				StartEditorTweens();
			}

			val = activatedValue;
			
			return true;
		}

		public override bool Deactivate(bool instant = false, bool force = false) {
			if (!base.Deactivate(instant, force)) return false;
			
			//Apply the state instantly
			if (instant) {
				trigger?.Invoke(deactivatedValue);
			}
			
			//Create tweens and use AddActiveTween()
			else {
				
				AddActiveTween(DOTween.To((f => {
					trigger?.Invoke(f);
				}), val, deactivatedValue, dur));

				StartEditorTweens();
			}

			val = deactivatedValue;
			return true;
		}


	}
}