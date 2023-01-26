using Core.Entities;

namespace TestStorage.Abstractions
{
    public interface ITestStorage
    {
        public TestStorageInfo Save( Test test );
        public Test Load( TestStorageInfo storageInfo );
    }
}
