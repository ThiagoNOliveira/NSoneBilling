# NSoneBilling

Exemple of use:

            var cnnC = ConnectionConfiguration.Builder
                .SetEnvironment(Environment.Sandbox)
                .SetOauthGrantType(GrantType.Password)
                .SetOauthApplicationId("1")
                .SetOauthClientId("jh3123jh12")
                .SetAuthenticationUsername("")
                .SetAuthenticationPassword("")
                .Build();

            using (var connection = new Connection(cnnC))
            {
                var returned = connection.Hire(Guid.Empty, string.Empty, string.Empty, string.Empty)
                    .SetFinishDate(DateTime.Now)
                    .Execute();
            }
