using Sone.Billing.Model.Types;

namespace Sone.Billing.Model.Contract
{
    public class Payer
    {
        /// <summary>
        ///     Percentage do valor
        /// </summary>
        public short Percent { get; set; }

        /// <summary>
        ///     Nome do pagante
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Documento do pagante
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        ///     Tipo de documento
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        ///     Dados de pagamento de crédito
        /// </summary>
        public PayerCredit Credit { get; set; }

        /// <summary>
        ///     Dados de pagamento de débito
        /// </summary>
        public PayerDebit Debit { get; set; }
    }

    /// <summary>
    ///     Modelo de dados de pagamento de débito
    /// </summary>
    public class PayerDebit
    {
        /// <summary>
        ///     Número da conta
        /// </summary>
        public string AccountNumber { get; set; }

        /// <summary>
        ///     Código da conta
        /// </summary>
        public string AccountDigit { get; set; }

        /// <summary>
        ///     Código de operação
        /// </summary>
        public string AccountType { get; set; }

        /// <summary>
        ///     Número da agência
        /// </summary>
        public string BranchNumber { get; set; }

        /// <summary>
        ///     Código da agência
        /// </summary>
        public string BranchDigit { get; set; }

        /// <summary>
        ///     Código do banco
        /// </summary>
        public string BankCode { get; set; }
    }

    /// <summary>
    ///     Modelo de dados de pagamento de crédito
    /// </summary>
    public class PayerCredit
    {
        /// <summary>
        ///     Nome no cartão
        /// </summary>
        public string CardHolder { get; set; }

        /// <summary>
        ///     Número do cartão
        /// </summary>
        public string CardNumber { get; set; }

        /// <summary>
        ///     Código do cartão
        /// </summary>
        public string SecurityCode { get; set; }

        /// <summary>
        ///     Banderia do cartão
        /// </summary>
        public Brand Brand { get; set; }

        /// <summary>
        ///     Dia de fechamento do fatura
        /// </summary>
        public short? CardInvoiceDay { get; set; }

        /// <summary>
        ///     Melhor dia para comprar
        /// </summary>
        public short? CardBestBuyDay { get; set; }

        /// <summary>
        ///     Validade do cartão. format:YYYYMM
        /// </summary>
        public string CardExpiration { get; set; }
    }
}