using System;
using UniRx;

namespace Interfaces.Popups {
	public interface IPopup {
		ReactiveCommand OnHide { get; }
		ReactiveCommand AfterHide { get; }
		bool HasDimmer { get; }
		void Show(Action onComplete = null);
		void Hide(Action onComplete = null);
	}
}