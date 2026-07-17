using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;
using System.Xml;
using ClosedXML.Excel;

namespace Excel_to_Msgxml
{
    public partial class Form1 : Form
    {
        // 使用者選擇的 Excel 完整路徑
        private string excelPath = "";
        public Form1()
        {
            InitializeComponent();
            columnTextBox.Text = "1";
            rowTextBox.Text = "1";
        }
        /// <summary>
        /// 選擇 Excel
        /// </summary>
        private void open_file(object sender, EventArgs e)
        {
            using (OpenFileDialog dialog = new OpenFileDialog())
            {
                dialog.Title = "請選擇 Excel";
                dialog.Filter =
                    "Excel 檔案 (*.xlsx)|*.xlsx|所有檔案 (*.*)|*.*";

                if (dialog.ShowDialog() == DialogResult.OK)
                {
                    excelPath = dialog.FileName;

                    MessageBox.Show(
                        "已選擇：\n" + excelPath,
                        "完成",
                        MessageBoxButtons.OK,
                        MessageBoxIcon.Information);
                }
            }
        }
        /// <summary>
        /// 執行 Excel → MSGXML
        /// </summary>
        private void execute(object sender, EventArgs e)
        {
            // 檢查 Excel 是否已選擇
            if (string.IsNullOrWhiteSpace(excelPath))
            {
                MessageBox.Show(
                    "請先選擇 Excel！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 檢查 Excel 是否存在
            if (!File.Exists(excelPath))
            {
                MessageBox.Show(
                    "找不到選擇的 Excel：\n" + excelPath,
                    "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }

            // 檢查輸出檔名
            if (string.IsNullOrWhiteSpace(file_name.Text))
            {
                MessageBox.Show(
                    "請輸入輸出檔名！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            string baseFileName = file_name.Text.Trim();

            // 若使用者誤輸入 .msgxml，先移除副檔名
            if (baseFileName.EndsWith(
                    ".msgxml",
                    StringComparison.OrdinalIgnoreCase))
            {
                baseFileName = baseFileName.Substring(
                    0,
                    baseFileName.Length - ".msgxml".Length);
            }

            // 檢查移除副檔名後是否為空
            if (string.IsNullOrWhiteSpace(baseFileName))
            {
                MessageBox.Show(
                    "請輸入有效的輸出檔名！",
                    "提示",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            // 避免輸入不能作為檔名的字元
            if (baseFileName.IndexOfAny(
                    Path.GetInvalidFileNameChars()) >= 0)
            {
                MessageBox.Show(
                    "輸出檔名包含無效字元：\n" +
                    string.Join(
                        " ",
                        Path.GetInvalidFileNameChars()),
                    "檔名錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

            /*
             * 範本路徑
             *
             * comment_example.msgxml
             * symbol_example.msgxml
             *
             * 都必須放在 exe 旁邊
             */
            string contentTemplatePath = Path.Combine(
                Application.StartupPath,
                "empty.msgxml");


            // 檢查 Comment 範本
            if (!File.Exists(contentTemplatePath))
            {
                MessageBox.Show(
                    "找不到 Comment MSGXML 範本：\n\n" +
                    contentTemplatePath +
                    "\n\n請將 comment_example.msgxml " +
                    "放在程式執行檔旁邊。",
                    "缺少範本",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);

                return;
            }
            /*
             * 輸出檔名：
             *
             * 使用者輸入：
             * KRV_ALARM_
             *
             * 輸出：
             * KRV_ALARM_comment.msgxml
             * KRV_ALARM_symbol.msgxml
             */
            string descriptionOutputName =
                baseFileName + "_description.msgxml";
            // 輸出到 exe 同一個資料夾
            string commentOutputPath = Path.Combine(
                Application.StartupPath,
                descriptionOutputName);
            // 避免 Comment 範本和輸出是同一個檔案
            if (IsSamePath(
                    contentTemplatePath,
                    commentOutputPath))
            {
                MessageBox.Show(
                    "Comment 輸出檔名不能和範本相同。\n\n" +
                    "請輸入其他檔名。",
                    "檔名重複",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Warning);

                return;
            }

  

            // 檢查輸出檔案是否已存在
            List<string> existingFiles = new List<string>();

            if (File.Exists(commentOutputPath))
            {
                existingFiles.Add(commentOutputPath);
            }

            // 只詢問一次是否覆蓋
            if (existingFiles.Count > 0)
            {
                string existingFileText =
                    string.Join("\n\n", existingFiles);

                DialogResult answer = MessageBox.Show(
                    "以下輸出檔案已存在：\n\n" +
                    existingFileText +
                    "\n\n是否覆蓋？",
                    "確認覆蓋",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (answer != DialogResult.Yes)
                {
                    return;
                }
            }

            try
            {
                /*
                 * 產生 Comment MSGXML
                 *
                 * 使用 Excel 第 3 欄 Comment
                 */
                ConversionResult commentResult =
                    ConvertExcelToMsgXml(
                        excelPath,
                        contentTemplatePath,
                        commentOutputPath
                      );
                MessageBox.Show(
                "轉換完成！\n\n" +

                "【轉換內容】\n" +
                "繁體中文：" +
                commentResult.ChineseCount + " 筆\n" +
                "英文：" +
                commentResult.EnglishCount + " 筆\n" +
                "簡體中文：" +
                commentResult.SimplifiedChineseCount +
                " 筆\n\n",

                "轉換成功",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "轉換失敗：\n\n" + ex.Message,
                    "錯誤",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }
        /// <summary>
        /// 執行完整轉換
        /// </summary>
        private ConversionResult ConvertExcelToMsgXml(
        string sourceExcelPath,
        string templateMsgXmlPath,
        string outputMsgXmlPath)
        {
            ConversionResult result = new ConversionResult();

            using (XLWorkbook workbook =
                   new XLWorkbook(sourceExcelPath))
            {
                XDocument document = XDocument.Load(
                    templateMsgXmlPath,
                    System.Xml.Linq.LoadOptions.PreserveWhitespace);
                    /*
                     * Comment 是多語言格式
                     */
                        IXLWorksheet traditionalChineseExcelSheet = workbook.Worksheet(1);

                    IXLWorksheet englishExcelSheet =
                        FindEnglishWorksheet(workbook);

                    IXLWorksheet simplifiedChineseExcelSheet =
                        FindSimplifiedChineseWorksheet(workbook);

                    result.ChineseCount =
                        UpdateLanguageSheet(
                            traditionalChineseExcelSheet,
                            document,
                            "Chinese");

                    result.EnglishCount =
                        UpdateLanguageSheet(
                            englishExcelSheet,
                            document,
                            "English");

                    result.SimplifiedChineseCount =
                        UpdateLanguageSheet(
                            simplifiedChineseExcelSheet,
                            document,
                            "SimplifiedChinese");
        

                SaveAsUtf16(document, outputMsgXmlPath);
            }
            return result;
        }

        /// <summary>
        /// 將 Excel 指定欄位的非空白內容，
        /// 依序寫入 MSGXML 的 Row Count="1"、"2"、"3"...
        /// Excel 空白儲存格不占用 XML Row。
        /// </summary>
        private int UpdateLanguageSheet(
            IXLWorksheet excelSheet,
            XDocument document,
            string xmlSheetName)
        {
            // 1. 找到 MSGXML 中對應的語言 Sheet
            XElement xmlSheet = document
                .Descendants()
                .FirstOrDefault(element =>
                {
                    if (element.Name.LocalName != "Sheet")
                    {
                        return false;
                    }

                    string actualSheetName =
                        GetAttributeValue(element, "name");
                    return string.Equals(
                        actualSheetName,
                        xmlSheetName,
                        StringComparison.OrdinalIgnoreCase);
                });

            if (xmlSheet == null)
            {
                throw new InvalidOperationException(
                    "MSGXML 找不到語言表：" +
                    xmlSheetName);
            }

            // 2. 取得所有 Count >= 1 的 Row，
            //    並依照 Count 從小到大排序
            List<XElement> xmlRows = xmlSheet
                .Elements()
                .Where(element =>
                    element.Name.LocalName == "Row")
                .Select(element => new
                {
                    Row = element,
                    CountText = GetAttributeValue(
                        element,
                        "Count")
                })
                .Where(item =>
                    int.TryParse(
                        item.CountText,
                        out int count) &&
                    count >= 1)
                .OrderBy(item =>
                    int.Parse(item.CountText))
                .Select(item => item.Row)
                .ToList();

            if (xmlRows.Count == 0)
            {
                throw new InvalidOperationException(
                    "MSGXML 的語言表「" +
                    xmlSheetName +
                    "」找不到 Count 大於等於 1 的 Row。");
            }

            // 3. 取得 Excel 最後一列
            IXLRow lastRow = excelSheet.LastRowUsed();

            if (lastRow == null)
            {
                throw new InvalidOperationException(
                    "Excel 工作表「" +
                    excelSheet.Name +
                    "」沒有資料。");
            }

            int lastRowNumber = lastRow.RowNumber();

            // 4. 檢查使用者輸入的欄號
            if (!int.TryParse(
                    columnTextBox.Text.Trim(),
                    out int column) ||
                column < 1)
            {
                throw new InvalidOperationException(
                    "欄位必須輸入大於 0 的整數。\n\n" +
                    "例如：A 欄輸入 1、B 欄輸入 2。");
            }

            // 5. 檢查使用者輸入的起始列
            if (!int.TryParse(
                    rowTextBox.Text.Trim(),
                    out int rowStart) ||
                rowStart < 1)
            {
                throw new InvalidOperationException(
                    "起始列必須輸入大於 0 的整數。");
            }

            int updateCount = 0;

            // 指向目前要寫入的 XML Row
            int xmlRowIndex = 0;

            // 6. 從使用者指定的 Excel 列開始讀取
            for (int rowNumber = rowStart;
                 rowNumber <= lastRowNumber;
                 rowNumber++)
            {
                string content = excelSheet
                    .Cell(rowNumber, column)
                    .GetString()
                    .Trim();

                // Excel 空白直接跳過
                // 不增加 xmlRowIndex，所以 XML Row 仍然連續
                if (string.IsNullOrWhiteSpace(content))
                {
                    continue;
                }

                // Excel 有效資料超過 XML 可用 Row 數量
                if (xmlRowIndex >= xmlRows.Count)
                {
                    throw new InvalidOperationException(
                        "Excel 的有效資料筆數超過 MSGXML 可用的 Row 數量。\n\n" +
                        "Excel 工作表：" +
                        excelSheet.Name + "\n" +
                        "目前 Excel 列號：" +
                        rowNumber + "\n" +
                        "已寫入筆數：" +
                        updateCount + "\n" +
                        "XML 可用 Row 數：" +
                        xmlRows.Count);
                }

                XElement xmlRow = xmlRows[xmlRowIndex];

                XElement messageElement = xmlRow
                    .Elements()
                    .FirstOrDefault(element =>
                        element.Name.LocalName == "Message");

                if (messageElement == null)
                {
                    string rowCount =
                        GetAttributeValue(
                            xmlRow,
                            "Count");

                    throw new InvalidOperationException(
                        "MSGXML 的 Row Count=\"" +
                        rowCount +
                        "\" 缺少 <Message> 節點。");
                }

                string convertedText =
                    ConvertExcelLineBreaksToMsgXml(
                        content);

                // 只修改 Message，不破壞 Row 內的其他節點
                messageElement.Value = convertedText;

                updateCount++;

                // 只有成功寫入後，才移到下一個 XML Row
                xmlRowIndex++;
            }

            return updateCount;
        }



        /// <summary>
        /// 將 Excel 的實際換行轉成 MSGXML 使用的字面 \n
        /// </summary>
        private string ConvertExcelLineBreaksToMsgXml(
            string text)
        {
            if (text == null)
            {
                return "";
            }

            // 統一所有換行格式
            string normalized = text
                .Replace("\r\n", "\n")
                .Replace("\r", "\n");

            /*
             * "\n" 代表實際換行。
             * "\\n" 代表反斜線加英文字母 n。
             */
            return normalized.Replace(
                "\n",
                "\\n");
        }

        /// <summary>
        /// 使用 UTF-16 儲存 MSGXML
        /// </summary>
        private void SaveAsUtf16(
            XDocument document,
            string outputPath)
        {
            XmlWriterSettings settings =
                new XmlWriterSettings();

            // UTF-16 Little Endian
            settings.Encoding = Encoding.Unicode;

            // 不自行美化排版
            settings.Indent = false;

            settings.OmitXmlDeclaration = false;

            // 不修改 Message 中的換行內容
            settings.NewLineHandling =
                NewLineHandling.None;

            using (XmlWriter writer =
                   XmlWriter.Create(
                       outputPath,
                       settings))
            {
                document.Save(writer);
            }
        }

        /// <summary>
        /// 尋找英文工作表：名稱只要包含 EN 即可，不區分大小寫。
        /// 例如 ALARM (EN)、ALARM_EN、English 都能找到。
        /// </summary>
        private IXLWorksheet FindEnglishWorksheet(
            XLWorkbook workbook)
        {
            IXLWorksheet worksheet = workbook.Worksheets
                .FirstOrDefault(item =>
                    item.Name.IndexOf(
                        "EN",
                        StringComparison.OrdinalIgnoreCase) >= 0);

            if (worksheet == null)
            {
                throw new InvalidOperationException(
                    BuildWorksheetNotFoundMessage(
                        workbook,
                        "名稱包含 EN"));
            }

            return worksheet;
        }
        /// <summary>
        /// 尋找簡體中文工作表：名稱包含「簡」。
        /// </summary>
        private IXLWorksheet FindSimplifiedChineseWorksheet(
            XLWorkbook workbook)
        {
            IXLWorksheet worksheet = workbook.Worksheets
                .FirstOrDefault(item => item.Name.Contains("簡"));

            if (worksheet == null)
            {
                throw new InvalidOperationException(
                    BuildWorksheetNotFoundMessage(
                        workbook,
                        "名稱包含「簡」"));
            }

            return worksheet;
        }

        /// <summary>
        /// 建立工作表找不到時的詳細訊息。
        /// </summary>
        private string BuildWorksheetNotFoundMessage(
            XLWorkbook workbook,
            string condition)
        {
            string worksheetNames = string.Join(
                "\n",
                workbook.Worksheets.Select(item =>
                    "- " + item.Name));

            return
                "Excel 找不到符合條件的工作表：" +
                condition +
                "\n\n目前 Excel 內的工作表：\n" +
                worksheetNames;
        }

        /// <summary>
        /// 不區分大小寫取得 XML 屬性
        /// </summary>
        private string GetAttributeValue(
            XElement element,
            string attributeName)
        {
            XAttribute attribute =
                element.Attributes()
                    .FirstOrDefault(item =>
                        string.Equals(
                            item.Name.LocalName,
                            attributeName,
                            StringComparison.OrdinalIgnoreCase));

            return attribute == null
                ? ""
                : attribute.Value;
        }

        /// <summary>
        /// 比較兩個路徑是否指向同一個檔案
        /// </summary>
        private bool IsSamePath(
            string firstPath,
            string secondPath)
        {
            return string.Equals(
                Path.GetFullPath(firstPath),
                Path.GetFullPath(secondPath),
                StringComparison.OrdinalIgnoreCase);
        }
    }
    /// <summary>
    /// 單一 MSGXML 的轉換結果
    /// </summary>
    public class ConversionResult
    {
        public int ChineseCount { get; set; }

        public int EnglishCount { get; set; }

        public int SimplifiedChineseCount { get; set; }
    }
}
