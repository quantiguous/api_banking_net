# api_banking_net
APIBanking .NET SDK

# Running tests
The unit tests run against the UAT environments, and therefore require you to have credentials as obtained from the bank that you would want to connect to.
THe code reads the information from Environment Variables, this isn't secure but helps avoid keep the test code simple and at the same time not commit my credentials to git.

## Yes Bank
Yes Bank requires you to have 
# a user/password (basic auth), client-id/client-secret and a client certificate (optional for UAT, mandatory for PRD)
# a public ip that is whitelisted with the bank

## Ratnakar Bank
Ratnakar Bank requires you to have 
# a user/password (basic auth), client-id/client-secret and a client certificate

