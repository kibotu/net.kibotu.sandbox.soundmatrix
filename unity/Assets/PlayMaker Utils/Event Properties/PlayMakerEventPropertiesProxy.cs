using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayMakerEventPropertiesProxy : Object {

	public Dictionary<string,object> properties;
	
	public PlayMakerEventPropertiesProxy()
	{
		properties = new Dictionary<string, object>();
	}
}
