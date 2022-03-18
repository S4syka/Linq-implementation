using System;
using System.Linq;

namespace MyLinqProject {

  class Program {
    static void Main(string[] args) {
      //int[] x = { 1, 2, 3 };
      //int[] y = { 4, 5, 6 };

      //var numbers = from a in x
      //              from b in y
      //              select new { a, b };
      //foreach (var n in numbers) {
      //  Console.WriteLine(n);
      //}

      int[] x = { 1, 2, 3, 4, 5 };
      int[] y = { 4, 5, 6, 7, 8 };


      var union = x.Union(y);
      var except = x.Except(y);
      var intersect = x.Intersect(y);
      var concat = x.Concat(y);

      int num1 = x.First();
      int num2 = x.FirstOrDefault();
      int num3 = x.Last();
      int num4 = x.LastOrDefault();
      int num5 = x.Single(x => x > 4);
      int num6 = x.SingleOrDefault(x => x > 4);

      var skip = x.Skip(2);
      var skipWhile = x.SkipWhile(x => x < 3);
      var skipLast = x.SkipLast(2);

      var take = x.Take(3);
      var takeWhile = x.TakeWhile(x => x < 3);
      var takeLast = x.TakeLast(3);

      var distinct = x.Distinct();

      var select = x.Select(x => 3 * x);

      string[] pages = new string[1000];
      int currentPage = 0, totalPages = pages.Length, pageSize = 100;

      while (currentPage <= totalPages / pageSize) {
        var data = pages.Skip(currentPage * pageSize).Take(pageSize);
        currentPage++;
        Console.ReadKey();
      }
    }
  }
}