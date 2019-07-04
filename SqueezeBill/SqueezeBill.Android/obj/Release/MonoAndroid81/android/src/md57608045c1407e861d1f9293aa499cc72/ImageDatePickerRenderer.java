package md57608045c1407e861d1f9293aa499cc72;


public class ImageDatePickerRenderer
	extends md51558244f76c53b6aeda52c8a337f2c37.DatePickerRenderer
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"";
		mono.android.Runtime.register ("SqueezeBill.Droid.Renderers.ImageDatePickerRenderer, SqueezeBill.Android", ImageDatePickerRenderer.class, __md_methods);
	}


	public ImageDatePickerRenderer (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == ImageDatePickerRenderer.class)
			mono.android.TypeManager.Activate ("SqueezeBill.Droid.Renderers.ImageDatePickerRenderer, SqueezeBill.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public ImageDatePickerRenderer (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == ImageDatePickerRenderer.class)
			mono.android.TypeManager.Activate ("SqueezeBill.Droid.Renderers.ImageDatePickerRenderer, SqueezeBill.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public ImageDatePickerRenderer (android.content.Context p0)
	{
		super (p0);
		if (getClass () == ImageDatePickerRenderer.class)
			mono.android.TypeManager.Activate ("SqueezeBill.Droid.Renderers.ImageDatePickerRenderer, SqueezeBill.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}

	private java.util.ArrayList refList;
	public void monodroidAddReference (java.lang.Object obj)
	{
		if (refList == null)
			refList = new java.util.ArrayList ();
		refList.add (obj);
	}

	public void monodroidClearReferences ()
	{
		if (refList != null)
			refList.clear ();
	}
}
