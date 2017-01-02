using QX_Frame.Data.Contract;
using System;
using System.Collections.Generic;
using QX_Frame.Data.Entities;

namespace QX_Frame.Data.Service
{
    public class ExampleService :IExampleService
    {
        private IExampleService _exampleService;
        private example _example;

        public ExampleService(IExampleService exampleService, example example)
        {
            this._exampleService = exampleService;
            this._example = example;
        }

        public bool Add() => true;

        public bool Delete() => true;

        public example QuerySingle(Guid uid) => new example { uid = uid, intValue = _example.intValue, stringValue = _example.stringValue };

        public List<example> QueryAll()
            =>
            new List<example> {
                new example { uid = Guid.NewGuid(), intValue = 1, stringValue = "this is a string value 1" },
                new example { uid = Guid.NewGuid(), intValue = 2, stringValue = "this is a string value 2" },
                new example { uid = Guid.NewGuid(), intValue = 3, stringValue = "this is a string value 3" },
                new example { uid = Guid.NewGuid(), intValue = 4, stringValue = "this is a string value 4" },
                new example { uid = Guid.NewGuid(), intValue = 5, stringValue = "this is a string value 5" }
            };

        public bool Update() => true;
    }
}
