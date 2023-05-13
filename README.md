# Yarp.DynamicRouting

Yarp.DynamicRouting is a dynamic routing solution built on top of YARP (Yet Another Reverse Proxy) that provides flexible and efficient routing capabilities for your applications. It leverages the power of PostgreSQL and Redis for distributed management and includes a dashboard implemented with .NET Blazor for easy configuration and monitoring.

## Features

- Dynamic routing: Easily configure and manage routing rules to direct incoming requests to different backend services based on various criteria.
- Load balancing: Implement a load balancer component that evenly distributes incoming requests across backend services to optimize resource utilization.
- High availability: Utilize Redis for distributed caching and state management to ensure high availability and fault tolerance.
- Scalability: Leverage PostgreSQL to store and manage dynamic routing configurations, allowing for seamless scaling and efficient management of large datasets.
- Real-time updates: Benefit from the dynamic nature of the solution, enabling real-time updates to routing configurations without requiring application restarts or service interruptions.
- Dashboard: Use the Blazor-based dashboard to manage and monitor dynamic routing configurations easily.

## Prerequisites

- .NET 7.0 SDK
- PostgreSQL database (version X or later)
- Redis server (version X or later)

## Getting Started

1. Clone the repository:
```
git clone https://github.com/dotknyl/yarp-dynamic-routing.git
```
2. Set up the PostgreSQL database:

- Create a new PostgreSQL database.
- Update the connection string in the `appsettings.json` file within the `Yarp.DynamicRouting.Infrastructure` project to point to your PostgreSQL database.

3. Set up Redis:

- Install and configure Redis on your system.
- Update the Redis connection details in the `appsettings.json` file within the `Yarp.DynamicRouting.Infrastructure` project.

4. Build and run applications:
```
cd yarp-dynamic-routing

# Dashboard
dotnet run --project src\Yarp.DynamicRouting.Dashboard

# Load balancer to handle requests
dotnet run --project src\Yarp.DynamicRouting.LoadBalancer
```

5. Access the Yarp.DynamicRouting dashboard:

Open your web browser and navigate to `http://localhost:5000` to access the Yarp.DynamicRouting dashboard. From here, you can configure routing rules, monitor the load balancing behavior, and manage dynamic routing configurations.

## Contributing

Contributions are welcome! If you find any issues or have suggestions for improvement, please open an issue or submit a pull request. Please ensure that your contributions align with the project's coding style and guidelines.

## License

This project is licensed under the [MIT License](LICENSE).

## Acknowledgements

Yarp.DynamicRouting is built upon the YARP project, which is an open-source project maintained by Microsoft. We extend our gratitude to the YARP community for their contributions and support.

If you have any questions or need assistance, please don't hesitate to reach out to the project maintainers.

Happy routing with Yarp.DynamicRouting!