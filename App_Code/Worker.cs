using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Worker
/// </summary>
public class Worker
{
	public Worker()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    string w_id;

    public string W_id
    {
        get { return w_id; }
        set { w_id = value; }
    }


    string name;

    public string Name
    {
        get { return Name; }
        set { Name = value; }
    }


    string pw;

    public string Pw
    {
        get { return pw; }
        set { pw = value; }
    }

    string title;

    public string Title
    {
        get { return title; }
        set { title = value; }
    }


    public Worker(string _W_id, string _Name, string _Pw, string _Title)
    {
        W_id = _W_id;
        Name = _Name;
        Pw = _Pw;
        Title = _Title;
 
    }
}