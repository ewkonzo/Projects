package android.support.v7.internal.widget;

import android.content.Context;
import android.content.res.TypedArray;
import android.graphics.Bitmap;
import android.graphics.BitmapShader;
import android.graphics.Paint;
import android.graphics.Rect;
import android.graphics.Shader.TileMode;
import android.graphics.drawable.Animatable;
import android.graphics.drawable.AnimationDrawable;
import android.graphics.drawable.BitmapDrawable;
import android.graphics.drawable.ClipDrawable;
import android.graphics.drawable.Drawable;
import android.graphics.drawable.LayerDrawable;
import android.graphics.drawable.ShapeDrawable;
import android.graphics.drawable.shapes.RoundRectShape;
import android.graphics.drawable.shapes.Shape;
import android.os.Parcel;
import android.os.Parcelable;
import android.os.Parcelable.Creator;
import android.util.AttributeSet;
import android.view.View;
import android.view.View.BaseSavedState;
import android.view.animation.AlphaAnimation;
import android.view.animation.AnimationUtils;
import android.view.animation.Interpolator;
import android.view.animation.LinearInterpolator;
import android.view.animation.Transformation;

public class ProgressBarICS
  extends View
{
  private static final int ANIMATION_RESOLUTION = 200;
  private static final int MAX_LEVEL = 10000;
  private static final int[] android_R_styleable_ProgressBar = { 16843062, 16843063, 16843064, 16843065, 16843066, 16843067, 16843068, 16843069, 16843070, 16843071, 16843039, 16843072, 16843040, 16843073 };
  private AlphaAnimation mAnimation;
  private int mBehavior;
  private Drawable mCurrentDrawable;
  private int mDuration;
  private boolean mInDrawing;
  private boolean mIndeterminate;
  private Drawable mIndeterminateDrawable;
  private Interpolator mInterpolator;
  private long mLastDrawTime;
  private int mMax;
  int mMaxHeight;
  int mMaxWidth;
  int mMinHeight;
  int mMinWidth;
  private boolean mNoInvalidate;
  private boolean mOnlyIndeterminate;
  private int mProgress;
  private Drawable mProgressDrawable;
  private RefreshProgressRunnable mRefreshProgressRunnable;
  Bitmap mSampleTile;
  private int mSecondaryProgress;
  private boolean mShouldStartAnimationDrawable;
  private Transformation mTransformation;
  private long mUiThreadId = Thread.currentThread().getId();
  
  public ProgressBarICS(Context paramContext, AttributeSet paramAttributeSet, int paramInt1, int paramInt2)
  {
    super(paramContext, paramAttributeSet, paramInt1);
    initProgressBar();
    paramAttributeSet = paramContext.obtainStyledAttributes(paramAttributeSet, android_R_styleable_ProgressBar, paramInt1, paramInt2);
    this.mNoInvalidate = true;
    setMax(paramAttributeSet.getInt(0, this.mMax));
    setProgress(paramAttributeSet.getInt(1, this.mProgress));
    setSecondaryProgress(paramAttributeSet.getInt(2, this.mSecondaryProgress));
    boolean bool2 = paramAttributeSet.getBoolean(3, this.mIndeterminate);
    this.mOnlyIndeterminate = paramAttributeSet.getBoolean(4, this.mOnlyIndeterminate);
    Drawable localDrawable = paramAttributeSet.getDrawable(5);
    if (localDrawable != null) {
      setIndeterminateDrawable(tileifyIndeterminate(localDrawable));
    }
    localDrawable = paramAttributeSet.getDrawable(6);
    if (localDrawable != null) {
      setProgressDrawable(tileify(localDrawable, false));
    }
    this.mDuration = paramAttributeSet.getInt(7, this.mDuration);
    this.mBehavior = paramAttributeSet.getInt(8, this.mBehavior);
    this.mMinWidth = paramAttributeSet.getDimensionPixelSize(9, this.mMinWidth);
    this.mMaxWidth = paramAttributeSet.getDimensionPixelSize(10, this.mMaxWidth);
    this.mMinHeight = paramAttributeSet.getDimensionPixelSize(11, this.mMinHeight);
    this.mMaxHeight = paramAttributeSet.getDimensionPixelSize(12, this.mMaxHeight);
    paramInt1 = paramAttributeSet.getResourceId(13, 17432587);
    if (paramInt1 > 0) {
      setInterpolator(paramContext, paramInt1);
    }
    paramAttributeSet.recycle();
    this.mNoInvalidate = false;
    if ((this.mOnlyIndeterminate) || (bool2)) {
      bool1 = true;
    }
    setIndeterminate(bool1);
  }
  
  private void doRefreshProgress(int paramInt1, int paramInt2, boolean paramBoolean1, boolean paramBoolean2)
  {
    for (;;)
    {
      try
      {
        float f;
        Drawable localDrawable2;
        Drawable localDrawable1;
        if (this.mMax > 0)
        {
          f = paramInt2 / this.mMax;
          localDrawable2 = this.mCurrentDrawable;
          if (localDrawable2 != null)
          {
            localDrawable1 = null;
            if (!(localDrawable2 instanceof LayerDrawable)) {
              break label92;
            }
            localDrawable1 = ((LayerDrawable)localDrawable2).findDrawableByLayerId(paramInt1);
            break label92;
            localDrawable1.setLevel(paramInt1);
          }
        }
        else
        {
          f = 0.0F;
          continue;
          localDrawable1 = localDrawable2;
          continue;
        }
        invalidate();
        continue;
        paramInt1 = (int)(10000.0F * f);
      }
      finally {}
      label92:
      if (localObject == null) {}
    }
  }
  
  private void initProgressBar()
  {
    this.mMax = 100;
    this.mProgress = 0;
    this.mSecondaryProgress = 0;
    this.mIndeterminate = false;
    this.mOnlyIndeterminate = false;
    this.mDuration = 4000;
    this.mBehavior = 1;
    this.mMinWidth = 24;
    this.mMaxWidth = 48;
    this.mMinHeight = 24;
    this.mMaxHeight = 48;
  }
  
  private void refreshProgress(int paramInt1, int paramInt2, boolean paramBoolean)
  {
    for (;;)
    {
      try
      {
        if (this.mUiThreadId == Thread.currentThread().getId())
        {
          doRefreshProgress(paramInt1, paramInt2, paramBoolean, true);
          return;
        }
        if (this.mRefreshProgressRunnable != null)
        {
          RefreshProgressRunnable localRefreshProgressRunnable1 = this.mRefreshProgressRunnable;
          this.mRefreshProgressRunnable = null;
          localRefreshProgressRunnable1.setup(paramInt1, paramInt2, paramBoolean);
          post(localRefreshProgressRunnable1);
        }
        else
        {
          RefreshProgressRunnable localRefreshProgressRunnable2 = new RefreshProgressRunnable(paramInt1, paramInt2, paramBoolean);
        }
      }
      finally {}
    }
  }
  
  private Drawable tileify(Drawable paramDrawable, boolean paramBoolean)
  {
    Object localObject;
    if ((paramDrawable instanceof LayerDrawable))
    {
      LayerDrawable localLayerDrawable = (LayerDrawable)paramDrawable;
      int j = localLayerDrawable.getNumberOfLayers();
      paramDrawable = new Drawable[j];
      int i = 0;
      if (i < j)
      {
        int k = localLayerDrawable.getId(i);
        localObject = localLayerDrawable.getDrawable(i);
        if ((k == 16908301) || (k == 16908303)) {}
        for (paramBoolean = true;; paramBoolean = false)
        {
          paramDrawable[i] = tileify((Drawable)localObject, paramBoolean);
          i += 1;
          break;
        }
      }
      localObject = new LayerDrawable(paramDrawable);
      i = 0;
      for (;;)
      {
        paramDrawable = (Drawable)localObject;
        if (i >= j) {
          break;
        }
        ((LayerDrawable)localObject).setId(i, localLayerDrawable.getId(i));
        i += 1;
      }
    }
    if ((paramDrawable instanceof BitmapDrawable))
    {
      paramDrawable = ((BitmapDrawable)paramDrawable).getBitmap();
      if (this.mSampleTile == null) {
        this.mSampleTile = paramDrawable;
      }
      localObject = new ShapeDrawable(getDrawableShape());
      paramDrawable = new BitmapShader(paramDrawable, Shader.TileMode.REPEAT, Shader.TileMode.CLAMP);
      ((ShapeDrawable)localObject).getPaint().setShader(paramDrawable);
      paramDrawable = (Drawable)localObject;
      if (paramBoolean) {
        paramDrawable = new ClipDrawable((Drawable)localObject, 3, 1);
      }
      return paramDrawable;
    }
    return paramDrawable;
  }
  
  private Drawable tileifyIndeterminate(Drawable paramDrawable)
  {
    Object localObject = paramDrawable;
    if ((paramDrawable instanceof AnimationDrawable))
    {
      paramDrawable = (AnimationDrawable)paramDrawable;
      int j = paramDrawable.getNumberOfFrames();
      localObject = new AnimationDrawable();
      ((AnimationDrawable)localObject).setOneShot(paramDrawable.isOneShot());
      int i = 0;
      while (i < j)
      {
        Drawable localDrawable = tileify(paramDrawable.getFrame(i), true);
        localDrawable.setLevel(10000);
        ((AnimationDrawable)localObject).addFrame(localDrawable, paramDrawable.getDuration(i));
        i += 1;
      }
      ((AnimationDrawable)localObject).setLevel(10000);
    }
    return (Drawable)localObject;
  }
  
  private void updateDrawableBounds(int paramInt1, int paramInt2)
  {
    int k = paramInt1 - getPaddingRight() - getPaddingLeft();
    int m = paramInt2 - getPaddingBottom() - getPaddingTop();
    int i2 = 0;
    int i3 = 0;
    int i = m;
    int j = k;
    int i1;
    int n;
    float f1;
    if (this.mIndeterminateDrawable != null)
    {
      i = m;
      i1 = i3;
      j = k;
      n = i2;
      if (this.mOnlyIndeterminate)
      {
        i = m;
        i1 = i3;
        j = k;
        n = i2;
        if (!(this.mIndeterminateDrawable instanceof AnimationDrawable))
        {
          i = this.mIndeterminateDrawable.getIntrinsicWidth();
          j = this.mIndeterminateDrawable.getIntrinsicHeight();
          f1 = i / j;
          float f2 = paramInt1 / paramInt2;
          i = m;
          i1 = i3;
          j = k;
          n = i2;
          if (f1 != f2)
          {
            if (f2 <= f1) {
              break label222;
            }
            paramInt2 = (int)(paramInt2 * f1);
            i1 = (paramInt1 - paramInt2) / 2;
            j = i1 + paramInt2;
            n = i2;
            i = m;
          }
        }
      }
    }
    for (;;)
    {
      this.mIndeterminateDrawable.setBounds(i1, n, j, i);
      if (this.mProgressDrawable != null) {
        this.mProgressDrawable.setBounds(0, 0, j, i);
      }
      return;
      label222:
      paramInt1 = (int)(paramInt1 * (1.0F / f1));
      n = (paramInt2 - paramInt1) / 2;
      i = n + paramInt1;
      i1 = i3;
      j = k;
    }
  }
  
  private void updateDrawableState()
  {
    int[] arrayOfInt = getDrawableState();
    if ((this.mProgressDrawable != null) && (this.mProgressDrawable.isStateful())) {
      this.mProgressDrawable.setState(arrayOfInt);
    }
    if ((this.mIndeterminateDrawable != null) && (this.mIndeterminateDrawable.isStateful())) {
      this.mIndeterminateDrawable.setState(arrayOfInt);
    }
  }
  
  protected void drawableStateChanged()
  {
    super.drawableStateChanged();
    updateDrawableState();
  }
  
  Shape getDrawableShape()
  {
    return new RoundRectShape(new float[] { 5.0F, 5.0F, 5.0F, 5.0F, 5.0F, 5.0F, 5.0F, 5.0F }, null, null);
  }
  
  public Drawable getIndeterminateDrawable()
  {
    return this.mIndeterminateDrawable;
  }
  
  public Interpolator getInterpolator()
  {
    return this.mInterpolator;
  }
  
  public int getMax()
  {
    try
    {
      int i = this.mMax;
      return i;
    }
    finally
    {
      localObject = finally;
      throw ((Throwable)localObject);
    }
  }
  
  /* Error */
  public int getProgress()
  {
    // Byte code:
    //   0: aload_0
    //   1: monitorenter
    //   2: aload_0
    //   3: getfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   6: istore_3
    //   7: iload_3
    //   8: ifeq +9 -> 17
    //   11: iconst_0
    //   12: istore_2
    //   13: aload_0
    //   14: monitorexit
    //   15: iload_2
    //   16: ireturn
    //   17: aload_0
    //   18: getfield 114	android/support/v7/internal/widget/ProgressBarICS:mProgress	I
    //   21: istore_2
    //   22: goto -9 -> 13
    //   25: astore_1
    //   26: aload_0
    //   27: monitorexit
    //   28: aload_1
    //   29: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	30	0	this	ProgressBarICS
    //   25	4	1	localObject	Object
    //   12	10	2	i	int
    //   6	2	3	bool	boolean
    // Exception table:
    //   from	to	target	type
    //   2	7	25	finally
    //   17	22	25	finally
  }
  
  public Drawable getProgressDrawable()
  {
    return this.mProgressDrawable;
  }
  
  /* Error */
  public int getSecondaryProgress()
  {
    // Byte code:
    //   0: aload_0
    //   1: monitorenter
    //   2: aload_0
    //   3: getfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   6: istore_3
    //   7: iload_3
    //   8: ifeq +9 -> 17
    //   11: iconst_0
    //   12: istore_2
    //   13: aload_0
    //   14: monitorexit
    //   15: iload_2
    //   16: ireturn
    //   17: aload_0
    //   18: getfield 119	android/support/v7/internal/widget/ProgressBarICS:mSecondaryProgress	I
    //   21: istore_2
    //   22: goto -9 -> 13
    //   25: astore_1
    //   26: aload_0
    //   27: monitorexit
    //   28: aload_1
    //   29: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	30	0	this	ProgressBarICS
    //   25	4	1	localObject	Object
    //   12	10	2	i	int
    //   6	2	3	bool	boolean
    // Exception table:
    //   from	to	target	type
    //   2	7	25	finally
    //   17	22	25	finally
  }
  
  public final void incrementProgressBy(int paramInt)
  {
    try
    {
      setProgress(this.mProgress + paramInt);
      return;
    }
    finally
    {
      localObject = finally;
      throw ((Throwable)localObject);
    }
  }
  
  public final void incrementSecondaryProgressBy(int paramInt)
  {
    try
    {
      setSecondaryProgress(this.mSecondaryProgress + paramInt);
      return;
    }
    finally
    {
      localObject = finally;
      throw ((Throwable)localObject);
    }
  }
  
  public void invalidateDrawable(Drawable paramDrawable)
  {
    if (!this.mInDrawing)
    {
      if (verifyDrawable(paramDrawable))
      {
        paramDrawable = paramDrawable.getBounds();
        int i = getScrollX() + getPaddingLeft();
        int j = getScrollY() + getPaddingTop();
        invalidate(paramDrawable.left + i, paramDrawable.top + j, paramDrawable.right + i, paramDrawable.bottom + j);
      }
    }
    else {
      return;
    }
    super.invalidateDrawable(paramDrawable);
  }
  
  public boolean isIndeterminate()
  {
    try
    {
      boolean bool = this.mIndeterminate;
      return bool;
    }
    finally
    {
      localObject = finally;
      throw ((Throwable)localObject);
    }
  }
  
  protected void onAttachedToWindow()
  {
    super.onAttachedToWindow();
    if (this.mIndeterminate) {
      startAnimation();
    }
  }
  
  protected void onDetachedFromWindow()
  {
    if (this.mIndeterminate) {
      stopAnimation();
    }
    if (this.mRefreshProgressRunnable != null) {
      removeCallbacks(this.mRefreshProgressRunnable);
    }
    super.onDetachedFromWindow();
  }
  
  /* Error */
  protected void onDraw(android.graphics.Canvas paramCanvas)
  {
    // Byte code:
    //   0: aload_0
    //   1: monitorenter
    //   2: aload_0
    //   3: aload_1
    //   4: invokespecial 423	android/view/View:onDraw	(Landroid/graphics/Canvas;)V
    //   7: aload_0
    //   8: getfield 191	android/support/v7/internal/widget/ProgressBarICS:mCurrentDrawable	Landroid/graphics/drawable/Drawable;
    //   11: astore_3
    //   12: aload_3
    //   13: ifnull +143 -> 156
    //   16: aload_1
    //   17: invokevirtual 428	android/graphics/Canvas:save	()I
    //   20: pop
    //   21: aload_1
    //   22: aload_0
    //   23: invokevirtual 313	android/support/v7/internal/widget/ProgressBarICS:getPaddingLeft	()I
    //   26: i2f
    //   27: aload_0
    //   28: invokevirtual 319	android/support/v7/internal/widget/ProgressBarICS:getPaddingTop	()I
    //   31: i2f
    //   32: invokevirtual 432	android/graphics/Canvas:translate	(FF)V
    //   35: aload_0
    //   36: invokevirtual 435	android/support/v7/internal/widget/ProgressBarICS:getDrawingTime	()J
    //   39: lstore 4
    //   41: aload_0
    //   42: getfield 437	android/support/v7/internal/widget/ProgressBarICS:mAnimation	Landroid/view/animation/AlphaAnimation;
    //   45: ifnull +74 -> 119
    //   48: aload_0
    //   49: getfield 437	android/support/v7/internal/widget/ProgressBarICS:mAnimation	Landroid/view/animation/AlphaAnimation;
    //   52: lload 4
    //   54: aload_0
    //   55: getfield 439	android/support/v7/internal/widget/ProgressBarICS:mTransformation	Landroid/view/animation/Transformation;
    //   58: invokevirtual 445	android/view/animation/AlphaAnimation:getTransformation	(JLandroid/view/animation/Transformation;)Z
    //   61: pop
    //   62: aload_0
    //   63: getfield 439	android/support/v7/internal/widget/ProgressBarICS:mTransformation	Landroid/view/animation/Transformation;
    //   66: invokevirtual 451	android/view/animation/Transformation:getAlpha	()F
    //   69: fstore_2
    //   70: aload_0
    //   71: iconst_1
    //   72: putfield 371	android/support/v7/internal/widget/ProgressBarICS:mInDrawing	Z
    //   75: aload_3
    //   76: ldc -50
    //   78: fload_2
    //   79: fmul
    //   80: f2i
    //   81: invokevirtual 202	android/graphics/drawable/Drawable:setLevel	(I)Z
    //   84: pop
    //   85: aload_0
    //   86: iconst_0
    //   87: putfield 371	android/support/v7/internal/widget/ProgressBarICS:mInDrawing	Z
    //   90: invokestatic 456	android/os/SystemClock:uptimeMillis	()J
    //   93: aload_0
    //   94: getfield 458	android/support/v7/internal/widget/ProgressBarICS:mLastDrawTime	J
    //   97: lsub
    //   98: ldc2_w 459
    //   101: lcmp
    //   102: iflt +17 -> 119
    //   105: aload_0
    //   106: invokestatic 456	android/os/SystemClock:uptimeMillis	()J
    //   109: putfield 458	android/support/v7/internal/widget/ProgressBarICS:mLastDrawTime	J
    //   112: aload_0
    //   113: ldc2_w 459
    //   116: invokevirtual 464	android/support/v7/internal/widget/ProgressBarICS:postInvalidateDelayed	(J)V
    //   119: aload_3
    //   120: aload_1
    //   121: invokevirtual 467	android/graphics/drawable/Drawable:draw	(Landroid/graphics/Canvas;)V
    //   124: aload_1
    //   125: invokevirtual 470	android/graphics/Canvas:restore	()V
    //   128: aload_0
    //   129: getfield 472	android/support/v7/internal/widget/ProgressBarICS:mShouldStartAnimationDrawable	Z
    //   132: ifeq +24 -> 156
    //   135: aload_3
    //   136: instanceof 474
    //   139: ifeq +17 -> 156
    //   142: aload_3
    //   143: checkcast 474	android/graphics/drawable/Animatable
    //   146: invokeinterface 477 1 0
    //   151: aload_0
    //   152: iconst_0
    //   153: putfield 472	android/support/v7/internal/widget/ProgressBarICS:mShouldStartAnimationDrawable	Z
    //   156: aload_0
    //   157: monitorexit
    //   158: return
    //   159: astore_1
    //   160: aload_0
    //   161: iconst_0
    //   162: putfield 371	android/support/v7/internal/widget/ProgressBarICS:mInDrawing	Z
    //   165: aload_1
    //   166: athrow
    //   167: astore_1
    //   168: aload_0
    //   169: monitorexit
    //   170: aload_1
    //   171: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	172	0	this	ProgressBarICS
    //   0	172	1	paramCanvas	android.graphics.Canvas
    //   69	10	2	f	float
    //   11	132	3	localDrawable	Drawable
    //   39	14	4	l	long
    // Exception table:
    //   from	to	target	type
    //   70	85	159	finally
    //   2	12	167	finally
    //   16	70	167	finally
    //   85	119	167	finally
    //   119	156	167	finally
    //   160	167	167	finally
  }
  
  protected void onMeasure(int paramInt1, int paramInt2)
  {
    try
    {
      Drawable localDrawable = this.mCurrentDrawable;
      int j = 0;
      int i = 0;
      if (localDrawable != null)
      {
        j = Math.max(this.mMinWidth, Math.min(this.mMaxWidth, localDrawable.getIntrinsicWidth()));
        i = Math.max(this.mMinHeight, Math.min(this.mMaxHeight, localDrawable.getIntrinsicHeight()));
      }
      updateDrawableState();
      int k = getPaddingLeft();
      int m = getPaddingRight();
      int n = getPaddingTop();
      int i1 = getPaddingBottom();
      setMeasuredDimension(resolveSize(j + (k + m), paramInt1), resolveSize(i + (n + i1), paramInt2));
      return;
    }
    finally {}
  }
  
  public void onRestoreInstanceState(Parcelable paramParcelable)
  {
    paramParcelable = (SavedState)paramParcelable;
    super.onRestoreInstanceState(paramParcelable.getSuperState());
    setProgress(paramParcelable.progress);
    setSecondaryProgress(paramParcelable.secondaryProgress);
  }
  
  public Parcelable onSaveInstanceState()
  {
    SavedState localSavedState = new SavedState(super.onSaveInstanceState());
    localSavedState.progress = this.mProgress;
    localSavedState.secondaryProgress = this.mSecondaryProgress;
    return localSavedState;
  }
  
  protected void onSizeChanged(int paramInt1, int paramInt2, int paramInt3, int paramInt4)
  {
    updateDrawableBounds(paramInt1, paramInt2);
  }
  
  protected void onVisibilityChanged(View paramView, int paramInt)
  {
    super.onVisibilityChanged(paramView, paramInt);
    if (this.mIndeterminate)
    {
      if ((paramInt == 8) || (paramInt == 4)) {
        stopAnimation();
      }
    }
    else {
      return;
    }
    startAnimation();
  }
  
  public void postInvalidate()
  {
    if (!this.mNoInvalidate) {
      super.postInvalidate();
    }
  }
  
  /* Error */
  public void setIndeterminate(boolean paramBoolean)
  {
    // Byte code:
    //   0: aload_0
    //   1: monitorenter
    //   2: aload_0
    //   3: getfield 130	android/support/v7/internal/widget/ProgressBarICS:mOnlyIndeterminate	Z
    //   6: ifeq +10 -> 16
    //   9: aload_0
    //   10: getfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   13: ifne +32 -> 45
    //   16: iload_1
    //   17: aload_0
    //   18: getfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   21: if_icmpeq +24 -> 45
    //   24: aload_0
    //   25: iload_1
    //   26: putfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   29: iload_1
    //   30: ifeq +18 -> 48
    //   33: aload_0
    //   34: aload_0
    //   35: getfield 321	android/support/v7/internal/widget/ProgressBarICS:mIndeterminateDrawable	Landroid/graphics/drawable/Drawable;
    //   38: putfield 191	android/support/v7/internal/widget/ProgressBarICS:mCurrentDrawable	Landroid/graphics/drawable/Drawable;
    //   41: aload_0
    //   42: invokevirtual 410	android/support/v7/internal/widget/ProgressBarICS:startAnimation	()V
    //   45: aload_0
    //   46: monitorexit
    //   47: return
    //   48: aload_0
    //   49: aload_0
    //   50: getfield 333	android/support/v7/internal/widget/ProgressBarICS:mProgressDrawable	Landroid/graphics/drawable/Drawable;
    //   53: putfield 191	android/support/v7/internal/widget/ProgressBarICS:mCurrentDrawable	Landroid/graphics/drawable/Drawable;
    //   56: aload_0
    //   57: invokevirtual 414	android/support/v7/internal/widget/ProgressBarICS:stopAnimation	()V
    //   60: goto -15 -> 45
    //   63: astore_2
    //   64: aload_0
    //   65: monitorexit
    //   66: aload_2
    //   67: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	68	0	this	ProgressBarICS
    //   0	68	1	paramBoolean	boolean
    //   63	4	2	localObject	Object
    // Exception table:
    //   from	to	target	type
    //   2	16	63	finally
    //   16	29	63	finally
    //   33	45	63	finally
    //   48	60	63	finally
  }
  
  public void setIndeterminateDrawable(Drawable paramDrawable)
  {
    if (paramDrawable != null) {
      paramDrawable.setCallback(this);
    }
    this.mIndeterminateDrawable = paramDrawable;
    if (this.mIndeterminate)
    {
      this.mCurrentDrawable = paramDrawable;
      postInvalidate();
    }
  }
  
  public void setInterpolator(Context paramContext, int paramInt)
  {
    setInterpolator(AnimationUtils.loadInterpolator(paramContext, paramInt));
  }
  
  public void setInterpolator(Interpolator paramInterpolator)
  {
    this.mInterpolator = paramInterpolator;
  }
  
  public void setMax(int paramInt)
  {
    int i = paramInt;
    if (paramInt < 0) {
      i = 0;
    }
    try
    {
      if (i != this.mMax)
      {
        this.mMax = i;
        postInvalidate();
        if (this.mProgress > i) {
          this.mProgress = i;
        }
        refreshProgress(16908301, this.mProgress, false);
      }
      return;
    }
    finally {}
  }
  
  public void setProgress(int paramInt)
  {
    try
    {
      setProgress(paramInt, false);
      return;
    }
    finally
    {
      localObject = finally;
      throw ((Throwable)localObject);
    }
  }
  
  /* Error */
  void setProgress(int paramInt, boolean paramBoolean)
  {
    // Byte code:
    //   0: aload_0
    //   1: monitorenter
    //   2: aload_0
    //   3: getfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   6: istore 5
    //   8: iload 5
    //   10: ifeq +6 -> 16
    //   13: aload_0
    //   14: monitorexit
    //   15: return
    //   16: iload_1
    //   17: istore 4
    //   19: iload_1
    //   20: ifge +6 -> 26
    //   23: iconst_0
    //   24: istore 4
    //   26: iload 4
    //   28: istore_1
    //   29: iload 4
    //   31: aload_0
    //   32: getfield 102	android/support/v7/internal/widget/ProgressBarICS:mMax	I
    //   35: if_icmple +8 -> 43
    //   38: aload_0
    //   39: getfield 102	android/support/v7/internal/widget/ProgressBarICS:mMax	I
    //   42: istore_1
    //   43: iload_1
    //   44: aload_0
    //   45: getfield 114	android/support/v7/internal/widget/ProgressBarICS:mProgress	I
    //   48: if_icmpeq -35 -> 13
    //   51: aload_0
    //   52: iload_1
    //   53: putfield 114	android/support/v7/internal/widget/ProgressBarICS:mProgress	I
    //   56: aload_0
    //   57: ldc -29
    //   59: aload_0
    //   60: getfield 114	android/support/v7/internal/widget/ProgressBarICS:mProgress	I
    //   63: iload_2
    //   64: invokespecial 537	android/support/v7/internal/widget/ProgressBarICS:refreshProgress	(IIZ)V
    //   67: goto -54 -> 13
    //   70: astore_3
    //   71: aload_0
    //   72: monitorexit
    //   73: aload_3
    //   74: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	75	0	this	ProgressBarICS
    //   0	75	1	paramInt	int
    //   0	75	2	paramBoolean	boolean
    //   70	4	3	localObject	Object
    //   17	19	4	i	int
    //   6	3	5	bool	boolean
    // Exception table:
    //   from	to	target	type
    //   2	8	70	finally
    //   29	43	70	finally
    //   43	67	70	finally
  }
  
  public void setProgressDrawable(Drawable paramDrawable)
  {
    if ((this.mProgressDrawable != null) && (paramDrawable != this.mProgressDrawable)) {
      this.mProgressDrawable.setCallback(null);
    }
    for (int i = 1;; i = 0)
    {
      if (paramDrawable != null)
      {
        paramDrawable.setCallback(this);
        int j = paramDrawable.getMinimumHeight();
        if (this.mMaxHeight < j)
        {
          this.mMaxHeight = j;
          requestLayout();
        }
      }
      this.mProgressDrawable = paramDrawable;
      if (!this.mIndeterminate)
      {
        this.mCurrentDrawable = paramDrawable;
        postInvalidate();
      }
      if (i != 0)
      {
        updateDrawableBounds(getWidth(), getHeight());
        updateDrawableState();
        doRefreshProgress(16908301, this.mProgress, false, false);
        doRefreshProgress(16908303, this.mSecondaryProgress, false, false);
      }
      return;
    }
  }
  
  /* Error */
  public void setSecondaryProgress(int paramInt)
  {
    // Byte code:
    //   0: aload_0
    //   1: monitorenter
    //   2: aload_0
    //   3: getfield 124	android/support/v7/internal/widget/ProgressBarICS:mIndeterminate	Z
    //   6: istore 4
    //   8: iload 4
    //   10: ifeq +6 -> 16
    //   13: aload_0
    //   14: monitorexit
    //   15: return
    //   16: iload_1
    //   17: istore_3
    //   18: iload_1
    //   19: ifge +5 -> 24
    //   22: iconst_0
    //   23: istore_3
    //   24: iload_3
    //   25: istore_1
    //   26: iload_3
    //   27: aload_0
    //   28: getfield 102	android/support/v7/internal/widget/ProgressBarICS:mMax	I
    //   31: if_icmple +8 -> 39
    //   34: aload_0
    //   35: getfield 102	android/support/v7/internal/widget/ProgressBarICS:mMax	I
    //   38: istore_1
    //   39: iload_1
    //   40: aload_0
    //   41: getfield 119	android/support/v7/internal/widget/ProgressBarICS:mSecondaryProgress	I
    //   44: if_icmpeq -31 -> 13
    //   47: aload_0
    //   48: iload_1
    //   49: putfield 119	android/support/v7/internal/widget/ProgressBarICS:mSecondaryProgress	I
    //   52: aload_0
    //   53: ldc -28
    //   55: aload_0
    //   56: getfield 119	android/support/v7/internal/widget/ProgressBarICS:mSecondaryProgress	I
    //   59: iconst_0
    //   60: invokespecial 537	android/support/v7/internal/widget/ProgressBarICS:refreshProgress	(IIZ)V
    //   63: goto -50 -> 13
    //   66: astore_2
    //   67: aload_0
    //   68: monitorexit
    //   69: aload_2
    //   70: athrow
    // Local variable table:
    //   start	length	slot	name	signature
    //   0	71	0	this	ProgressBarICS
    //   0	71	1	paramInt	int
    //   66	4	2	localObject	Object
    //   17	15	3	i	int
    //   6	3	4	bool	boolean
    // Exception table:
    //   from	to	target	type
    //   2	8	66	finally
    //   26	39	66	finally
    //   39	63	66	finally
  }
  
  public void setVisibility(int paramInt)
  {
    if (getVisibility() != paramInt)
    {
      super.setVisibility(paramInt);
      if (this.mIndeterminate)
      {
        if ((paramInt != 8) && (paramInt != 4)) {
          break label36;
        }
        stopAnimation();
      }
    }
    return;
    label36:
    startAnimation();
  }
  
  void startAnimation()
  {
    if (getVisibility() != 0) {
      return;
    }
    if ((this.mIndeterminateDrawable instanceof Animatable))
    {
      this.mShouldStartAnimationDrawable = true;
      this.mAnimation = null;
    }
    for (;;)
    {
      postInvalidate();
      return;
      if (this.mInterpolator == null) {
        this.mInterpolator = new LinearInterpolator();
      }
      this.mTransformation = new Transformation();
      this.mAnimation = new AlphaAnimation(0.0F, 1.0F);
      this.mAnimation.setRepeatMode(this.mBehavior);
      this.mAnimation.setRepeatCount(-1);
      this.mAnimation.setDuration(this.mDuration);
      this.mAnimation.setInterpolator(this.mInterpolator);
      this.mAnimation.setStartTime(-1L);
    }
  }
  
  void stopAnimation()
  {
    this.mAnimation = null;
    this.mTransformation = null;
    if ((this.mIndeterminateDrawable instanceof Animatable))
    {
      ((Animatable)this.mIndeterminateDrawable).stop();
      this.mShouldStartAnimationDrawable = false;
    }
    postInvalidate();
  }
  
  protected boolean verifyDrawable(Drawable paramDrawable)
  {
    return (paramDrawable == this.mProgressDrawable) || (paramDrawable == this.mIndeterminateDrawable) || (super.verifyDrawable(paramDrawable));
  }
  
  private class RefreshProgressRunnable
    implements Runnable
  {
    private boolean mFromUser;
    private int mId;
    private int mProgress;
    
    RefreshProgressRunnable(int paramInt1, int paramInt2, boolean paramBoolean)
    {
      this.mId = paramInt1;
      this.mProgress = paramInt2;
      this.mFromUser = paramBoolean;
    }
    
    public void run()
    {
      ProgressBarICS.this.doRefreshProgress(this.mId, this.mProgress, this.mFromUser, true);
      ProgressBarICS.access$102(ProgressBarICS.this, this);
    }
    
    public void setup(int paramInt1, int paramInt2, boolean paramBoolean)
    {
      this.mId = paramInt1;
      this.mProgress = paramInt2;
      this.mFromUser = paramBoolean;
    }
  }
  
  static class SavedState
    extends View.BaseSavedState
  {
    public static final Parcelable.Creator<SavedState> CREATOR = new Parcelable.Creator()
    {
      public ProgressBarICS.SavedState createFromParcel(Parcel paramAnonymousParcel)
      {
        return new ProgressBarICS.SavedState(paramAnonymousParcel, null);
      }
      
      public ProgressBarICS.SavedState[] newArray(int paramAnonymousInt)
      {
        return new ProgressBarICS.SavedState[paramAnonymousInt];
      }
    };
    int progress;
    int secondaryProgress;
    
    private SavedState(Parcel paramParcel)
    {
      super();
      this.progress = paramParcel.readInt();
      this.secondaryProgress = paramParcel.readInt();
    }
    
    SavedState(Parcelable paramParcelable)
    {
      super();
    }
    
    public void writeToParcel(Parcel paramParcel, int paramInt)
    {
      super.writeToParcel(paramParcel, paramInt);
      paramParcel.writeInt(this.progress);
      paramParcel.writeInt(this.secondaryProgress);
    }
  }
}


/* Location:              E:\Paul\Projects\Android\Agent Recovery\dex2jar-2.0\dex2jar-2.0\classes-dex2jar.jar!\android\support\v7\internal\widget\ProgressBarICS.class
 * Java compiler version: 6 (50.0)
 * JD-Core Version:       0.7.1
 */