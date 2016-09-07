using System;
using System.Diagnostics;
using System.Runtime.Serialization;
using System.Collections;
using Object = UnityEngine.Object;

public class IDGenerator
{
    private InGameController _IGC;
    private ObjectIDGenerator _generator;
    private bool firstime;

	public void Init (InGameController igc)
	{
	    _IGC = igc;
        _generator = new ObjectIDGenerator();
	}
	
	public long GetID (object obj)
	{
	    var temp = _generator.GetId(obj, out firstime);
	    if (!firstime)
	    {
	        throw new Exception("THIS OBJECT HAS ALREADY BEEN ASSIGNED A ID!");
	    }
	    return temp;
	}
}
