# unity-mvp
Implementation of MVP (Model-View-Presenter) architectural pattern via Unity engine.

Before starting, it is recommended to get [sample project](https://github.com/dancher743/unity-mvp/releases/tag/sample-project).

Getting Started
---
### What is MVP?
**MVP** or **Model-View-Presenter** is an architectural pattern, which consists of three components: _Model_, _View_ and _Presenter_.

* _Model_ is a data.
* _View_ is an interface that displays data and routes user commands to Presenter.
* _Presenter_ wires up Model and View together and thereby creates a functioning entity.

[![MVP-diagram.png](https://i.postimg.cc/jSCcjt5W/MVP-diagram.png)](https://postimg.cc/w18LfKDH)

For more information about MVP, check an original source - ["MVP: Model-View-Presenter. The Taligent Programming Model for C++ and Java." Mike Potel](http://www.wildcrest.com/Potel/Portfolio/mvp.pdf).

### Creating a Model
Implement `IModel` interface to create a _Model_ -

```
public class CubeModel : IModel
{
	...
}
```

### Creating a View
Implement `IView` interface to create a _View_ -

```
public class CubeView : MonoBehaviour, IView
{
	...
}
```

You can also use `MonoView` class as an "stub" instead of `MonoBehaviour` -

`public class CubeView : MonoView, IView`

### Creating a Presenter
Create a `CubePresenter` class and derive it from `Presenter<TView, TModel>`. Specify types: `TView` and `TModel`. In our case `TModel` is `CubeModel` and `TView` is `CubeView` -

`CubePresenter : Presenter<CubeView, CubeModel>`

```
public class CubePresenter : Presenter<CubeView, CubeModel>
{
	public CubePresenter(CubeView cubeView, CubeModel cubeModel) : base(cubeView, cubeModel)
	{
		...
	}
}
```

At this point we're done with the main components of MVP - `CubeModel`, `CubeView` and `CubePresenter`!

Instantiating
---
To create an instance of a `Presenter` use `Create<TPresenter>()` method in `PresenterFactory` -

```
[SerializeField]
private CubeView cubeView;

...

private CubePresenter cubePresenter;

...

void Start()
{
	cubePresenter = presenterFactory.Create<CubePresenter>(cubeView, new CubeModel());
}
```
`PresenterFactory` is built-in implementation of `IPresenterFactory` interface -

```
public interface IPresenterFactory
{
	public TPresenter Create<TPresenter>(params object[] data) where TPresenter : IPresenter;
}
```

But you can implement your own factory.

Messaging
---
### Message Dispatcher
Each `Presenter` should interact with another `Presenter`. One possible way to do it is to use messages. `MessageDispatcher` is a class which provides needed functionality for messaging.

But to receive a _Message_ we need a _Subscriber_.

### Receive a Message
Implement `IMessageSubscriber` interface to make some class available for message receiving -

```
public interface IMessageSubscriber
{
	void ReceiveMessage<TMessage>(TMessage message);
}
```

In the example we have `UIPresenter` -

```
public class UIPresenter : Presenter<UIView, UIModel>, IMessageSubscriber
{
	...
	
	void IMessageSubscriber.ReceiveMessage<TMessage>(TMessage message)
	{
		switch (message)
		{
			case CubeColorMessage cubeColorMessage:
				model.ColorText = cubeColorMessage.Color.ToString();
				break;
		}
	}
}
```

Switch-case is used here as a way to handle a message from `CubePresenter`.

### Send a Message
To send a _Message_ to some `Presenter` use `SendMessageTo<TSubscriber, TMessage>(TMessage message)` method in `PresenterManager` -

`PresenterManager.DispatchMessageTo<UIPresenter, CubeColorData>(new CubeColorData(color))`

In the example where `CubePresenter` class is -

```
public class CubePresenter : Presenter<CubeView, CubeModel>
{
  	...

	private void OnModelColorChanged(Color color)
	{
		view.Color = color;
		messageDispatcher.SendMessageTo<UIPresenter, CubeColorMessage>(new CubeColorMessage { Color = color });
	}
}
```

Clearing
---
To clear a `Presenter` (or some class) you can use built-in `IClearable` interface -

```
public interface IClearable
{
	public void Clear();
}
```

Base `Presenter` class implements `IClearable` interface -

`Presenter<TView, TModel> : IPresenter, IClearable`

In the example, inside of `EntryPoint.OnDestroy()` method `Clear` is used to free up resources -

```
public class EntryPoint : MonoBehaviour
{
	private CubePresenter cubePresenter;
	private UIPresenter UIPresenter;

	...

	private void OnDestroy()
	{
		cubePresenter.Clear();
		UIPresenter.Clear();
	}
{
```

Sample
---
Sample project with the latest version of the package is available [here](https://github.com/dancher743/unity-mvp/releases/tag/sample-project).
