using CsvHelper;
using IndianCensusAnalyzer;
using System.Globalization;

namespace IndianStateCensusAnalyzer
{
    public class StateCensusAnalyzer
    {
        public static int ReadStateCensusData(string filepath)
        {
            if (!File.Exists(filepath))
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.FILE_NOT_EXISTS,
                    "File not exists");
            }
            if (!Path.GetExtension(filepath).Equals(".csv"))
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.FILE_INCORRECT,
                    "File extension incorrect");
            }
            if (!File.ReadAllLines(filepath)[0].Equals("State,Population,AreaInSqKm,DensityPerSqKm"))
            {
                throw new CensusAnalyzerException(CensusAnalyzerException.ExceptionType.HEADER_INCORRECT,
                    "Header incorrect");
            }
            using (var reader = new StreamReader(filepath))
            {
                using (var csv = new CsvReader(reader, CultureInfo.InvariantCulture))
                {
                    var records = csv.GetRecords<StateCensusData>().ToList();
                    Console.WriteLine("Read Data from CSV");
                    foreach (var data in records)
                    {
                        Console.WriteLine(data.State + "---" + data.Population + "---" +
                            data.AreaInSqKm + "---" + data.DensityPerSqKm);
                    }
                    return records.Count() - 1;
                }
            }
        }
    }
}