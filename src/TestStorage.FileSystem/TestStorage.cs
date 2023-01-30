using Core.Entities;
using DatabaseStorage.Abstractions.Repositories;
using System.IO;
using System.Text.Json;
using TestStorage.Abstractions;
using TestStorage.FileSystem.Entities;
using TestStorage.FileSystem.Mappings;

namespace TestStorage.FileSystem
{
    public class TestStorage : ITestStorage
    {
        private const string SavingDirectory = "./tests/";

        public void LoadQuestions( Test test )
        {
            string creationDate = test.CreationDate.ToString().Replace( '.', '-' ).Replace( ' ', '-' ).Replace( ':', '-' );
            string path = $"{SavingDirectory}{creationDate}/{test.Name}.json";
            string json = string.Empty;
            using ( StreamReader reader = new StreamReader( path ) )
            {
                json = reader.ReadToEnd();
            }
            StoredTest storedTest = JsonSerializer.Deserialize<StoredTest>( json );
            test.ImportLoadedQuestions( storedTest );
        }

        public void Save( Test test )
        {
            string path = SavingDirectory;
            string creationDate = test.CreationDate.ToString().Replace( '.', '-' ).Replace( ' ', '-' ).Replace( ':', '-');
            path += $"{creationDate}/";
            if ( !Directory.Exists( path ) )
            {
                Directory.CreateDirectory( path );
            }
            StoredTest storedTest = test.ToStoredTest();
            string json = JsonSerializer.Serialize<StoredTest>( storedTest );
            using ( StreamWriter writer = new StreamWriter( $"{path}{storedTest.Name}.json" ) )
            {
                writer.Write( json );
            }
        }
    }
}
