using CommandLine;
using Lab1;
using Lab2.Helpers;
using Lab3.Helpers;
using PK_Lab4.Console;

Parser.Default.ParseArguments<CommandOptions>(args)
           .WithParsed(RunOptions)
           .WithNotParsed(HandleParseError);

void RunOptions(CommandOptions options)
{
    if (options.Command == "version")
        Console.WriteLine($"Version: v{typeof(Program).Assembly.GetName().Version}", $"Author: Syniavskyi Illia");
    else if (options.Command == "run")
    {
        if (options.SubCommand == "lab1")
        {
            Console.WriteLine("Running Lab 1");
            Lab1Logic.StartLab(options.InputFilePath, options.OutputFilePath);
        }
        else if (options.SubCommand == "lab2")
        {
            Console.WriteLine("Running Lab 2");
            Lab2Logic.StartLab(options.InputFilePath, options.OutputFilePath);
        }
        else if (options.SubCommand == "lab3")
        {
            Console.WriteLine("Running Lab 3");
            Lab3Logic.StartLab(options.InputFilePath, options.OutputFilePath);
        }
        else
        {
            Console.WriteLine("Invalid subcommand. Use 'lab1', 'lab2', or 'lab3'.");
        }
    }
    else if (options.Command == "set-path")
    {
        Environment.SetEnvironmentVariable("LAB_PATH", options.Path);
        Console.WriteLine($"LAB_PATH set to: {options.Path}");
    }

}

void HandleParseError(IEnumerable<Error> errs)
{
    foreach (var error in errs)
        Console.WriteLine(error.ToString());
}