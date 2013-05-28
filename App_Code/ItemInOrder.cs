using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemInOrder
/// </summary>
public class ItemInOrder
{
	public ItemInOrder()
	{
		//
		// TODO: Add constructor logic here
		//
	}



    string po_id;

    public string Po_id
    {
        get { return po_id; }
        set { po_id = value; }
    }

    string serialnumber;

    public string Serialnumber
    {
        get { return serialnumber; }
        set { serialnumber = value; }
    }

    string quant;

    public string Quant
    {
        get { return quant; }
        set { quant = value; }
    }
    private string stat;

    public string Stat
    {
        get { return stat; }
        set { stat = value; }
    }


    public ItemInOrder(string _po_id, string _serialnumber, string _quant,string _stat)
    {
        Po_id = _po_id;
        Serialnumber = _serialnumber;
        Quant = _quant;
        Stat = _stat;
    }
}