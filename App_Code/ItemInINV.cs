using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for ItemInINV
/// </summary>
public class ItemInINV
{
	public ItemInINV()
	{
		//
		// TODO: Add constructor logic here
		//
	}
    private float it_price;

    public float It_price
    {
        get { return it_price; }
        set { it_price = value; }
    }

    private int inv_quant;

    public int Inv_quant
    {
        get { return inv_quant; }
        set { inv_quant = value; }
    }

    private float inv_price;

    public float Inv_price
    {
        get { return inv_price; }
        set { inv_price = value; }
    }

    private string sn;

    public string Sn
    {
        get { return sn; }
        set { sn = value; }
    }

    public ItemInINV(string _sn, float _inv_price, int _inv_quant, float _it_price)
    {
        Sn = _sn;
        Inv_price = _inv_price;
        Inv_quant = _inv_quant;
        It_price = _it_price;

    }


    

}