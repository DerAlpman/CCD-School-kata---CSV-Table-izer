using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace CSVTableizer
{
    internal static class Tablerizer
    {
        internal static IEnumerable<string> TablerizedCSVData(string[] csvData)
        {
            int[] columnsWidths = Tablerizer.GetColumnsWidths(csvData);
#
            string headerUnderLine = BuildHeaderUnderline(columnsWidths);

            var tablerizedCSVData = TablerizedRows(csvData, columnsWidths).ToArray();

            for (int row = 0; row < csvData.Length; row++)
            {
                yield return tablerizedCSVData[row];
                if (row == 0)
                {
                    yield return headerUnderLine;
                }
            }
        }

        private static IEnumerable<string> TablerizedRows(string[] csvData, int[] columnsWidths)
        {

            for (int row = 0; row < csvData.Length; row++)
            {
                var columns = csvData[row].Split(';');

                StringBuilder rowString = new StringBuilder();
                for (int column = 0; column < columns.Length; column++)
                {
                    rowString.Append(columns[column].PadRight(columnsWidths[column]) + '|');
                }
                yield return rowString.ToString();
            }
        }

        private static string BuildHeaderUnderline(int[] columnsWidths)
        {
            StringBuilder headerUnderLine = new StringBuilder();
            foreach (var columnWidth in columnsWidths)
            {
                headerUnderLine.Append(new string('-', columnWidth) + '+');
            }

            return headerUnderLine.ToString();
        }

        private static int[] GetColumnsWidths(string[] csvData)
        {
            int columnCount = csvData[0].Split(';').Count();

            int[] columnsWidths = new int[columnCount];

            for (int row = 0; row < csvData.Length; row++)
            {
                var columns = csvData[row].Split(';');

                for (int column = 0; column < columns.Length; column++)
                {
                    columnsWidths[column] = Math.Max(columnsWidths[column], columns[column].Length);
                }
            }

            return columnsWidths;
        }
    }
}
