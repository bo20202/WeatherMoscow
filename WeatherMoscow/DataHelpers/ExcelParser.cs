using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using NPOI.XSSF.UserModel;
using WeatherMoscow.Models;
using System.IO;
using NPOI.SS.UserModel;
namespace WeatherMoscow.DataHelpers
{
    public class ExcelParser
    {
        private enum _dataColumns { Date, Time, Temperature, Moisture, DewPoint, Pressure, WindDir, WindSpeed, Cloudness, CloudBase, HorizontalVisibility, WeatherConds };

        public IEnumerable<Weather> ParseFile(Stream fileStream)
        {
            var weathers = new List<Weather>();
            try
            {
                XSSFWorkbook workbook = new XSSFWorkbook(fileStream);

                var tasks = new Task<IEnumerable<Weather>>[workbook.Count];
                for (int i = 0; i < workbook.Count; i++)
                {
                    ISheet sheet = workbook.GetSheetAt(i);
                    tasks[i] = Task<IEnumerable<Weather>>.Factory.StartNew(() => ParseRows(sheet));
                }
                Task.WaitAll(tasks);
                foreach (var task in tasks)
                {
                    weathers.AddRange(task.Result);
                }
                return weathers;
            }
            catch
            {
                return weathers;
            }
        }

        private IEnumerable<Weather> ParseRows(ISheet sheet)
        {
            var weathers = new List<Weather>();
            for(int i = 4; i < sheet.LastRowNum; i++) //first 4 rows are filled with technical info
            {
                try
                {
                    Weather weather = new Weather();
                    IRow row = sheet.GetRow(i);
                    weather.Date = DateTime.Parse(GetStringCellData(row, _dataColumns.Date));
                    weather.Time = TimeSpan.Parse(GetStringCellData(row, _dataColumns.Time));

                    weather.AirTemp = GetNumericCellData(row, _dataColumns.Temperature);
                    weather.Moisture = GetNumericCellData(row, _dataColumns.Moisture);
                    weather.DewPoint = GetNumericCellData(row, _dataColumns.DewPoint);
                    weather.Pressure = (int?)GetNumericCellData(row, _dataColumns.Pressure);

                    weather.WindDir = GetStringCellData(row, _dataColumns.WindDir);
                    weather.WindSpeed = (int?)GetNumericCellData(row, _dataColumns.WindSpeed);

                    weather.Cloudness = (int?)GetNumericCellData(row, _dataColumns.Cloudness);
                    weather.CloudBase = (int?)GetNumericCellData(row, _dataColumns.CloudBase);
                    weather.HorizontalVisibility = (int?)GetNumericCellData(row, _dataColumns.HorizontalVisibility);
                    weather.WeatherConditions = GetStringCellData(row, _dataColumns.WeatherConds);

                    weathers.Add(weather);
                }
                catch
                {
                    continue;
                }
            }
            return weathers;
        }

        private string GetStringCellData(IRow row, _dataColumns column)
        {
            try
            {
                return row.GetCell((int)column).StringCellValue;
            }
            catch
            {
                return null;
            }
        }

        private double? GetNumericCellData(IRow row, _dataColumns column)
        {
            try
            {
                return row.GetCell((int)column).NumericCellValue;
            }
            catch
            {
                return null;
            }
        }
       
    }
}
