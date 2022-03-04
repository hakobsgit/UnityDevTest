using UnityEngine;

namespace Interfaces.Factories {
	public interface IPrefabFactory {
		GameObject Create(GameObject prefab);
		GameObject Create(GameObject prefab, Transform container);
		GameObject Create(string path);
		GameObject Create(string path, Transform container);
		T Create<T>(string path);
		T Create<T>(string path, Transform parent);
		T Create<T>(T original) where T : Object;
		T Create<T>(T original, Transform parent) where T : Object;
		T Create<T>(GameObject original) where T : Object;
		T Create<T>(GameObject original, Transform parent) where T : Object;
	}
}