using System;
using Data.Enums;
using Interfaces.Game;
using Interfaces.Managers;
using Popups;
using UniRx;
using UnityEngine;
using Zenject;

namespace Controllers {
	public class GameController : IInitializable {
		[Inject] private IGameView _gameView;
		[Inject] private IPopupManager _popupManager;
		
		private DynamicContentPopup _dynamicContentPopup;
		
		public void Initialize() {
			_gameView.Init(ShowStartPopup);
		}

		private void ShowStartPopup() {
			_popupManager.ShowPopup<MessagePopup>(popup => {
				popup.Init("Hello there! You are about to see popups test project in action. Please don't be harsh on design :)", "Ok",
					() => {
						popup.Hide();
						ShowDialogPopup();
					}, false);
			});
		}

		private void ShowDialogPopup() {
			_popupManager.ShowPopup<DialogPopup>(popup => {
				popup.Init("Wanna see the best bridge card game made by me ?", "No", "Yes", () => {
					popup.Hide();
					ShowWhyNot();
				}, () => {
					popup.Hide();
					ShowDynamicContentPopup();
				});
			});
		}

		private void ShowWhyNot() {
			_popupManager.ShowPopup<MessagePopup>(popup => {
				popup.Init("Why not? Anyway you are going to see it :) it's about dynamic content downloaded from url",
					"Ok",
					() => {
						popup.Hide();
						ShowDynamicContentPopup();
					}, false);
			});
		}

		private void ShowDynamicContentPopup() {
			string panelUrl = "http://hakob.me/wp-content/uploads/2020/04/icon-5-1024x600.png";
			string buttonUrl = "http://www.clker.com/cliparts/c/y/9/A/H/s/red-rectangle-open-button-th.png";
			_popupManager.ShowPopup<DynamicContentPopup>(popup => {
				_dynamicContentPopup = popup;
				popup.Init(panelUrl, buttonUrl, () => {
					Application.OpenURL("https://trickybridge.com");
				});
				IDisposable disposable = null;
				disposable = popup.AfterHide.Subscribe(_ => {
					ShowPreAddressableMessagePopup();
					disposable?.Dispose();
				});
			});
		}

		private void ShowPreAddressableMessagePopup() {
			_popupManager.ShowPopup<MessagePopup>(popup => {
				popup.Init("Now I am about to show you popup from addressables(Asset bundles) which can be downloadable from remote path. So this also can be dynamic.", "Show",
					() => {
						popup.Hide();
					});
				popup.AfterHide.Subscribe(_ => {
					ShowAddressablePopup();
				});
			});
		}

		private void ShowAddressablePopup() {
			_popupManager.ShowPopup<AddressablePopup>(popup => {
				popup.Init("Great!", () => {
					popup.SetCloseButtonActive(true);
					OpenPopupOnTop();
				}, false);
			});
		}

		private void OpenPopupOnTop() {
			_popupManager.ShowPopup<DialogPopup>(popup => {
				popup.Init("Now you see two popup on each other :) you can either close both from here or close after",
					"Close only this", "Close both",
					() => {
						popup.Hide();
					}, () => {
						_popupManager.HidePopup<AddressablePopup>();
						popup.Hide();
					});
			});
			_popupManager.GetPopup<AddressablePopup>().AfterHide.Subscribe(_ => {
				AddressablePopupClosed();
			});
		}

		private void AddressablePopupClosed() {
			_popupManager.ShowPopup<MessagePopup>(popup => {
				popup.Init("Now time to see popup with animations :o ", "Show",
					() => {
						popup.Hide();
						ShowAnimationsPopup();
					});
			});
		}

		private void ShowAnimationsPopup() {
			_popupManager.ShowPopup<AnimationsPopup>(popup => {
				popup.Init("Sorry again for bad design :) Now let's add some popups to queue", "Nice!", () => {
					popup.Hide();
				});
				popup.AfterHide.Subscribe(_ => {
					ShowPopupsQueue();
				});
			});
		}

		private void ShowPopupsQueue() {
			_popupManager.ShowPopup<MessagePopup>(popup => {
				popup.Init("Nicely done! now there are two more popups that will show next by next", "Next",
					() => {
						popup.Hide();
					});
			});
			_popupManager.ShowPopup<MessagePopup>(popup1 => {
				popup1.Init("Cool! Left only one", "Next",
					() => {
						popup1.Hide();
					});
			}, PopupOrder.BehindOfOpenPopup);
			_popupManager.ShowPopup<MessagePopup>(popup2 => {
				popup2.Init("That's it we are done :)", "Good job!",
					() => {
						popup2.Hide();
					});
				popup2.AfterHide.Subscribe(_ => {
					ShowLastOne();
				});
			}, PopupOrder.BehindOfOpenPopup);
		}

		private void ShowLastOne() {
			_popupManager.ShowPopup<MessagePopup>(popup => {
				popup.Init("Ok! let me show you another thing :) The dynamic content popup without loading again", "Awesome!",
					() => {
						popup.Hide();
						_dynamicContentPopup.Show();
						_dynamicContentPopup.AfterHide.Subscribe(_ => {
							Done();
						});
					});
			});
		}

		private void Done() {
			_popupManager.ShowPopup<DialogPopup>(popup => {
				popup.Init("Do you want to start again?", () => popup.Hide(),
					() => {
						popup.Hide();
						ShowStartPopup();
					});
			});
		}
	}
}
