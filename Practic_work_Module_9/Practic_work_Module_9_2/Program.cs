using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practic_work_Module_9_2
{
    public interface IInternalDeliveryService
    {
        void DeliverOrder(string orderId);
        string GetDeliveryStatus(string orderId);
        decimal CalculateDeliveryCost(string orderId);
    }

    // Реализация внутренней службы доставки
    public class InternalDeliveryService : IInternalDeliveryService
    {
        public void DeliverOrder(string orderId)
        {
            Console.WriteLine($"Заказ {orderId} осуществляется внутренней службой.");
        }

        public string GetDeliveryStatus(string orderId)
        {
            return $" Статус заказа {orderId} это: В пути.";
        }

        public decimal CalculateDeliveryCost(string orderId)
        {
            return 10.0m;  
        }
    }

    // Сторонние логистические службы
    public class ExternalLogisticsServiceA
    {
        public void ShipItem(int itemId)
        {
            Console.WriteLine($" Элемент {itemId} Отправлено внешней логистической службой A.");
        }

        public string TrackShipment(int shipmentId)
        {
            return $"Отслеживание отправления {shipmentId} с внешней логистической службой А. ";
        }
    }

    public class ExternalLogisticsServiceB
    {
        public void SendPackage(string packageInfo)
        {
            Console.WriteLine($"Посылка отправлена ​​с информацией: {packageInfo} Внешняя логистическая служба B.");
        }

        public string CheckPackageStatus(string trackingCode)
        {
            return $"Статус кода отслеживания {trackingCode} из внешней логистической службы B.";
        }
    }

    public class ExternalLogisticsServiceC
    {
        public void DispatchPackage(string packageDetails)
        {
            Console.WriteLine($"Отправка посылки: {packageDetails} из Службы внешней логистики C.");
        }

        public string GetShipmentStatus(string trackingId)
        {
            return $"Статус отправки для {trackingId} из Службы внешней логистики C. ";
        }

        public decimal CalculateShippingCost(string packageDetails)
        {
            return 15.0m;  
        }
    }

    // Адаптер для ExternalLogisticsServiceA
    public class LogisticsAdapterA : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceA _externalService;

        public LogisticsAdapterA(ExternalLogisticsServiceA externalService)
        {
            _externalService = externalService;
        }

        public void DeliverOrder(string orderId)
        {
            int itemId = int.Parse(orderId); // Преобразование ID заказа в ID товара
            try
            {
                _externalService.ShipItem(itemId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при доставке: {ex.Message}");
            }
        }

        public string GetDeliveryStatus(string orderId)
        {
            int shipmentId = int.Parse(orderId);
            return _externalService.TrackShipment(shipmentId);
        }

        public decimal CalculateDeliveryCost(string orderId)
        {
            return 12.0m; // Фиксированная стоимость доставки
        }
    }

    // Адаптер для ExternalLogisticsServiceB
    public class LogisticsAdapterB : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceB _externalService;

        public LogisticsAdapterB(ExternalLogisticsServiceB externalService)
        {
            _externalService = externalService;
        }

        public void DeliverOrder(string orderId)
        {
            try
            {
                _externalService.SendPackage(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Ошибка при доставке: {ex.Message}");
            }
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _externalService.CheckPackageStatus(orderId);
        }

        public decimal CalculateDeliveryCost(string orderId)
        {
            return 8.0m; // Фиксированная стоимость доставки
        }
    }

    // Адаптер для ExternalLogisticsServiceC
    public class LogisticsAdapterC : IInternalDeliveryService
    {
        private readonly ExternalLogisticsServiceC _externalService;

        public LogisticsAdapterC(ExternalLogisticsServiceC externalService)
        {
            _externalService = externalService;
        }

        public void DeliverOrder(string orderId)
        {
            try
            {
                _externalService.DispatchPackage(orderId);
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Ошибка при доставке: {ex.Message}");
            }
        }

        public string GetDeliveryStatus(string orderId)
        {
            return _externalService.GetShipmentStatus(orderId);
        }

        public decimal CalculateDeliveryCost(string orderId)
        {
            return _externalService.CalculateShippingCost(orderId);
        }
    }

    // Фабрика для выбора службы доставки
    public static class DeliveryServiceFactory
    {
        public static IInternalDeliveryService GetDeliveryService(string serviceType)
        {
            switch (serviceType)
            {
                case "F":
                    return new InternalDeliveryService();
                case "A":
                    return new LogisticsAdapterA(new ExternalLogisticsServiceA());
                case "B":
                    return new LogisticsAdapterB(new ExternalLogisticsServiceB());
                case "C":
                    return new LogisticsAdapterC(new ExternalLogisticsServiceC());
                default:
                    throw new ArgumentException("Неверный тип услуги");
            }
        }
    }

    // Клиентский код
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Выберите службу доставки (Внутренняя F, Внешняя A, Внешняя B, Внешняя C): ");
            string serviceType = Console.ReadLine();

            IInternalDeliveryService deliveryService = DeliveryServiceFactory.GetDeliveryService(serviceType);

            string orderId = "1001"; // Пример ID заказа
            deliveryService.DeliverOrder(orderId);
            Console.WriteLine(deliveryService.GetDeliveryStatus(orderId));
            Console.WriteLine($"Стоимость доставки: {deliveryService.CalculateDeliveryCost(orderId)}");
        
            Console.ReadKey();
        }
    }
}
