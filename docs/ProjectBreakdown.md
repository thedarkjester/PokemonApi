# Project Breakdown

The solution is comprised of the following:

1. The main hosted Application `Pokemon`containing controllers and dependency injection configuration - this was designed to be light and not contain major bits of code - there are some mappings the should in a real world be moved into some other mapping service.
2. Pokemon.Domain - this defines all internal models and service interfaces that will be implemented - this gives a way to store/managed data in a way that is understood by the application but does depend on external API models and will allow our API models to remain unaffected by internal changes.
3. Pokemon.ApiModels - these are API Models that will be exposed externally. With a proper production error interceptor certain codes can be returned for a more meaningful experience.
4. Pokemon.Services - implementations of Processors and Orchestrators. As the non-translated endpoint uses only the lookup and mapping, it wasn't put into an orchestrator, but really should be. The translation orchestrator uses the processor for the main lookup plus another processor for the translations.
5. Tests.Unit tests - this is where all round testing would take place testing logic/permutations
6. Tests.ServiceTests - this is blackbox boundary testing with externals mocked testing behaviour of the service.



A note on the tests: I would normally factor in time for proper testing and to make sure the tests are covered. I focused more on the layout.

Regarding the naming conventions for the processors and orchestrators - I went with removing cognitive load and thinking about function names and using the processor to define it's logic.