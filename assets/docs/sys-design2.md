**Clean Architecture**




* Independent of frameworks it does not require the existence of some tool or framework
* Testable easy to test – Core has no dependencies on anything external, so writing automated tests is much easier
* Independent of UI logic is kept out of the UI so it is easy to change to another technology – right now you might be using Angular, soon Vue, eventually Blazor!
* Independent of the database data-access concerns are cleanly separated so moving from SQL Server to CosmosDB or otherwise is trivial
* Independent of anything external in fact, Core is completely isolated from the outside world – the difference between a system that will last 3 years, and one that will last 20 years

**Govmeeting top level folders**

* src/Application
* src/Domain
* src/Infrastructure -  - external concerns: DB access, file access, logging, email, authorization and identity
* src/WebUI