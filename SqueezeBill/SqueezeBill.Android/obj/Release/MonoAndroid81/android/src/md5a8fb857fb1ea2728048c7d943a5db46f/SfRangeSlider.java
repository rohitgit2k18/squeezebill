package md5a8fb857fb1ea2728048c7d943a5db46f;


public class SfRangeSlider
	extends android.widget.FrameLayout
	implements
		mono.android.IGCUserPeer
{
/** @hide */
	public static final String __md_methods;
	static {
		__md_methods = 
			"n_onTouchEvent:(Landroid/view/MotionEvent;)Z:GetOnTouchEvent_Landroid_view_MotionEvent_Handler\n" +
			"";
		mono.android.Runtime.register ("Com.Syncfusion.Sfrangeslider.SfRangeSlider, Syncfusion.SfRangeSlider.Android", SfRangeSlider.class, __md_methods);
	}


	public SfRangeSlider (android.content.Context p0)
	{
		super (p0);
		if (getClass () == SfRangeSlider.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Sfrangeslider.SfRangeSlider, Syncfusion.SfRangeSlider.Android", "Android.Content.Context, Mono.Android", this, new java.lang.Object[] { p0 });
	}


	public SfRangeSlider (android.content.Context p0, android.util.AttributeSet p1)
	{
		super (p0, p1);
		if (getClass () == SfRangeSlider.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Sfrangeslider.SfRangeSlider, Syncfusion.SfRangeSlider.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android", this, new java.lang.Object[] { p0, p1 });
	}


	public SfRangeSlider (android.content.Context p0, android.util.AttributeSet p1, int p2)
	{
		super (p0, p1, p2);
		if (getClass () == SfRangeSlider.class)
			mono.android.TypeManager.Activate ("Com.Syncfusion.Sfrangeslider.SfRangeSlider, Syncfusion.SfRangeSlider.Android", "Android.Content.Context, Mono.Android:Android.Util.IAttributeSet, Mono.Android:System.Int32, mscorlib", this, new java.lang.Object[] { p0, p1, p2 });
	}


	public boolean onTouchEvent (android.view.MotionEvent p0)
	{
		return n_onTouchEvent (p0);
	}

	private native boolean n_onTouchEvent (android.view.MotionEvent p0);

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
