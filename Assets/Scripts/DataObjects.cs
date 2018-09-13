using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace DataObjects
{
	#region Response Objects
	/// <summary>
	/// ServerResponse object is used to contain data from HTTPResponse. It contains following information: request success, DataObject, errorMessage and errorCode.
	/// </summary>
	public class ServerResponse<T>
	{
		public bool success;
		public T data;
		public string errorMessage;
		public int errorCode;
	}

	[Serializable]
	public class User
	{
		public int id;
		public string name;
		public string username;
		public string email;
		public Address address;
		public string phone;
		public string website;
		public Company company;

		/*
		public User(int id, string name, string username, string email, Address address, string phone, string website, Company company)
		{
			this.id = id;
			this.name = name;
			this.username = username;
			this.email = email;
			this.address = address;
			this.phone = phone;
			this.website = website;
			this.company = company;
		}
		*/
	}

	[Serializable]
	public class Address
	{
		public string street;
		public string suite;
		public string city;
		public string zipcode;
		public Geo geo;
	}

	[Serializable]
	public class Geo
	{
		public string lat;
		public string lng;
	}

	[Serializable]
	public class Company
	{
		public string name;
		public string catchPhrace;
		public string bs;
		/*
		public Company(string name, string catchPhrace, string bs)
		{
			this.name = name;
			this.catchPhrace = catchPhrace;
			this.bs = bs;
		}
		*/
	}

	[Serializable]
	public class Todo
	{
		public int userId;
		public int id;
		public string title;
		public bool completed;
	}

	#endregion
}
