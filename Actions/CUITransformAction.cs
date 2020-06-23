/*using System;
using System.Collections;
using System.Collections.Generic;
using CUI.DOTweenUtil;
using DG.Tweening;
using Sirenix.OdinInspector;
using UnityEngine;


namespace CUI.Actions {
	
	[RequireComponent(typeof(Transform))]
	public class CUITransformAction : CUIAction {
		
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
		

		
		protected override void Reset() {
			base.Reset();

		}

		public override bool ActivateIndex(int index, bool instant = false, bool force = false) {
			if (!base.ActivateIndex(index, instant, force)) return false;

			State state = states[index];

			//Prepare tweens

			if (instant) {
				transform.localScale = state.scale;
				transform.localPosition = state.pos;
				transform.localEulerAngles = state.rot;
			}
			else {
				if (transform.localScale != state.scale) {
					AddActiveTween(transform.DOScale(state.scale, dur).SetEase(easing));
				}

				if (transform.localPosition != state.pos) {
					AddActiveTween(transform.DOLocalMove(state.pos, dur).SetEase(easing));
				}

				if (transform.localEulerAngles != state.rot) {
					AddActiveTween(transform.DOLocalRotate(state.rot, dur).SetEase(easing));
				}
				
				StartEditorTweens();
			}
			
			return true;
		}


		[Serializable]
		public class State : CUIActionState {
			[HideInInspector] public Transform transform;

			public Vector3 pos = Vector3.zero;
			public Vector3 scale = Vector3.one;
			public Vector3 rot = Vector3.zero;

			public override void Set() {
				pos = transform.localPosition;
				scale = transform.localScale;
				rot = transform.localEulerAngles;
			}

			public override void GetReferences(GameObject go) {
				transform = go.transform;
			}
		}
	}
}*/