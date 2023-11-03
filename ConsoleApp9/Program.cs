using System;
using System.IO;
using System.Threading;

class Bank
{
    private int money;
    private string name;
    private int percent;

    public int Money
    {
        get { return money; }
        set
        {
            if (money != value)
            {
                money = value;
                CreateAndRunThread();
            }
        }
    }

    public string Name
    {
        get { return name; }
        set
        {
            if (name != value)
            {
                name = value;
                CreateAndRunThread();
            }
        }
    }

    public int Percent
    {
        get { return percent; }
        set
        {
            if (percent != value)
            {
                percent = value;
                CreateAndRunThread();
            }
        }
    }

    private void CreateAndRunThread()
    {
        Thread thread = new Thread(() =>
        {
            string dataToWrite = $"Money: {Money}, Name: {Name}, Percent: {Percent}";

            // Задайте путь к файлу, куда нужно записать данные
            string filePath = "bank_data.txt";

            // Используйте блокировку, чтобы избежать конфликтов при одновременной записи в файл
            lock (this)
            {
                using (StreamWriter writer = File.AppendText(filePath))
                {
                    writer.WriteLine(dataToWrite);
                }
            }
        });

        thread.Start();
    }
}