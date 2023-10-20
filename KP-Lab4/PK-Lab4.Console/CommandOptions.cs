﻿using CommandLine;

namespace PK_Lab4.Console;

public class CommandOptions
{
    [Option('c', "command", Required = true, HelpText = "The command to execute (version, run, set-path).")]
    public string Command { get; set; } = string.Empty; 

    [Option('s', "sub-command", HelpText = "The sub-command to execute (lab1, lab2, lab3) when using the 'run' command.")]
    public string SubCommand { get; set; } = string.Empty;

    [Option('i', "input", HelpText = "Input file path.")]
    public string InputFilePath { get; set; } = null;

    [Option('o', "output", HelpText = "Output file path.")]
    public string OutputFilePath { get; set; } = null;

    [Option('p', "path", HelpText = "Path to the folder with input and output files when using the 'set-path' command.")]
    public string Path { get; set; } = string.Empty;
}
