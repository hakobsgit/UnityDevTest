using System;
using UniRx;

namespace Interfaces.Popups {
	public interface IPopup {
		ReactiveCommand OnHide { get; }
		ReactiveCommand OnShow { get; }
		ReactiveCommand AfterHide { get; }
		ReactiveCommand AfterShow { get; }
		bool HasDimmer { get; }
		void Show(Action onComplete = null);
		void Hide(Action onComplete = null);
	}
}