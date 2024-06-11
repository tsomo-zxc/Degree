using Microsoft.Maui.Controls;
using Microcharts;
using SkiaSharp;
using Degree.MVVM.Models;
namespace Degree.MVVM.Views;

public partial class HomePage : ContentPage
{
    private List<InventoryChangeLogs> inventoryChangeLogs;

    public HomePage()
	{
        InitializeComponent();
        LoadData();
        LoadPicker();
        LoadChart(1);
    }
    private void LoadData()
    {
        // ��������� �����
        inventoryChangeLogs = App.InventoryLogsRepository.GetItems();
           
    }

    private void LoadPicker()
    {
        // ���������� Picker ���������� InventoryId
        var inventoryIds = inventoryChangeLogs.Select(log => log.InventoryId).Distinct().ToList();
        foreach (var id in inventoryIds)
        {
            var product = App.InventoryRepository.GetItem(x => x.Id == id);
            inventoryPicker.Items.Add(product.ProductName);
        }
    }

    private void OnInventoryPickerSelectedIndexChanged(object sender, EventArgs e)
    {
        // ��������� ��������� InventoryId
        if (inventoryPicker.SelectedIndex != -1)
        {
            var selectedInventory = inventoryPicker.Items[inventoryPicker.SelectedIndex].ToString();

            int id = App.InventoryRepository.GetItem(x => x.ProductName == selectedInventory).Id;
            LoadChart(id);
        }
    }

    private void LoadChart(int inventoryId)
    {
        // Գ���������� ����� ��� ��������� InventoryId
        var filteredData = inventoryChangeLogs.Where(log => log.InventoryId == inventoryId).ToList();

        // ���������� ����� �� ����� �� ��������� ������� ���
        var groupedData = filteredData
            .GroupBy(log => log.ChangeDate)
            .Select(g => new
            {
                ChangeDate = g.Key,
                ChangeQuantity = g.Sum(log => log.ChangeQuantity)
            })
            .ToList();

        // ��������� ������ ������ ��� �������
        var entries = new List<ChartEntry>();
        foreach (var data in groupedData)
        {
            entries.Add(new ChartEntry(data.ChangeQuantity)
            {
                Label = data.ChangeDate.ToString("MM.dd"),
                ValueLabel = data.ChangeQuantity.ToString(),
                Color = data.ChangeQuantity >= 0 ? SKColor.Parse("#00FF00") : SKColor.Parse("#FF0000"),
                TextColor = SKColors.Black,
                ValueLabelColor = SKColors.Black
            });
        }

        // ��������� ������� ���� LineChart
        var chart = new LineChart
        {
            Entries = entries,
            BackgroundColor = SKColor.Parse("#FFFFFF"), // ���� ����
            LineMode = LineMode.Straight,
            LineSize = 6,
            PointMode = PointMode.Circle,
            PointSize = 12,
            LabelTextSize = 32, // ����� ������ ��� ����
            ValueLabelTextSize = 32, // ����� ������ ��� �������
            LabelOrientation = Orientation.Horizontal, // �������� ������ ����
            ShowYAxisLines = true,
            ShowYAxisText = true,
            LabelColor = SKColors.Black,
            ValueLabelOrientation=Orientation.Horizontal,
            YAxisLinesPaint = new SKPaint
            {
                Style = SKPaintStyle.Stroke,
                Color = SKColors.Gray,
                StrokeWidth = 2
            },
            EnableYFadeOutGradient = false,
        };

        // ³���������� ������� � ChartView
        chartView.Chart = chart;
    }
}