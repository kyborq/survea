using Core.Entities;
using System;

namespace TestStorage.Abstractions
{
    public class TestStorageInfo
    {
        public string Name { get; set; }
        public DateTime CreationDate { get; set; }
    
        public TestStorageInfo()
        {
        }

        public TestStorageInfo( string name, DateTime creationDate )
        {
            Name = name;
            CreationDate = creationDate;
        }

        public TestStorageInfo( Test test )
        {
            Name = test.Name;
            CreationDate = test.CreationDate;
        }
    }
}
