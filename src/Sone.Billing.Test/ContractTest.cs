using System;
using System.Collections.Generic;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Sone.Billing.Model.Contract;
using Sone.Billing.Model.Types;
using Sone.Core;
using Environment = Sone.Core.Environment;

namespace Sone.Billing.Test
{
    [TestClass]
    public class ContractTest
    {
        private ApiClientConfig _config;

        [TestInitialize]
        public void Initialize()
        {
            _config = ApiClientConfig.Builder
                .SetEnvironment(Environment.Sandbox)
                .SetOauthGrantType(GrantType.Password)
                .SetOauthApplicationId("")
                .SetOauthClientId("")
                .SetAuthenticationUsername("")
                .SetAuthenticationPassword("")
                .Build();
        }

        [TestMethod]
        public void CreateTest()
        {
            using (var client = new BillingApiClient(_config))
            {
                var contract = new CreateContractRequest
                {
                    MerchantKey = new Guid("MerchantKey"),
                    ContractMode = ContractMode.Recurrent,
                    PaymentMode = PaymentMode.Credit,
                    Frequency = Frequency.Monthly,
                    Value = 20,
                    ValueTotal = 200,
                    CurrencyCode = "986",
                    FirstInstallmentValue = 21,
                    NumberOfInstallments = 10,
                    DueExpiration = 10,
                    StartDate = DateTime.Now,
                    FinishDate = DateTime.Now.AddYears(1),
                    PaymentDate = DateTime.Now,
                    OurCode = "Sdk_Test",
                    Infinite = false,
                    AutoRenew = false,
                    NumberRenew = 0,
                    Customer = new Customer
                    {
                        Name = "Moreira Silva",
                        Document = "88181538110",
                        DocumentType = "CPF",
                        Birthdate = DateTime.Now.AddYears(-20),
                        Gender = Gender.M,
                        Address = "Rua Aarão Mendes",
                        Number = "122",
                        Complement = "Ap 101",
                        City = "Quixeramobim",
                        PostalCode = "63800-000",
                        SubDivisionCode = "BR-CE",
                        CountryCode = "BRA",
                        Phone = "558834449999",
                        Phone2 = "",
                        Email = "moreira.silva@solutionsone.com.br",
                        Email2 = ""
                    },
                    Payers = new List<Payer>
                        {
                            new Payer
                            {
                                Percent = 100,
                                Name = "Moreira Silva",
                                Document = "88181538110",
                                DocumentType = "CPF",
                                Credit = new PayerCredit
                                {
                                    CardHolder = "Moreira Silva",
                                    CardNumber = "4916463099149424",
                                    SecurityCode = "367",
                                    Brand = Brand.Visa,
                                    CardInvoiceDay = 10,
                                    CardBestBuyDay = 10,
                                    CardExpiration = "202111"
                                }
                            }
                        }
                };

                var contractResponse = client.Hire(contract);

                Assert.IsNotNull(contractResponse);
            }
        }
    }
}