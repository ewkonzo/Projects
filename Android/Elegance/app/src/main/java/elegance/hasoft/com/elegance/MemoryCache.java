package elegance.hasoft.com.elegance;

import android.graphics.Bitmap;

import java.lang.ref.SoftReference;
import java.util.Collections;
import java.util.HashMap;
import java.util.Map;

/**
 * Created by Erick Genius on 7/2/2014.
 */
public class MemoryCache {
    private Map<String,SoftReference<Bitmap>> cache = Collections.synchronizedMap(new HashMap<String, SoftReference<Bitmap>>());
    public Bitmap get(String id){
        if(!cache.containsKey(id))
            return null;
        SoftReference<Bitmap> ref = cache.get(id);
        return ref.get();
    }
    public void put(String id,Bitmap bitmap){
        cache.put(id,new SoftReference<Bitmap>(bitmap));
    }
    public void clear(){
        cache.clear();
    }
}