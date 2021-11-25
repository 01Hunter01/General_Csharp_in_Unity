using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace HomeWork7
{
    public sealed class ExamplesHomeWork7 : MonoBehaviour
    {
        private string _word;
        private int _value;

        private List<int> integers;

        //delegate int DictDelegate();

        //private DictDelegate dict;

        private void Start()
        {

            #region Task_2

            _word = "kulebyaka";

            _value = _word.CharCount();

            Debug.Log(_value);

            #endregion

            #region Task_3a

            Debug.Log("===============");
            Debug.Log("Task_3a");
            Debug.Log("===============");

            integers = new List<int>{ 1, 2, 3, 4, 5, 5, 3, 4, 2, 2, 1, 1};

            ElementCount(integers);



            //ElementCount(integers);

            #endregion

            #region Task_3b

            //Debug.Log("===============");
            //Debug.Log("Task_3b");
            //Debug.Log("===============");

            #endregion

            #region Task_3c

            Debug.Log("===============");
            Debug.Log("Task_3c");
            Debug.Log("===============");

            ElementCountLinq(integers);

            #endregion

            #region Task_4A

            Dictionary<string, int> dict = new Dictionary<string, int>()
            {
                {"four",4 },
                {"two",2 },
                { "one",1 },
                {"three",3 },
             };

            var d = dict.OrderBy(pair => pair.Value);

            foreach (var pair in d)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            #endregion

            #region Task_4B


            Dictionary<string, int> dict4b = new Dictionary<string, int>()
            {
                {"five",5 },
                {"seven",7 },
                { "six",6 },
                {"eight",8 },
             };

            var d4b = dict4b.OrderBy(delegate (KeyValuePair<string, int> pair) {return pair.Value;});


            foreach (var pair in d4b)
            {
                Debug.Log($"{pair.Key} - {pair.Value}");
            }

            #endregion
        }


        private void ElementCount(List<int> collection)
        {
            int counter = 0;

            for(int i = 1; i < collection.Count; i++)
            {
                if(collection[i] != collection[i-1])
                {
                    for (int j = 0; j < collection.Count; j++)
                    {
                        if (collection[i] == collection[j])
                        {
                            counter++;
                        }
                    }

                    Debug.Log($"Елемент коллекции {collection[i]} встречается {counter} раз(а).");
                    counter = 0;
                }
            }
        }

        private void ElementCountLinq(List<int> coll)
        {
            foreach (int val in coll.Distinct())
            {
                Debug.Log($"Элемент коллекци {val} - встречается {coll.Where(x => x == val).Count()} раз(а)");
            }
        }

        //private int ExampleSort()
        //{
        //    KeyValuePair<string, int> pair;
        //    return pair.Value;
        //}

    }
}
