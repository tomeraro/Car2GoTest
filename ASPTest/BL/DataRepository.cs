using ASPTest.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTest.BL
{
    public class DataRepository : IData
    {
        public void SaveItems(List<int> Items)
        {
            try
            {
                using (Model context = new Model())
                {
                    var now = DateTime.Now;
                    foreach (var item in Items)
                    {
                        SelectedItems i = new SelectedItems();
                        i.Number = item;
                        i.ShowDate = now;
                        context.SelectedItems.Add(i);
                    }
                    context.SaveChanges();
                }
            }
            catch (Exception exp)
            {
            }
        }

        /// <summary>
        /// Return each  /// Will return each number and the count of times it is in the DB
        /// Gets Date to show from specific date or number
        /// 2,100 - the number 2 appears 100 times. 
        /// </summary>
        /// <param name="Date"></param>
        /// <returns></returns>
        public List<Tuple<int, int>> GetItemsAccroding(DateTime Date)
        {
            Dictionary<int, int> itemsAndCountFromDateDic = new Dictionary<int, int>(); //works with dictionary because its easy to add the numbers with counter is 0 and than convert to List<tuple> 
            List<Tuple<int, int>> itemsAndCountFromDate = new List<Tuple<int, int>>();
            try
            {
                using (Model context = new Model())
                {
                    var list = context.SelectedItems.Where(x=> x.ShowDate >= Date).GroupBy(x => x.Number).Select(p => new { number = p.Key, count = p.Count() }).ToList();
                    foreach (var item in list)
                    {
                        itemsAndCountFromDateDic.Add(item.number, item.count);
                    }

                    for(int i=0; i<100; i++)
                    {
                        if (!itemsAndCountFromDateDic.ContainsKey(i))
                        {
                            itemsAndCountFromDateDic.Add(i, 0);
                        }
                    }

                    foreach (var item in itemsAndCountFromDateDic)
                    {
                        itemsAndCountFromDate.Add(new Tuple<int, int>(item.Key, item.Value));
                    }
                }
            }
            catch (Exception exp) { }

            return itemsAndCountFromDate.OrderByDescending(x => x.Item2).ToList();
        }

        /// <summary>
        /// Will return each number and the count of times it is in the DB
        /// 2,100 - the number 2 appears 100 times.
        /// </summary>
        /// <returns></returns>
        public List<Tuple<int, int>> GetItemsAndCount()
        {
            Dictionary<int, int> itemsAndCountDic = new Dictionary<int, int>(); //works with dictionary because its easy to add the numbers with counter is 0 and than convert to List<tuple> 
            List<Tuple<int, int>> itemsAndCount = new List<Tuple<int, int>>();
            try
            {
                using (Model context = new Model())
                {
                    var list = context.SelectedItems.GroupBy(x => x.Number).Select(p => new { number = p.Key, count = p.Count() }).ToList();
                    foreach(var item in list)
                    {
                        itemsAndCountDic.Add(item.number, item.count);
                    }

                    for (int i = 0; i < 100; i++)
                    {
                        if (!itemsAndCountDic.ContainsKey(i))
                        {
                            itemsAndCountDic.Add(i, 0);
                        }
                    }

                    foreach (var item in itemsAndCountDic)
                    {
                        itemsAndCount.Add(new Tuple<int, int>(item.Key, item.Value));
                    }
                }
            }
            catch (Exception exp){}
            return itemsAndCount.OrderByDescending(x => x.Item2).ToList();
        }
    }

    interface IData
    {
        /// <summary>
        /// Saves Item in DB
        /// </summary>
        /// <param name="Items"></param>
        void SaveItems(List<int> Items);

        List<Tuple<int, int>> GetItemsAccroding(DateTime Date);

        List<Tuple<int, int>> GetItemsAndCount();

    }
}