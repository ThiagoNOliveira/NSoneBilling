namespace Sone.Billing.Model.Contract
{
    /// <summary>
    ///     Modelo de contrato
    /// </summary>
    public class CreateContractResponse
    {
        /// <summary>
        ///     Indentificador
        /// </summary>
        public string Id { get; set; }

        /// <summary>
        ///     Número do contrado
        /// </summary>
        public string Number { get; set; }
    }
}