using System;
using System.Linq;
using System.Threading.Tasks;
using DataObjects;
using UnityEngine;


public class DataController : MonoBehaviour
{
	readonly string USERS_URL = "https://jsonplaceholder.typicode.com/users";
	readonly string TODOS_URL = "https://jsonplaceholder.typicode.com/todos";

	async Task<User[]> FetchUsers()
	{
		Debug.Log(" FetchUsers");
		var www = await new WWW(USERS_URL);

		if (!string.IsNullOrEmpty(www.error))
		{
			throw new Exception();
		}

		var jsonString = www.text;

		Debug.Log(string.Format("json: {0} ", jsonString));

		User[] users = JsonHelper.FromServerJson<User>(jsonString);

		return users;
	}
	
	async Task<Todo[]> FetchTodos()
	{
		var www = await new WWW(TODOS_URL);
		if (!string.IsNullOrEmpty(www.error))
		{
			throw new Exception();
		}

		var jsonString = www.text;

		//Debug.Log(string.Format("json: {0} ", jsonString));

		Todo[] todos = JsonHelper.FromServerJson<Todo>(jsonString);

		return todos;
	}

	async void Start()
	{


		try
		{
			var usersTask = FetchUsers();
			var todosTask = FetchTodos();
			await Task.WhenAll(usersTask, todosTask);
			var users = await usersTask;
			var todos = await todosTask;

			foreach (User user in users)
			{
				Debug.Log(user.name);
			}
			foreach (Todo todo in todos)
			{
				Debug.Log(todo.title);
			}
		}
		catch
		{
			Debug.Log("An error occurred");
		}
	}
	/*
	async void Start()
	{
		try
		{
			Debug.Log("A");

			var users = await FetchUsers();
			var todos = await FetchTodos();

			Debug.Log("B");


			foreach (User user in users)
			{

				//Debug.Log(string.Format("Name: {0}", user.name));
				Debug.Log(string.Format("Name: {0} Company {1} Company bs {2}", user.name, user.company.name, user.company.bs));
			}

			Debug.Log("C");


			
			foreach (Todo todo in todos)
			{
				Debug.Log(todo.title);
			}
			
		}
		catch
		{
			Debug.Log("<color=#ff00ffff> An error occurred</color>" );
		}
	}
	*/
}