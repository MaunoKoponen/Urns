using System;
using System.Linq;
using System.Threading.Tasks;
using DataObjects;
using UnityEngine;


public class DataController : MonoBehaviour
{
	readonly string USERS_URL = "https://jsonplaceholder.typicode.com/users";
	//readonly string TODOS_URL = "https://jsonplaceholder.typicode.com/todos";

	async Task<User[]> FetchUsers()
	{
		Debug.Log(" FetchUsers");
		var www = await new WWW(USERS_URL);

		Debug.Log("after await line");
		if (!string.IsNullOrEmpty(www.error))
		{
			throw new Exception();
		}

		Debug.Log("after www error check diipa daapa");
		var jsonString = fixJson(www.text);

		Debug.Log(string.Format("json: {0} ", jsonString));

		User[] users = JsonHelper.FromJson<User>(jsonString);

		return users;
	}
	/*
	async Task<Todo[]> FetchTodos()
	{
		var www = await new WWW(TODOS_URL);
		if (!string.IsNullOrEmpty(www.error))
		{
			throw new Exception();
		}
		var json = www.text;
		var todosRaws = JsonHelper.getJsonArray<TodoRaw>(json);
		return todosRaws.Select(todoRaw => new Todo(todoRaw)).ToArray();
	}
	*/


	string fixJson(string value)
	{
		value = "{\"Items\":" + value + "}";
		return value;
	}

	async void Start()
	{
		try
		{
			Debug.Log("A");

			var users = await FetchUsers();
			//var todos = await FetchTodos();

			Debug.Log("B");


			foreach (User user in users)
			{
				Debug.Log(user.name);
			}

			Debug.Log("C");


			/*
			foreach (Todo todo in todos)
			{
				Debug.Log(todo.Title);
			}
			*/
		}
		catch
		{
			Debug.Log("<color=#ff00ffff> An error occurred</color>" );
		}
	}
}