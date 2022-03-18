using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyLinqProject {
  static class MyLinq {
    public static IEnumerable<TSource> Union<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));

      return new HashSet<TSource>(first.Concat(second));
    }

    public static IEnumerable<TSource> Except<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));

      HashSet<TSource> hashSet = new HashSet<TSource>(second);

      foreach (var item in first) {
        if (!hashSet.Contains(item)) yield return item;
      }
    }

    public static IEnumerable<TSource> Intersect<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));

      HashSet<TSource> hashSet = new HashSet<TSource>(first);

      foreach (var item in second) {
        if (hashSet.Contains(item)) yield return item;
      }
    }

    public static IEnumerable<TSource> Concat<TSource>(this IEnumerable<TSource> first, IEnumerable<TSource> second) {
      if (first == null) throw new ArgumentNullException(nameof(first));
      if (second == null) throw new ArgumentNullException(nameof(second));

      foreach (var item in first) {
        yield return item;
      }
      foreach (var item in second) {
        yield return item;
      }
    }

    public static IEnumerable<TSource> Distinct<TSource>(this IEnumerable<TSource> collection) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));

      return new HashSet<TSource>(collection);
    }

    public static TSource First<TSource>(this IEnumerable<TSource> collection) {
      return collection.First(x => true);
    }
    
    public static TSource First<TSource>(this IEnumerable<TSource> collection, Func<TSource,bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      foreach (var item in collection) {
        if (predicate(item)) return item;
      }

      throw new InvalidOperationException();
    }

    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> collection) {
      return collection.FirstOrDefault(x => true);
    }

    public static TSource FirstOrDefault<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      foreach (var item in collection) {
        if (predicate(item)) return item;
      }

      return default;
    }

    public static TSource Last<TSource>(this IEnumerable<TSource> collection) {
      return collection.Last(x => true);
    }

    public static TSource Last<TSource>(this IEnumerable<TSource> collection, Func<TSource,bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      object returnValue = null;
      bool foundLast = false;

      foreach(var item in collection) {
        if (predicate(item)) {
          foundLast = true;
          returnValue = item;
        }
      }

      if (foundLast) return (TSource)returnValue;
      throw new InvalidOperationException();
    }

    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> collection) {
      return collection.LastOrDefault(x => true);
    }

    public static TSource LastOrDefault<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      object returnValue = null;
      bool foundLast = false;

      foreach (var item in collection) {
        if (predicate(item)) {
          foundLast = true;
          returnValue = item;
        }
      }

      if (foundLast) return (TSource)returnValue;
      return default;
    }

    public static TSource Single<TSource>(this IEnumerable<TSource> collection) {
      return collection.Single(x => true);
    }

    public static TSource Single<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      object returnValue = null;
      bool foundAlready = false;

      foreach (var item in collection) {
        if (predicate(item) && foundAlready) throw new InvalidOperationException();

        if (predicate(item)) {
          foundAlready = true;
          returnValue = item;
        }
      }

      if (foundAlready) return (TSource)returnValue;
      throw new InvalidOperationException();
    }

    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> collection) {
      return collection.SingleOrDefault(x => true);
    }

    public static TSource SingleOrDefault<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      object returnValue = null;
      bool foundAlready = false;

      foreach (var item in collection) {
        if (predicate(item) && foundAlready) throw new InvalidOperationException();

        if (predicate(item)) {
          foundAlready = true;
          returnValue = item;
        }
      }

      if (foundAlready) return (TSource)returnValue;
      return default;
    }

    public static IEnumerable<TSource> Skip<TSource>(this IEnumerable<TSource> collection, int count) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));

      foreach (var item in collection) {
        if (count == 0) yield return item;
        else count--;
      }
    }

    public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      bool foundAlready = false;

      foreach (var item in collection) {
        if (!predicate(item)) foundAlready = true;
        if (foundAlready) yield return item;
      }
    }

    public static IEnumerable<TSource> SkipWhile<TSource>(this IEnumerable<TSource> collection, Func<TSource, int, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      int index = 0;
      bool foundAlready = false;

      foreach (var item in collection) {
        if (!predicate(item,index)) foundAlready = true;
        if (foundAlready) yield return item;
      }
    }

    public static IEnumerable<TSource> SkipLast<TSource>(this IEnumerable<TSource> collection, int count) {
      if (collection == null) throw new ArgumentNullException();

      return ((collection.Reverse()).Skip(count)).Reverse();
    }

    public static IEnumerable<TSource> Take<TSource>(this IEnumerable<TSource> collection, int count) {
      if (collection == null) throw new ArgumentNullException();

      foreach (var item in collection) {
        if (count-- != 0) yield return item;
        else yield break;
      }
    }

    public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      foreach (var item in collection) {
        if (predicate(item)) yield return item;
        else yield break;
      }
    }

    public static IEnumerable<TSource> TakeWhile<TSource>(this IEnumerable<TSource> collection, Func<TSource, int, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      int index = 0;

      foreach (var item in collection) {
        if (predicate(item, index++)) yield return item;
        else yield break;
      }
    }

    public static IEnumerable<TSource> TakeLast<TSource>(this IEnumerable<TSource> collection, int count) {
      if (collection == null) throw new ArgumentNullException();

      return ((collection.Reverse()).Take(count)).Reverse();
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, TResult> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      foreach (var item in collection) {
        yield return predicate(item);
      }
    }

    public static IEnumerable<TResult> Select<TSource, TResult>(this IEnumerable<TSource> collection, Func<TSource, int, TResult> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      int index = 0;
      foreach (var item in collection) {
        yield return predicate(item, index);
        index++;
      }
    }

    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> collection, Func<TSource, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      foreach (var item in collection) {
        if (predicate(item)) yield return item;
      }
    }

    public static IEnumerable<TSource> Where<TSource>(this IEnumerable<TSource> collection, Func<TSource, int, bool> predicate) {
      if (collection == null) throw new ArgumentNullException(nameof(collection));
      if (predicate == null) throw new ArgumentNullException(nameof(predicate));

      int index = 0;
      foreach (var item in collection) {
        if (predicate(item,index)) yield return item;
        index++;
      }
    }

    public static IEnumerable<TSource> Reverse<TSource>(this IEnumerable<TSource> collection) {
      Stack<TSource> stack = new Stack<TSource>();

      foreach (var item in collection) {
        stack.Push(item);
      }

      return stack;
    }
  }
}