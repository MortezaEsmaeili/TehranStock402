
using System;
using System.Linq;
using DocumentFormat.OpenXml;
using DocumentFormat.OpenXml.Packaging;
using DocumentFormat.OpenXml.Spreadsheet;
using DocumentFormat.OpenXml.Wordprocessing;

namespace MSHB.TsetmcReader.Service.Helper
{
    public static class ExelReader
    {
        public static string[][] ReadExcelFileDOM(string fileName)//DOM(Document Object Model) approach, all document in memory
        {
            string[][] excelTable = null;
            try
            {
                using (SpreadsheetDocument spreadsheetDocument =
                    SpreadsheetDocument.Open(fileName, false))
                {
                    WorkbookPart workbookPart = spreadsheetDocument.WorkbookPart;
                    SharedStringTablePart sstpart = workbookPart.GetPartsOfType<SharedStringTablePart>().First();
                    SharedStringTable sst = sstpart.SharedStringTable;


                    WorksheetPart worksheetPart = workbookPart.WorksheetParts.First();
                    SheetData sheetData = worksheetPart.Worksheet.Elements<SheetData>().First();
                    int rows = sheetData.Elements<Row>().Count();
                    excelTable = new string[rows][];
                    int row = 0;
                    foreach (Row r in sheetData.Elements<Row>())
                    {
                        excelTable[row] = new string[r.Elements<Cell>().Count()];

                        int col = 0;
                        foreach (Cell cell in r.Elements<Cell>())
                        {
                            if ((cell.DataType != null) && (cell.DataType == CellValues.SharedString))
                            {
                                int ssid = int.Parse(cell.CellValue.Text);
                                string str = sst.ChildElements[ssid].InnerText;
                                excelTable[row][col] = str;
                            }
                            else if (cell.CellValue != null)
                            {
                                excelTable[row][col] = cell.CellValue.Text;
                            }
                            col++;
                        }
                        row++;
                    }


                }
            }
            catch (Exception ex) { ex.ToString(); }
            return excelTable;
        }

    }
}
