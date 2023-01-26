using Core.Entities;
using System;
using TestStorage.Abstractions;

namespace TestStorage.FileSystem
{
    public class TestStorage : ITestStorage
    {
        public Test Load( TestStorageInfo storageInfo )
        {
            throw new NotImplementedException();
        }

        public TestStorageInfo Save( Test test )
        {
            throw new NotImplementedException();
        }
    }
}
