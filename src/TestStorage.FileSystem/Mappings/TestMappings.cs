using Core.Entities;
using System;
using TestStorage.FileSystem.Entities;

namespace TestStorage.FileSystem.Mappings
{
    public static class TestMappings
    {
        public static StoredTest ToStoredTest( this Test test )
        {
            return new StoredTest
            {
                TestId = test.TestId,
                Name = test.Name,
                Questions = test.Questions
            };
        }

        public static void ImportLoadedQuestions( this Test test, StoredTest loadedTest )
        {
            if ( test.TestId != loadedTest.TestId || !test.Name.Equals( loadedTest.Name ) )
            {
                throw new Exception( "Tests are different" );
            }
            test.Questions = loadedTest.Questions;
        }
    }
}
