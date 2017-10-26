using System;
using System.Collections.Generic;
using Sone.Billing.Model.Types;

namespace Sone.Billing.Model.Contract
{
    /// <summary>
    ///     Modelo do cliente
    /// </summary>
    public class Customer
    {
        /// <summary>
        ///     Nome
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        ///     Documneto
        /// </summary>
        public string Document { get; set; }

        /// <summary>
        ///     Tipo de documento
        /// </summary>
        public string DocumentType { get; set; }

        /// <summary>
        ///     Data de Nascimento
        /// </summary>
        public DateTime? Birthdate { get; set; }

        /// <summary>
        ///     Gênero
        /// </summary>
        public Gender? Gender { get; set; }

        /// <summary>
        ///     Endereço
        /// </summary>
        public string Address { get; set; }

        /// <summary>
        ///     Número do endereço
        /// </summary>
        public string Number { get; set; }

        /// <summary>
        ///     Complemento do endereço
        /// </summary>
        public string Complement { get; set; }

        /// <summary>
        ///     Bairro
        /// </summary>
        public string Neighborhood { get; set; }

        /// <summary>
        ///     Cidade
        /// </summary>
        public string City { get; set; }

        /// <summary>
        ///     CEP
        /// </summary>
        public string PostalCode { get; set; }

        /// <summary>
        ///     Código do Estado(Região)
        /// </summary>
        public string SubDivisionCode { get; set; }

        /// <summary>
        ///     Código do País.
        /// </summary>
        public string CountryCode { get; set; }

        /// <summary>
        ///     Telefone
        /// </summary>
        public string Phone { get; set; }

        /// <summary>
        ///     Telefone
        /// </summary>
        public string Phone2 { get; set; }

        /// <summary>
        ///     E-mail
        /// </summary>
        public string Email { get; set; }

        /// <summary>
        ///     E-mail
        /// </summary>
        public string Email2 { get; set; }

        /// <summary>
        ///     Dados complementares
        /// </summary>
        public Dictionary<string, string> Complementary { get; set; }
    }
}