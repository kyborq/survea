using Core.Entities;

namespace TestStorage.Abstractions
{
    public interface ITestStorage
    {
        public void Save( Test test );
        public void LoadQuestions( Test test );
    }
}
