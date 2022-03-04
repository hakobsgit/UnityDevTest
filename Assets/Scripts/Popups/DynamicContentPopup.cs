using System;
using System.Collections.Generic;
using Popups.Core;
using UniRx;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;
using Utils;

namespace Popups {
	public class DynamicContentPopup : BasePopup {
		[SerializeField] private Button _button;
		[SerializeField] private RawImage _panelBg;
		[SerializeField] private RawImage _buttonBg;

		private readonly List<IDisposable> _downloadDisposables = new List<IDisposable>();

		public void Init(string bgUrl, string buttonUrl, UnityAction buttonAction, bool closeButtonActive = true) {
			ImageDownloader.Download(bgUrl, SetPanelImage).AddTo(_downloadDisposables);
			ImageDownloader.Download(buttonUrl, SetButtonImage).AddTo(_downloadDisposables);
			SetCloseButtonActive(closeButtonActive);
			_button.onClick.RemoveAllListeners();
			_button.onClick.AddListener(buttonAction);
		}

		public override void Show(Action onComplete = null) {
			Observable.EveryUpdate().TakeWhile(_ => _panelBg.texture == null || _buttonBg.texture == null).Subscribe(
				_ => { }, () => { base.Show(onComplete); });
		}

		public override void Hide(Action onComplete = null) {
			base.Hide(onComplete);
			_downloadDisposables.ForEach(d => d.Dispose());
			_downloadDisposables.Clear();
		}

		private void SetPanelImage(Texture2D image) {
			_panelBg.texture = image;
			_panelBg.rectTransform.sizeDelta = new Vector2(image.width, image.height);
		}

		private void SetButtonImage(Texture2D image) {
			_buttonBg.texture = image;
			_buttonBg.rectTransform.sizeDelta = new Vector2(image.width, image.height);
		}
	}
}