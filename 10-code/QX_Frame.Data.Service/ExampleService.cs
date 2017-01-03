using QX_Frame.Data.Contract;
using System;
using System.Collections.Generic;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
    public class ExampleService :IExampleService
    {
        private Example _example;

        public ExampleService(Example example)
        {
            this._example = example;
        }

        public bool Add() => true;

        public bool Delete() => true;

        public Example QuerySingle(Guid uid) => new Example { uid = uid, intValue = _example.intValue, stringValue = _example.stringValue };

        public List<Example> QueryAll()
            =>
            new List<Example> {
                new Example { uid = Guid.NewGuid(), intValue = 1, stringValue = "this is a string value 1" },
                new Example { uid = Guid.NewGuid(), intValue = 2, stringValue = "this is a string value 2" },
                new Example { uid = Guid.NewGuid(), intValue = 3, stringValue = "this is a string value 3" },
                new Example { uid = Guid.NewGuid(), intValue = 4, stringValue = "this is a string value 4" },
                new Example { uid = Guid.NewGuid(), intValue = 5, stringValue = "this is a string value 5" }
            };

        public bool Update() => true;
    }
}
