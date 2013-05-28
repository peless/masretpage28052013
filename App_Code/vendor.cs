using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for vendor
/// </summary>
public class vendor
{
	public vendor()
	{
		//
		// TODO: Add constructor logic here
		//
	}

        private string number;

    public string Number
    {
        get { return number; }
        set { number = value; }
    }

    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    public vendor(string _number, string _name)
    {
        Number = _number;
        Name = _name;
    }
}