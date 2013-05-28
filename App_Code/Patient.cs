using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

/// <summary>
/// Summary description for Patient
/// </summary>
public class Patient
{
	public Patient()
	{
		//
		// TODO: Add constructor logic here
		//
	}

    private string p_id;

    public string P_id
    {
        get { return p_id; }
        set { p_id = value; }
    }


    private string name;

    public string Name
    {
        get { return name; }
        set { name = value; }
    }


    private string kupah;

    public string Kupah
    {
        get { return kupah; }
        set { kupah = value; }
    }

    private string num;

    public string Num
    {
        get { return num; }
        set { num = value; }
    }

    private string zantar;

    public string Zantar
    {
        get { return zantar; }
        set { zantar = value; }
    }

    private string needle;

    public string Needle
    {
        get { return needle; }
        set { needle = value; }
    }

    private string coil;

    public string Coil
    {
        get { return coil; }
        set { coil = value; }
    }


    private string infusionBag;

    public string InfusionBag
    {
        get { return infusionBag; }
        set { infusionBag = value; }
    }


    private string solutions;

    public string Solutions
    {
        get { return solutions; }
        set { solutions = value; }
    }

    public Patient(string _P_id, string _Name, string _Kupah, string _Num, string _Zantar, string _Needle, string _Coil, string _InfusionBag, string _Solutions)
    {
        P_id = _P_id;
        Name = _Name;
        Kupah = _Kupah;
        Num = _Num;
        Zantar=_Zantar;
        Needle=_Needle;
        Coil=_Coil;
        InfusionBag =_InfusionBag;
        Solutions=_Solutions;
    }
}
