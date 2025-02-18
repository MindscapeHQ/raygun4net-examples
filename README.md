# raygun4net-examples

A variety of example apps which are compatible with raygun4net

## Setup

### Clone Raygun4Net

Repository [Raygun4Net](https://github.com/MindscapeHQ/raygun4net) must be setup
in the same parent folder as this repository.

For example:

- `~/projects/raygun4net`
- `~/projects/raygun4net-examples`

## Development

### Build solution

All the examples can be build through the `raygun4net-examples.sln` solution
included in the repository root.

```
dotnet build
```

You might need to install workloads with:

```
dotnet workload restore
```

### Solution management

To add a project to the root solution, use the `sln` command:

```
dotnet sln add <path to csproj>
```

