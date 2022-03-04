using System;
using System.Collections;
using UniRx;
using UnityEngine;
using UnityEngine.Networking;

namespace Utils {
	public static class ImageDownloader {
		public static IDisposable Download(string url, Action<Texture2D> onSuccess,
			Action<string> onError = null) {
			return Observable.FromCoroutine(_ => DownloadEnumerator(url, onSuccess, onError)).Subscribe();
		}
		
		public static IEnumerator DownloadEnumerator(string url, Action<Texture2D> onSuccess,
			Action<string> onError = null) {
			UnityWebRequest request = UnityWebRequestTexture.GetTexture(url);
			yield return request.SendWebRequest();
			if (request.result == UnityWebRequest.Result.ConnectionError ||
			    request.result == UnityWebRequest.Result.ProtocolError)
				onError?.Invoke(request.error);
			else
				onSuccess?.Invoke(((DownloadHandlerTexture) request.downloadHandler).texture);
		}
	}
}