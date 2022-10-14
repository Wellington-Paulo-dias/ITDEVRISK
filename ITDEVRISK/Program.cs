// See https://aka.ms/new-console-template for more information
using ITDEVRISK.Bussines;
using ITDEVRISK.Bussines.Category;
using ITDEVRISK.Domain;
using ITDEVRISK.Interface;
using System.Globalization;
using System.Xml.Linq;

internal class Program
{

    private static void Main(string[] args)
    {
        List<Trade> TradesList = new();
        List<string> TradeResult = new();

        bool exit = true;
        bool errDate = false;

        try
        {
            do
            {

                Console.WriteLine("Enter reference date:");
                var dataReference = Console.ReadLine();

                if (!string.IsNullOrEmpty(dataReference) && VerifyDateValid(dataReference.ToString()))
                {
                    Console.WriteLine("Enter the number of trades in the portfolio.");
                    var numberPortfolio = Console.ReadLine();
                    if (!string.IsNullOrEmpty(numberPortfolio))
                    {
                        for (int i = 0; i < int.Parse(numberPortfolio); i++)
                        {
                            Console.WriteLine("Enter the format below.");
                            Console.WriteLine("0000000 Sector mm/DD/yyyy");
                            Console.WriteLine("Trade amount | Client’s sector | Pending payment.");
                            Console.WriteLine($"Enter with {i + 1}° item:");
                            var resultValid = Console.ReadLine();
                            var arrayResult = resultValid.Split(' ');
                            if (arrayResult.Length == 3)
                            {
                                if (arrayResult[2].Length == 10)
                                {
                                    VerifyDate verifyDate = new(arrayResult[2]);
                                    if (verifyDate.Return())
                                    {
                                        TradesList.Add(new Trade
                                        {
                                            Value = Convert.ToDouble(arrayResult[0]),
                                            ClientSector = arrayResult[1],
                                            NextPaymentDate = Convert.ToDateTime(arrayResult[2], new CultureInfo("en-US"))

                                        });
                                        Console.WriteLine($"Trade {i+1}° successfully added");
                                    }
                                    else
                                    {
                                        Console.WriteLine("Format date invalid, Please verify format!");
                                        i--;
                                    }                                    
                                }
                                else
                                {
                                    Console.WriteLine("Format date invalid!");
                                }
                            }
                        }
                        var result = ResutlTrade(TradesList, Convert.ToDateTime(dataReference));
                        if (result is not null)
                        {
                            Console.WriteLine("Result:");
                            foreach (var item in result)
                            {
                                Console.WriteLine($"{item}");
                            }
                        }
                    }
                    else
                    {
                        Console.WriteLine("Number of trades invalid!");
                    }
                }
                else
                {
                    Console.WriteLine("Reference date invalid, please verify format!");
                    errDate = true;
                }
                exit = errDate is true ? true : false;
            }
            while (exit);
        }
        catch (Exception err)
        {
            Console.WriteLine(err.Message);
        }

    }

    private static bool VerifyDateValid(string dataReference)
    {
        VerifyDate verifyDate = new VerifyDate(dataReference);
        return verifyDate.Return();
    }

    public static List<string> ResutlTrade(List<Trade> tradelist, DateTime dataReference)
    {
        List<string> result = new();
        foreach (var item in tradelist)
        {
            if (VerifyExpired(item, dataReference))
            {
                result.Add(Constants.Category.EXPIRED);
            }
            else
            {
                result.Add(VerifyRisk(item.Value, item.ClientSector));
            }
        }
        return result;
    }

    private static bool VerifyExpired(Trade tradeModel, DateTime dataReference)
    {
        var dataExp = new DateTime(tradeModel.NextPaymentDate.Year, tradeModel.NextPaymentDate.Month, tradeModel.NextPaymentDate.Day);
        ICategoryExpired category = new Category();
        return category.Expired(Convert.ToDateTime(dataReference), dataExp);
    }

    private static string VerifyRisk(double value, string clientSector)
    {
        string typeRisk = "";
        RiskService highRiskService = new(value, clientSector);
        var resultRisk = highRiskService.ReturnResult();
        if (resultRisk == (int)EnumCategory.HighRisk)
            typeRisk = Constants.Category.HIGHRISK;
        else
            typeRisk = Constants.Category.MEDIUMRISK;
        return typeRisk;
    }

   




}