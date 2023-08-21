using IndianCensusAnalyzer;
using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzerTest;

namespace IndianStateCensusAnalyzerTest
{
    public class Tests
    {
        public string stateCensusDataFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCensusData.csv";
        [Test]
        public void GivenStateCensusData_WhenAnalysed_RecordsShouldBeMatched()
        {
            Assert.AreEqual(StateCensusAnalyzer.ReadStateCensusData(stateCensusDataFilePath), CSVStateCensus.ReadStateCensusData(stateCensusDataFilePath));
        }

        [Test]
        public void GivenStateCensusDataFileIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyzer.ReadStateCensusData(stateCensusDataFilePath);
            }
            catch(CensusAnalyzerException e)
            {
                Assert.AreEqual(e.Message, "File extension incorrect");
            }
        }
        [Test]
        public void GivenStateCensusDataFileNotExists_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyzer.ReadStateCensusData(stateCensusDataFilePath);
            }
            catch(CensusAnalyzerException e)
            {
                Assert.AreEqual(e.Message, "File does not exists");
            }
        }
    }
}