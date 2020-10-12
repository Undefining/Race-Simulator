﻿using System;
using System.Collections.Generic;
using System.Text;

namespace Model
{
    public class ParticipantLapTime : IStorageConstraint
    {
        public string Name { get; set; }
        public int Lap { get; set; }
        public TimeSpan Time { get; set; }
        public void Add<T>(List<T> list) where T : class, IStorageConstraint
        {
            list.Add(this as T);
        }
    }
}
