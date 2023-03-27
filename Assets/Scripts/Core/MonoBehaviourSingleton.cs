using System;
using UnityEngine;

namespace Utils.Singletons
{
	public interface IKeepAliveMonoBehaviourSingleton { };
	public interface IAlwaysAccessibleOnQuit { };

	public abstract class MonoBehaviourSingleton<T> : MonoBehaviour where T : MonoBehaviour
	{
		public static bool isQuitting = false;
		public static bool isInitialized = false;

		public static event Action onInitialized;

		public static T instance
		{
			get
			{
				if (isQuitting)
				{
					if (m_instance is IAlwaysAccessibleOnQuit)
					{
						return m_instance;
					}
					else
					{
						return null;
					}
				}

				return m_instance ?? CreateInstance();
			}
		}

		private static T m_instance;

		protected virtual void Awake()
		{
			if (m_instance == null || m_instance == this)
			{
				m_instance = this as T;

				if (this is IKeepAliveMonoBehaviourSingleton)
				{
					DontDestroyOnLoad(gameObject);
				}

				try
				{
					if (!isInitialized)
					{
						Initialization();
						onInitialized?.Invoke();
					}
				}
				catch (Exception E)
				{
				}
				finally
				{
					isInitialized = true;
				}
			}
			else
			{
				Destroy(gameObject);
			}
		}

		private void OnDestroy()
		{
			try
			{
				if (this == m_instance)
				{
					try
					{
						Finalization();
					}
					catch (Exception E)
					{
					}
					finally
					{
						isInitialized = false;
					}
				}
			}
			catch (Exception E)
			{
			}

			if (this == m_instance)
			{
				m_instance = null;
			}
		}

		protected virtual void OnApplicationQuit()
		{
			isQuitting = true;
		}

		protected virtual void Initialization() { }
		protected virtual void Finalization() { }

		private static T CreateInstance()
		{
			if (m_instance == null)
			{
				try
				{
					m_instance = FindObjectOfType<T>() as T;
				}
				catch (Exception E)
				{
				}
				finally
				{
					if (Application.isPlaying)
					{
						if (m_instance == null)
						{
						}
						else
						{
							// кейс, когда мы запрашиваем GameObject, который реально уже существует на сцене, но для которого еще не был вызван Awake:
							// нам придется его удалить, и создать новый с насильным запуском Awake, чтобы все процедуры отработали штатно прямо сейчас
							m_instance.gameObject.SetActive(false);
							Destroy(m_instance.gameObject);
							m_instance = null;

						}

						CreateObjectWithComponent();
					}
#if UNITY_EDITOR
					else
					{
						CreateObjectWithComponent();
					}
#endif
				}
			}
			return m_instance;
		}

		private static void CreateObjectWithComponent()
		{
			var go = new GameObject(typeof(T).ToString());
			// хукаемся так, чтобы m_instance заполнился ДО вызова Awake,
			// тем самым делая неважным порядок вызова Awake в наследовании
			go.SetActive(false);
			m_instance = go.AddComponent<T>();
			go.SetActive(true);
		}


		public static bool hasInstance { get { return (!isQuitting || (m_instance is IAlwaysAccessibleOnQuit)) && m_instance != null; } }
	}
}