﻿using CensusAnalyserLive.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace CensusAnalyserLive.DTO
{
    public class CensusAnalyzer
    {
        public enum Country
        {
            INDIA,
        }

        Dictionary<string, CensusDTO> dataMap;

        public Dictionary<string, CensusDTO> LoadCensusData(Country country, string csvFilePath, string dataHeaders)
        {
            dataMap = new CSVAdapterFactory().LoadCsvData(country, csvFilePath, dataHeaders);
            return dataMap;
        }
    }

}

