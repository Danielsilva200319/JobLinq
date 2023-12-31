using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Threading.Tasks;
using JobLinq.Entities;

namespace JobLinq.Run
{
    public class Linq
    {
        /* Listas de las clases */
        List<Product> ProductList = new List<Product>()
        {
            new Product(){Id = 1, Name = "Martillo", UnitPrice = 12.000, Amount = 12, StockMin = 10, StockMax = 160},
            new Product(){Id = 2, Name = "Palas", UnitPrice = 2.000, Amount = 3, StockMin = 10, StockMax = 160},
            new Product(){Id = 3, Name = "Puntillas", UnitPrice = 500, Amount = 20, StockMin = 10, StockMax = 160},
            new Product(){Id = 4, Name = "Alambre", UnitPrice = 1.000, Amount = 15, StockMin = 10, StockMax = 160}
        };
        List<Client> ClientList = new List<Client>()
        {
            new Client(){Id = 1, Name = "Daniel", Email = "silvaguerrerodanielstiven@gmail.com"},
            new Client(){Id = 2, Name = "Johan", Email = "johan_234@gmail.com"},
            new Client(){Id = 3, Name = "Camilo", Email = "2003_Andres@gmail.com"},
            new Client(){Id = 4, Name = "Samuel", Email = "sdaljasdj_23@gmail.com"}
        };
        List<Bill> BillList = new List<Bill>()
        {
            new Bill(){Id = 1, Date = new DateOnly(2023, 11, 2), IdClient = 1, TotalBill = 50.000 },
            new Bill(){Id = 2, Date = new DateOnly(2023, 1, 15), IdClient = 2, TotalBill = 300.000 },
            new Bill(){Id = 3, Date = new DateOnly(2023, 7, 22), IdClient = 3, TotalBill = 20.000 },
            new Bill(){Id = 4, Date = new DateOnly(2023, 1, 30), IdClient = 4, TotalBill = 15.000 }
        };
        List<BillDetail> BillDetailList = new List<BillDetail>()
        {
            new BillDetail(){Id = 1, IdBill = 1, IdProduct = 1, Amount = 5, Value = 12.000 },
            new BillDetail(){Id = 2, IdBill = 1, IdProduct = 2, Amount = 3, Value = 8.000 },
            new BillDetail(){Id = 3, IdBill = 2, IdProduct = 3, Amount = 10, Value = 100.000 },
            new BillDetail(){Id = 4, IdBill = 2, IdProduct = 4, Amount = 8, Value = 30.000 }
        };
        /* MENU */
        public void Menu()
        {
            bool isActivate = true;
            while (isActivate)
            {
                Console.Clear();
                Console.WriteLine("+------------------------+");
                Console.WriteLine("|   HARDWARE INVENTORY   |");
                Console.WriteLine("+------------------------+");
                Console.WriteLine("|    1.Inventary         |");
                Console.WriteLine("|    2.Sold out          |");
                Console.WriteLine("|    3.Buy               |");
                Console.WriteLine("|    4.TotalBills        |");
                Console.WriteLine("|    5.List Sold         |");
                Console.WriteLine("|    6.Total value       |");
                Console.WriteLine("|    0.Salir             |");
                Console.WriteLine("+------------------------+");
                Console.Write("Select an option: ");
                int opcion = Int32.Parse(Console.ReadLine());
                switch (opcion)
                {
                    case 1:
                        list();
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                    case 2:
                        SoldOut();
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                    case 3:
                        Buy();
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                    case 4:
                        TotalBill();
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                    case 5:
                        ListProductsSold();
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                    case 6:
                        InventoryValue();
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                    case 0:
                        isActivate = false;
                        break;
                    default:
                        Console.WriteLine("Invalid Option");
                        Console.Write("Press Enter to Continue... ");
                        Console.ReadLine();
                        break;
                }
            }
        }
        /* 1.Inventary */
        public void list()
        {
            var InventaryProducts = ProductList.ToList();
            Console.Clear();
            Console.WriteLine("1.Products Inventory:");
            foreach (var item in InventaryProducts)
            {
                Console.WriteLine($"\tId: {item.Id}, Name: {item.Name}, Amount: {item.Amount}");
            }
        }
        /* 2. Sold Out */
        public void SoldOut()
        {
            Console.Clear();
            var productsOutStock = ProductList.Where(p => p.Amount < p.StockMin).ToList();
            Console.WriteLine("2.Products out of stock:");
            foreach (var tp in productsOutStock)
            {
                Console.WriteLine($"\tId: {tp.Id}, Name: {tp.Name}, Amount: {tp.Amount}");
            }
        }
        /* 3. Buy */
        public void Buy()
        {
            Console.Clear();
            var BuyProducts = ProductList.Where(p => p.Amount < p.StockMax).ToList();
            Console.WriteLine("3.Products to buy and amount to buy:");
            foreach (var i in BuyProducts)
            {
                int BuyAmount = i.StockMax - i.Amount;
                Console.WriteLine($"\tId: {i.Id}, Name: {i.Name}, Amount to Buy: {BuyAmount}");
            }
        }
        /* 4. Total Bills */
        public void TotalBill()
        {
            Console.Clear();
            Console.Write("Enter the month in lower case (e.g., enero, febrero, etc.): ");
            string monthInput = Console.ReadLine();
            DateTimeFormatInfo dtfi = DateTimeFormatInfo.CurrentInfo;
            string[] monthNames = dtfi.MonthNames;
            int selectedMonth = Array.IndexOf(monthNames, monthInput);
            if (selectedMonth != -1)
            {
                var billsForSelectedMonth = BillList
                    .Where(p => p.Date.Year == 2023 && p.Date.Month == selectedMonth + 1)
                    .ToList();
                Console.Clear();
                Console.WriteLine($"Total of bills for {monthInput}:");
                foreach (var item in billsForSelectedMonth)
                {
                    Console.WriteLine($"\tId: {item.Id}, Date: {item.Date}, TotalBill: {item.TotalBill:C}");
                }
                var totalBillForSelectedMonth = billsForSelectedMonth.Sum(p => p.TotalBill);
                Console.WriteLine($"Total of bills for {monthInput} is: {totalBillForSelectedMonth:C}");
            }
            else
            {
                Console.WriteLine("Invalid month input. Please enter a valid month (e.g., enero, febrero, etc.).");
            }
        }
        /* 5. List Sold */
        public void ListProductsSold()
        {
            Console.Clear();
            Console.Write("Enter the bill Id: ");
            int IdBillConsulted = Int32.Parse(Console.ReadLine());
            var ProductsSold = BillDetailList.Where(f => f.IdBill == IdBillConsulted)
            .Select(f => ProductList.FirstOrDefault(p => p.Id == f.IdProduct)).ToList();
            Console.WriteLine($"5.Products sold in the bill #{IdBillConsulted}:");
            foreach (var df in ProductsSold)
            {
                Console.WriteLine($"\tId: {df.Id}, Name: {df.Name}");
            }
        }
        /* 6. Total Value */
        public void InventoryValue()
        {
            Console.Clear();
            var InventoryValueTotal = ProductList.Sum(p => p.Amount * p.UnitPrice);
            Console.WriteLine($"6.Value Total of Inventary: {InventoryValueTotal:C}");
        }
    }
}