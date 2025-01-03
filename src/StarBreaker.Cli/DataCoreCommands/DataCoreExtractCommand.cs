using System.Diagnostics;
using CliFx;
using CliFx.Attributes;
using CliFx.Infrastructure;
using StarBreaker.Cli.Utils;
using StarBreaker.DataCore;

namespace StarBreaker.Cli.DataCoreCommands;

[Command("dcb-extract", Description = "Extracts a DataCore binary file into separate xml files")]
public class DataCoreExtractCommand : ICommand
{
    [CommandOption("dcb", 'd', Description = "Path to the DataCore binary file")]
    public required string DataCoreBinary { get; init; }
    
    [CommandOption("output", 'o', Description = "Path to the output directory")]
    public required string OutputDirectory { get; init; }
    
    [CommandOption("filter", 'f', Description = "Pattern to filter entries")]
    public string? Filter { get; init; }
    
    public ValueTask ExecuteAsync(IConsole console)
    {
        var df = new DataForge(File.OpenRead(DataCoreBinary));

        console.Output.WriteLine("DataCore loaded.");
        console.Output.WriteLine("Exporting...");

        var sw = Stopwatch.StartNew();
        df.ExtractAll(OutputDirectory, Filter, new ProgressBar(console));
        sw.Stop();
        
        console.Output.WriteLine();
        console.Output.WriteLine($"Export completed in {sw.ElapsedMilliseconds}ms.");
        
        return default;
    }
}