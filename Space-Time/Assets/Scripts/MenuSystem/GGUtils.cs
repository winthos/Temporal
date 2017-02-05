using System;
using UnityEngine;
using System.Collections;
using Object = UnityEngine.Object;

public enum Side
{
    Up,
    Left,
    Right,
    Down
}

public enum Quadrant
{
    UpperLeft,
    UpperRight,
    LowerLeft,
    LowerRight,
}

public static class GGUtils
{
  // Fill an array with a value
  public static void Populate<T>(this T[] arr, T val)
  {
    for (int i = 0; i < arr.Length; i++)
    {
      arr[i] = val;
    }
  }

  // Turn a 1D array into a 2D array
  public static T[,] Make2D<T>(T[] input, int height, int width)
  {
    T[,] output = new T[height, width];
    for (int i = 0; i < height; i++)
    {
      for (int j = 0; j < width; j++)
      {
        output[i, j] = input[i*width + j];
      }
    }
    return output;
  }

  public static bool SetInstance<T>(ref T target, T instance) where T : MonoBehaviour
  {
    if (Object.ReferenceEquals(target, null))
    {
      target = instance;
      return true;
    }
    else if (!Object.ReferenceEquals(target, instance))
    {
      Object.Destroy(instance.gameObject);
      return false;
    }
    return false;
  }
}

public class SingletonBehavior<T> : MonoBehaviour where T : MonoBehaviour
{
  public static T Instance;

  protected virtual void Awake()
  {
    GGUtils.SetInstance(ref Instance, this as T);
  }
}

public class Pair<X, Y>
{
  public Pair()
  {
  }

  public Pair(X first, Y second)
  {
    this.First = first;
    this.Second = second;
  }

  public X First { get; set; }
  public Y Second { get; set; }
};

public class Ref<T>
{
  private readonly Func<T> getter;
  private readonly Action<T> setter;

  public Ref(Func<T> getter, Action<T> setter)
  {
    this.getter = getter;
    this.setter = setter;
  }

  public T Value
  {
    get { return getter(); }
    set { setter(value); }
  }
}