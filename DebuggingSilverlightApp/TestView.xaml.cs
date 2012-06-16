using System;
using System.Collections.Generic;

namespace DebuggingSilverlightApp
{
    public partial class TestView
    {
        private const int ListCount = 1000000;
        private readonly List<DummyData> largeUseOfMemory = new List<DummyData>(ListCount);

        public TestView()
        {
            InitializeComponent();
            var guid = Guid.NewGuid();
            var number = new Random().Next(int.MaxValue);

            for (int i = 0; i < ListCount; i++)
            {
                largeUseOfMemory.Add(new DummyData()
                    {
                        Id = guid,
                        Number = number,
                        Text = "Some irrelevant dummy data consuming memory",
                        Price = 12345.6789m,
                        Date = DateTime.Now 
                    });
            }
        }

        public void EventHandler(object sender, EventArgs e)
        {
            // does nothing
        }
    }

    public class DummyData
    {
        public Guid Id { get; set; }
        public int Number { get; set; }
        public string Text { get; set; }
        public decimal Price { get; set; }
        public DateTime Date { get; set; }
    }
}
