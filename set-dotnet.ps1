# Set local dotnet folder
$env:DOTNET_ROOT = "C:\Users\bakiyaswanth.reddy\.dotnet"
$env:PATH = "C:\Users\bakiyaswanth.reddy\.dotnet;" + $env:PATH

# Check installed SDKs
dotnet --list-sdks

# Check dotnet version
dotnet --version
cd api
code .
