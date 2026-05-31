# Framework Architecture

```mermaid
flowchart TD
    A[Feature Files] --> B[Step Definitions]
    B --> C[Page Objects]
    C --> D[Playwright Driver]
    D --> E[Browser]
    E --> F[Application Under Test - SauceDemo]

    G[Test Data - JSON] --> B
    H[Hooks] --> D
    H --> I[Screenshot Capture]
    H --> J[Extent HTML Reports]
    K[GitHub Actions] --> L[Build and Test Execution]