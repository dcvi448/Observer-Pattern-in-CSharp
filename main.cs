using System;
using System.Collections.Generic;

public interface Observer
{
	void update(string status);
}
public interface FacebookUserSubject
{
	void registerObserver(Observer o);
	void removeObserver(Observer o);
	void notifyObserver();
}
public class BeautifulGirl : FacebookUserSubject
{
	private LinkedList<Observer > observers = new LinkedList<Observer >();
	private string status;

	public void setStatus(string herStatus)
	{
		this.status = herStatus;
		notifyObserver();
	}
	public void registerObserver(Observer o)
	{
		observers.AddLast(o);
		Console.Write("\n");
		Console.Write("--> System notification: 1 person just follow you!. You have: ");
		Console.Write(observers.Count);
		Console.Write(" follower");
		Console.Write("\n");
	}
	public void removeObserver(Observer o)
	{
		observers.Remove(o);
		Console.Write("\n");
		Console.Write("--> System notification: 1 person just UN-follow you!. You have: ");
		Console.Write(observers.Count);
		Console.Write(" follower");
		Console.Write("\n");
	}
	public void notifyObserver()
	{
		foreach (Observer ob in observers)
		{
			ob.update(status);
		}
	}
}
public class Follower : Observer
{
	private string userName;

	public Follower(string userName)
	{
		this.userName = userName;
	}
	public void update(string herStatus)
	{
		Console.Write("Hello ");
		Console.Write(userName);
		Console.Write("! You have a message from your crush: ");
		Console.Write(herStatus);
		Console.Write("\n");
	}
}
public static class ObserverPattern
{
	internal static void Main()
	{
		BeautifulGirl user = new BeautifulGirl();
		Observer followerA = new Follower("Follower 1");
		Observer followerB = new Follower("Follower 2");
		Observer followerC = new Follower("Follower 3");
		user.registerObserver(followerA);
		user.setStatus("I'm hungry");
		user.registerObserver(followerB);
		user.setStatus("I'm boring");
		user.registerObserver(followerC);
		user.setStatus("I have a boyfriend");
		user.removeObserver(followerB);
		user.setStatus("I will go to Vietnam");
		user.setStatus("I I just broke up with him");
		user.registerObserver(followerB);
		user.setStatus("I have been lived in here for 1 day, the best country that I know");
	}
}
