using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Message
/// </summary>
public class Message
{
	public Message()
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

    private string text_message;

    public string Text_message
    {
        get { return text_message; }
        set { text_message = value; }
    }


    public Message(string _number, string _text_message)
    {
        Number = _number;
        Text_message = _text_message;
    }
}