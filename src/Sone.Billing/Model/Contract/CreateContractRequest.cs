using System;
using System.Collections.Generic;
using Sone.Billing.Model.Types;

namespace Sone.Billing.Model.Contract
{
    /// <summary>
    ///     Modelo de contrato
    /// </summary>
    public class CreateContractRequest
    {
        /// <summary>
        ///     Código de produto da operação
        /// </summary>
        public Guid MerchantKey { get; set; }

        /// <summary>
        ///     Modo de contratação
        /// </summary>
        public ContractMode ContractMode { get; set; }

        /// <summary>
        ///     Modo de pagamento
        /// </summary>
        public PaymentMode PaymentMode { get; set; }

        /// <summary>
        ///     Frequência de pagamento
        /// </summary>
        public Frequency Frequency { get; set; }

        /// <summary>
        ///     Valor da cobrança
        /// </summary>
        public decimal Value { get; set; }

        /// <summary>
        ///     Valor total do contrato
        /// </summary>
        public decimal? ValueTotal { get; set; }

        /// <summary>
        ///     Moeda
        /// </summary>
        public string CurrencyCode { get; set; }

        /// <summary>
        ///     Valor da 1ª cobrança
        /// </summary>
        public decimal? FirstInstallmentValue { get; set; }

        /// <summary>
        ///     Número de parcelas
        /// </summary>
        public short NumberOfInstallments { get; set; }

        /// <summary>
        ///     Dia de vencimento da cobrança
        /// </summary>
        public short DueExpiration { get; set; }

        /// <summary>
        ///     Início de vigência do contrato
        /// </summary>
        public DateTime StartDate { get; set; }

        /// <summary>
        ///     Fim de vigência do contrato
        /// </summary>
        public DateTime? FinishDate { get; set; }

        /// <summary>
        ///     Data de pagamento
        /// </summary>
       public DateTime? PaymentDate { get; set; }

        /// <summary>
        ///     Nosso número
        /// </summary>
        public string OurCode { get; set; }

        /// <summary>
        ///     Recorrência sem fim determinado
        /// </summary>
        public bool? Infinite { get; set; }

        /// <summary>
        ///     Renovação automática
        /// </summary>
        public bool? AutoRenew { get; set; }

        /// <summary>
        ///     Número de renovações
        /// </summary>
        public short? NumberRenew { get; set; }

        /// <summary>
        ///     Pagamento parcelado em repasse
        /// </summary>
        public Guid? SplitPayment { get; set; }

        /// <summary>
        ///     Contratante
        /// </summary>
        public Customer Customer { get; set; }

        /// <summary>
        ///     Dados de pagamento
        /// </summary>
        public IEnumerable<Payer> Payers { get; set; }

        /// <summary>
        ///     Dados complementares
        /// </summary>
        public Dictionary<string, string> Complementary { get; set; }


        public CreateContractRequest()
        {
            Payers = new List<Payer>();
            Complementary = new Dictionary<string, string>();
        }
    }
}