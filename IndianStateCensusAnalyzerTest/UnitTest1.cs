using IndianCensusAnalyzer;
using IndianStateCensusAnalyzer;
using IndianStateCensusAnalyzerTest;

namespace IndianStateCensusAnalyzerTest
{
    public class Tests
    {
        public string stateCensusDataFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCensusData.csv";
        public string stateCensusDataNoFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\Files\StateCensus.csv";
        public string stateCensusDataIncorrectFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCensusData.txt";
        public string stateCensusDataHeaderFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCensusDataHeader.csv";
        public string stateCensusDataDelimiterFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCensusDataDelimiter.csv";

        public string stateCodeFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCode.csv";
        public string stateCodeIncorrectFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\Statecode.txt";
        public string stateCodeNoFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianStateCensusAnalyzer\Files\StateCodeData.csv";
        public string stateCodeHeaderFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCodeHeader.csv";
        public string stateCodeDelimiterFilePath = @"D:\gittestrep\IndianStateCensusAnalyzer\IndianCensusAnalyzer\Files\StateCodeDelimniter.csv";


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
        public void GivenStateCensusDataFileHeaderIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyzer.ReadStateCensusData(stateCensusDataHeaderFilePath);
            }
            catch (CensusAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "Header incorrect");
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
        [Test]
        public void GivenStateCensusDataFileDelimiterIncorrect_WhenAnalysed_ShouldReturnException()
        {
            try
            {
                StateCensusAnalyzer.ReadStateCensusData(stateCensusDataDelimiterFilePath);
            }
            catch (CensusAnalyzerException ex)
            {
                Assert.AreEqual(ex.Message, "Delimiter incorrect");
            }
        }
    }
}