using System;
using System.Collections.Generic;
using System.Text;
using CensusAnalyserLive;
using CensusAnalyserLive.POCO;
using CensusAnalyserLive.DTO;
using NUnit.Framework;
using static CensusAnalyserLive.DTO.CensusAnalyzer;

namespace CensusAnalyserTestLive
{
    public class CensusAnalyserTest
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCodeHeaders = "SrNo,State Name,TIN,StateCode";
        // Correct Csv file path
        static string indianStateCensusFilePath = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCensusData.csv";
        static string indianStateCodeFilePath = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCode.csv";
        // Wrong delimiter 
        static string delimiterIndianStateCensusFilePath = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\DelimiterIndiaStateCensusData.csv";
        static string delimiterIndianStateCodeFilePath = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\DelimiterIndiaStateCode.csv";
        // Wrong File Path
        static string wrongIndianStateCensusFilePath = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\WrongPath.csv";
        // Wrong File Type
        static string wrongIndianStateCensusFileType = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCensusData.csv";
        static string wrongIndianStateCodeFileType = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\IndiaStateCode.csv";
        // Wrong Header
        static string wrongHeaderIndianCensusFilePath = @"C:\Users\sajju2002\source\repos\CensusAnalyserDemo\CensusAnalyserTest\CSV Files\WrongIndiaStateCensusData.csv";
        static string wrongHeaderStateCodeFilePath = @"C:\Users\sumit\Desktop\mypro\IndianStateCensusAnalyser\CensusAnalyserTestLive\CSVFiles\WrongIndiaStateCode.csv";

        CensusAnalyzer censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new CensusAnalyzer();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]
        public void Test1()
        {
            Assert.Pass();
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenRead_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(indianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders);
            stateRecord = censusAnalyser.LoadCensusData(indianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders);
            Assert.AreEqual(29, totalRecord.Count);
            Assert.AreEqual(37, stateRecord.Count);
        }

        [Test]
        public void GivenWrongIndianCensusDataFile_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, stateException.eType);
        }

        [Test]
        public void GivenWrongIndianCensusDataFileType_WhenRead_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCensusFileType, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongIndianStateCodeFileType, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(delimiterIndianStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, stateException.eType);
        }

        [Test]
        public void GivenIndianCensusDataFile_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderIndianCensusFilePath, Country.INDIA, indianStateCensusHeaders));
            var stateException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(wrongHeaderStateCodeFilePath, Country.INDIA, indianStateCodeHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, stateException.eType);
        }
    }
}
