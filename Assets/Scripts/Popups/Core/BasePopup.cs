using System;
using Interfaces.Popups;
using UniRx;
using UnityEngine;
using UnityEngine.UI;
using Utils;

namespace Popups.Core {
	public class BasePopup : MonoBehaviour, IPopup {
		[SerializeField] protected RectTransform _content;
		[SerializeField] protected Animator _animator;
		[SerializeField] protected AnimationClip _showAnimation;
		[SerializeField] protected AnimationClip _hideAnimation;
		[SerializeField] protected bool _hasDimmer;
		[SerializeField] protected bool _hasCloseButton = true;
		[SerializeField] protected bool _destroyAfterHide = true;
		[SerializeField] protected bool _scaleAnimation = true;

		[ConditionalHide("_hasCloseButton")] [SerializeField]
		protected Button _closeButton;

		private static readonly int ShowTrigger = Animator.StringToHash("show");
		private static readonly int HideTrigger = Animator.StringToHash("hide");

		public ReactiveCommand OnHide { get; } = new ReactiveCommand();
		public ReactiveCommand AfterHide { get; } = new ReactiveCommand();
		public bool HasDimmer => _hasDimmer;

		public virtual void Show(Action onComplete = null) {
			gameObject.SetActive(true);
			_animator.enabled = true;
			onComplete += () => _animator.enabled = false; 
			_animator.SetTrigger(ShowTrigger);
			Observable.Timer(TimeSpan.FromSeconds(_showAnimation.length)).Subscribe(_ => { onComplete?.Invoke(); });
		}

		public virtual void Hide(Action onComplete = null) {
			OnHide.Execute();
			onComplete += () => {
				AfterHide.Execute();
				if (_destroyAfterHide) {
					Destroy(gameObject, Time.deltaTime);
				}
				else {
					gameObject.SetActive(false);
				}
			};
			_animator.enabled = true;
			onComplete += () => _animator.enabled = false;
			_animator.SetTrigger(HideTrigger);
			Observable.Timer(TimeSpan.FromSeconds(_hideAnimation.length)).Subscribe(_ => { onComplete?.Invoke(); });
		}

		public void KeepAliveAfterHide() {
			_destroyAfterHide = false;
		}

		public void BringToTopOrder() {
			transform.SetAsLastSibling();
		}

		public void SetCloseButtonActive(bool active) {
			_closeButton.gameObject.SetActive(active);
		}

		private void Start() {
			if (_closeButton) {
				_closeButton.onClick.AddListener(() => Hide());
			}

			if (_scaleAnimation) {
				_content.localScale = Vector3.zero;
			}
		}
	}
}