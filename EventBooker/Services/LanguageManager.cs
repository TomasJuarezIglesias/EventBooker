﻿using Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class LanguageManager : IPublisher
    {
        private readonly List<IObserver> _observers;

        public LanguageManager()
        {
            _observers = new List<IObserver>();
        }

        public void NotifyAll(object obj)
        {
            foreach (var observer in _observers) 
            {
                observer.Notify(obj);
            }
        }

        public void AddObserver(IObserver observer)
        {
            _observers.Add(observer);
        }

        public void RemoveAllObservers()
        {
            _observers.Clear();
        }
    }
}
