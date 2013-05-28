using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Order
/// </summary>
public class Order
{
	public Order()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string po_id;

    public string Po_id
    {
        get { return po_id; }
        set { po_id = value; }
    }


    private string status;

    public string Status
    {
        get { return status; }
        set { status = value; }
    }


    private string po_date;

    public string Po_date
    {
        get { return po_date; }
        set { po_date = value; }
    }

    private string sup_date;

    public string Sup_date
    {
        get { return sup_date; }
        set { sup_date = value; }
    }


    public Order(string _po_id, string _Status, string _Po_date, string _Sup_date)
    {
        Po_id = _po_id;
        Status = _Status;
        Po_date = _Po_date;
        Sup_date = _Sup_date;
    }
}
