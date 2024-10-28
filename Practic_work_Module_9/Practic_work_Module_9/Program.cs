using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Practic_work_Module_9
{
    /*
    public interface IReport
    {
        string Generate();
    }

    // Классы отчетов
    public class SalesReport : IReport
    {
        public string Generate()
        {
            return "Отчет о продажах: список продаж с подробностями.\n";
        }
    }

    public class UserReport : IReport
    {
        public string Generate()
        {
            return "Отчет пользователя: список пользователей с подробностями.\n";
        }
    }

    // Абстрактный декоратор
    public abstract class ReportDecorator : IReport
    {
        protected IReport _report;

        protected ReportDecorator(IReport report)
        {
            _report = report;
        }

        public virtual string Generate()
        {
            return _report.Generate();
        }
    }

    // Декоратор для фильтрации по датам
    public class DateFilterDecorator : ReportDecorator
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public DateFilterDecorator(IReport report, DateTime startDate, DateTime endDate) : base(report)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public override string Generate()
        {
            return $"{_report.Generate()} Отфильтровано по датам от {_startDate.ToShortDateString()} к {_endDate.ToShortDateString()}.\n";
        }
    }

    // Декоратор для сортировки данных
    public class SortingDecorator : ReportDecorator
    {
        private string _sortCriteria;

        public SortingDecorator(IReport report, string sortCriteria) : base(report)
        {
            _sortCriteria = sortCriteria;
        }

        public override string Generate()
        {
            return $"{_report.Generate()} Сортировать по {_sortCriteria}.\n";
        }
    }

    // Декоратор для экспорта в CSV
    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            string reportData = _report.Generate();
            return reportData + "Экспортировано в формате CSV.\n";
        }
    }

    // Декоратор для экспорта в PDF
    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            string reportData = _report.Generate();
            return reportData + "Экспортировано в формате PDF.\n";
        }
    }

    // Клиентский код
    class Program
    {
        static void Main(string[] args)
        {
            // Создаем отчет по продажам
            IReport salesReport = new SalesReport();

            // Добавляем фильтр по датам, сортировку по сумме и экспорт в CSV
            DateTime startDate = new DateTime(2023, 1, 1);
            DateTime endDate = new DateTime(2023, 12, 31);
            salesReport = new DateFilterDecorator(salesReport, startDate, endDate);
            salesReport = new SortingDecorator(salesReport, "Количество");
            salesReport = new CsvExportDecorator(salesReport);

            Console.WriteLine("Отчет о продажах с фильтром по дате, сортировкой и экспортом в CSV:");
            Console.WriteLine(salesReport.Generate());

            // Создаем отчет по пользователям с сортировкой по дате и экспортом в PDF
            IReport userReport = new UserReport();
            userReport = new SortingDecorator(userReport, "Дата регистрации");
            userReport = new PdfExportDecorator(userReport);

            Console.WriteLine("Пользовательский отчет с сортировкой и экспортом в PDF:\n");
            Console.WriteLine(userReport.Generate());

            Console.ReadKey();
        }
        
    }
    */
    public interface IReport
    {
        string Generate();
    }

    // Классы отчетов
    public class SalesReport : IReport
    {
        public string Generate()
        {
            return "Отчет о продажах: список продаж с подробностями.\n";
        }
    }

    public class UserReport : IReport
    {
        public string Generate()
        {
            return "Отчет пользователя: список пользователей с подробностями.\n";
        }
    }

    // Абстрактный декоратор
    public abstract class ReportDecorator : IReport
    {
        protected IReport _report;

        protected ReportDecorator(IReport report)
        {
            _report = report;
        }

        public virtual string Generate()
        {
            return _report.Generate();
        }
    }

    // Декоратор для фильтрации по датам
    public class DateFilterDecorator : ReportDecorator
    {
        private DateTime _startDate;
        private DateTime _endDate;

        public DateFilterDecorator(IReport report, DateTime startDate, DateTime endDate) : base(report)
        {
            _startDate = startDate;
            _endDate = endDate;
        }

        public override string Generate()
        {
            return $"{_report.Generate()} Отфильтровано по датам от{_startDate.ToShortDateString()} к {_endDate.ToShortDateString()}.\n";
        }
    }

    // Декоратор для сортировки данных
    public class SortingDecorator : ReportDecorator
    {
        private string _sortCriteria;

        public SortingDecorator(IReport report, string sortCriteria) : base(report)
        {
            _sortCriteria = sortCriteria;
        }

        public override string Generate()
        {
            return $"{_report.Generate()} Сортировать по {_sortCriteria}.\n";
        }
    }

    // Новый декоратор для фильтрации по сумме продаж
    public class AmountFilterDecorator : ReportDecorator
    {
        private double _minAmount;
        private double _maxAmount;

        public AmountFilterDecorator(IReport report, double minAmount, double maxAmount) : base(report)
        {
            _minAmount = minAmount;
            _maxAmount = maxAmount;
        }

        public override string Generate()
        {
            return $"{_report.Generate()} Фильтр по объему продаж от {_minAmount} к {_maxAmount}.\n";
        }
    }

    // Новый декоратор для фильтрации пользователей по характеристикам
    public class UserCharacteristicFilterDecorator : ReportDecorator
    {
        private string _characteristic;

        public UserCharacteristicFilterDecorator(IReport report, string characteristic) : base(report)
        {
            _characteristic = characteristic;
        }

        public override string Generate()
        {
            return $"{_report.Generate()} Отфильтровано по характеристикам пользователя: {_characteristic}.\n";
        }
    }

    // Декоратор для экспорта в CSV
    public class CsvExportDecorator : ReportDecorator
    {
        public CsvExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            string reportData = _report.Generate();
            return reportData + "Экспортировано в формате CSV.\n";
        }
    }

    // Декоратор для экспорта в PDF
    public class PdfExportDecorator : ReportDecorator
    {
        public PdfExportDecorator(IReport report) : base(report) { }

        public override string Generate()
        {
            string reportData = _report.Generate();
            return reportData + "Экспортировано в формате PDF.\n";
        }
    }

    // Клиентский код с динамическим выбором декораторов
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите тип отчета (1 - Продажи, 2 - Пользователь):");
            int reportChoice = int.Parse(Console.ReadLine());
            IReport report = reportChoice == 1 ? new SalesReport() : (IReport)new UserReport();

            Console.WriteLine("Применить фильтр по дате? (y/n):");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine(" Введите дату начала(yyyy-mm-dd): ");
                DateTime startDate = DateTime.Parse(Console.ReadLine());
                Console.WriteLine(" Введите дату окончания(yyyy-mm-dd): ");
                DateTime endDate = DateTime.Parse(Console.ReadLine());
                report = new DateFilterDecorator(report, startDate, endDate);
            }

            Console.WriteLine("Применить фильтр количества? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Введите минимальную сумму: ");
                double minAmount = double.Parse(Console.ReadLine());
                Console.WriteLine("Введите максимальную сумму: ");
                double maxAmount = double.Parse(Console.ReadLine());
                report = new AmountFilterDecorator(report, minAmount, maxAmount);
            }

            Console.WriteLine(" Применить фильтр характеристик пользователя? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine(" Введите характеристику:");
                string characteristic = Console.ReadLine();
                report = new UserCharacteristicFilterDecorator(report, characteristic);
            }

            Console.WriteLine(" Применить сортировку?(y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                Console.WriteLine("Введите критерии сортировки (например, дату или сумму):");
                string criteria = Console.ReadLine();
                report = new SortingDecorator(report, criteria);
            }

            Console.WriteLine(" Экспортировать в CSV? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                report = new CsvExportDecorator(report);
            }

            Console.WriteLine(" Экспортировать в PDF? (y/n): ");
            if (Console.ReadLine().ToLower() == "y")
            {
                report = new PdfExportDecorator(report);
            }

            Console.WriteLine("\nСгенерированный отчет:");
            Console.WriteLine(report.Generate());
            Console.ReadKey();
        }
    }
}
