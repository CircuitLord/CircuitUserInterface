using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

namespace CUI.Actions {
	public abstract class CUIAction : MonoBehaviour {
		
		
		[SerializeField] private bool startTriggered = false;

		[SerializeField] protected Ease easing = Ease.InOutCubic;
		
		
		public bool isTriggered { get; protected set; } = false;

		
		private List<Tweener> tweens = new List<Tweener>();


		protected virtual void Start() {
			if (startTriggered) {
				isTriggered = false;
				Trigger(true);
			}
			else {
				isTriggered = true;
				Untrigger(true);
			}
		}


		public virtual bool Trigger(bool instant = false) {
			if (isTriggered) return false;
			
			isTriggered = true;
			
			KillTweens();
			//Debug.Log("killed tweens");

			return true;
		}

		public virtual bool Untrigger(bool instant = false) {

			if (!isTriggered) return false;
			
			isTriggered = false;
			
			KillTweens();

			return true;
		}


		protected void AddActiveTween(Tweener tween) {
			//if (tweens.Contains(tween)) return;
			
			tweens.Add(tween);

			tween.onComplete += () => {
				RemoveActiveTween(tween);
			};


		}

		private void RemoveActiveTween(Tweener tween) {
			if (!tweens.Contains(tween)) return;
			tweens.Remove(tween);
		}

		public void KillTweens() {
			foreach (Tweener tween in tweens) {
				tween?.Kill();
			}
			
			tweens.Clear();
			
		}
		

	}
}