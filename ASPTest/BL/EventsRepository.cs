using ASPTest.BL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ASPTest
{
    public class EventsRepository : IEvents
    {
        IData _DataRepository = new DataRepository();
        List<int> Items = new List<int>();
        Random _rand = new Random();
        Dictionary<int, int> ItemsDictionary = new Dictionary<int, int>();

        public EventsRepository()
        {
            for (int i = 0; i < 100; i++)
            {
                Items.Add(_rand.Next(0, 100));
            }
            _DataRepository.SaveItems(Items);

            //initialize new dictionary based on Items array. 
            //each Key represent index on items array. each value represent the NextPosition index.
            //-1 indicates error: 1. array not contains next position for event number. 2. NextPosition function asks for wrong position.
            //example >> arr = [1,2,3,1,1] >> dic[0] = 3, dic[1] = -1 
            bool findNextPosition = false;
            for (int i = 0; i < Items.Count; i++)
            {
                for (int j = i + 1; j < Items.Count; j++)
                {
                    if (Items[i] == Items[j])
                    {
                        ItemsDictionary[i] = j;
                        findNextPosition = true;
                        break;
                    }
                }
                if (!findNextPosition)
                    ItemsDictionary[i] = -1;
                findNextPosition = false;
            }

            //save the original dictionary in session because items list changing in each call  
            if (HttpContext.Current.Session["ItemsDictionary"] == null)
                HttpContext.Current.Session["ItemsDictionary"] = ItemsDictionary;
        }

        public int Next(int Postion)
        {
            //check wrong position
            var sessionDictionary = ((Dictionary<int, int>)HttpContext.Current.Session["ItemsDictionary"]);
            if (!sessionDictionary.ContainsKey(Postion))
                return -1;

            //return the next position in O(1) from dictionary
            return ((Dictionary<int, int>)HttpContext.Current.Session["ItemsDictionary"])[Postion];
        }

        public List<int> GetAllItems()
        {
            return Items;
        }
    }

    interface IEvents
    {
        int Next(int Postion);
        List<int> GetAllItems();

    }

    

}