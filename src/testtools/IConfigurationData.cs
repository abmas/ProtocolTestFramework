﻿// Copyright (c) Microsoft. All rights reserved.
// Licensed under the MIT license. See LICENSE file in the project root for full license information.

using System;
using System.Collections.Generic;
using System.Text;
using System.Collections.Specialized;
using System.Collections.ObjectModel;
using System.Runtime.InteropServices;

namespace Microsoft.Protocols.TestTools
{
    /// <summary>
    /// Provides all data from PTF configuration.
    /// </summary>
    public interface IConfigurationData
    {
        /// <summary>
        /// Abstract adapter class for all kinds of adapter
        /// </summary>
        /// <param name="adapterName">Adapter name</param>
        /// <returns>Adapter config instance</returns>
        AdapterConfig GetAdapterConfig(string adapterName);

        /// <summary>
        /// Gets log sink configs
        /// </summary>
        Collection<LogSinkConfig> LogSinks { get; }

        /// <summary>
        /// Gets log profile configs
        /// </summary>
        Collection<ProfileConfig> Profiles { get; }

        /// <summary>
        /// Gets the default log profile name
        /// </summary>
        string DefaultProfile { get; }

        /// <summary>
        /// Gets the output path of log analysis report file.
        /// </summary>
        string TestReportOutputFile { get; }

        /// <summary>
        /// Gets whether it needs to generate log analysis report automatically
        /// </summary>
        bool NeedGenerateReport { get; }

        /// <summary>
        /// Gets whether it needs to display the log analysis report after a test run
        /// </summary>
        bool NeedAutoDisplay { get; }

        /// <summary>
        /// Gets whether it needs to use the default test deployment directory
        /// </summary>
        bool UseDefaultOutputDir { get; }

        /// <summary>
        /// Gets all the requirement spec file names
        /// </summary>
        string[] RequirementFiles { get; }

        /// <summary>
        /// Gets all the log file names
        /// </summary>
        string[] LogFiles { get; }

        /// <summary>
        /// Gets the in scope parameter value
        /// </summary>
        string InScope { get; }

        /// <summary>
        /// Gets the out of scope parameter value
        /// </summary>
        string OutScope { get; }

        /// <summary>
        /// Gets the Document short name
        /// </summary>
        string Prefix { get; }

        /// <summary>
        /// Gets whether it needs to use the verbose mode of reporting tool
        /// </summary>
        bool VerboseMode { get; }

        /// <summary>
        /// Gets all the name-value collection properties
        /// </summary>
        NameValueCollection Properties { get; }
    }

    /// <summary>
    /// An abstract class which stores the adapter information
    /// </summary>
    [Serializable]
    public abstract class AdapterConfig
    {
        private string name;

        /// <summary>
        /// Constructs an adapter configuration
        /// </summary>
        /// <param name="name">Adapter name</param>
        protected AdapterConfig(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets the adapter interface name
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }
    }

    /// <summary>
    /// An abstract class which stores managed adapter information
    /// </summary>
    [Serializable]
    public class ManagedAdapterConfig : AdapterConfig
    {
        private string adapterType;
        private bool disablevalidation;

        /// <summary>
        /// Constructs a managed adapter instance
        /// </summary>
        /// <param name="name">Adapter name</param>
        /// <param name="adapterType">Adapter implementation class name</param>
        /// <param name="disablevalidation">True if it needs to disable validation</param>
        public ManagedAdapterConfig(string name, string adapterType, bool disablevalidation)
            : base(name)
        {
            this.adapterType = adapterType;
            this.disablevalidation = disablevalidation;
        }

        /// <summary>
        /// Gets the adapter implementation class name
        /// </summary>
        public string AdapterType
        {
            get { return this.adapterType; }
        }
        /// <summary>
        /// Gets the value whether disables validation
        /// </summary>
        public bool Disablevalidation
        {
            get { return disablevalidation; }
        }
    }

    /// <summary>
    /// An abstract class which stores custom adapter information
    /// </summary>
    [Serializable]
    public class CustomAdapterConfig : AdapterConfig
    {
        private string type;

        /// <summary>
        /// Constructs a customer adapter config.
        /// </summary>
        /// <param name="name">Adapter name</param>
        /// <param name="type">Adapter implementation class name</param>
        public CustomAdapterConfig(string name, string type)
            : base(name)
        {
            this.type = type;
        }

        /// <summary>
        /// Gets the customer defined adapter type name,
        /// for example, "RPC"
        /// </summary>
        public string Type
        {
            get { return this.type; }
        }
    }

    /// <summary>
    /// An abstract class which stores interactive adapter information
    /// </summary>
    [Serializable]
    public class InteractiveAdapterConfig : AdapterConfig
    {
        /// <summary>
        /// Constructs an interactive adapter instance
        /// </summary>
        /// <param name="name">Adapter name</param>
        public InteractiveAdapterConfig(string name)
            : base(name)
        {
        }
    }

    /// <summary>
    /// An abstract class which stores script adapter information
    /// </summary>
    [Serializable]
    public class ScriptAdapterConfig : AdapterConfig
    {
        private string scriptDir;

        /// <summary>
        /// Constructs a script adapter instance
        /// </summary>
        /// <param name="name">Adapter name</param>
        /// <param name="scriptDir">The directory name of the scripts path</param>
        public ScriptAdapterConfig(string name, string scriptDir)
            : base(name)
        {
            this.scriptDir = scriptDir;
        }

        /// <summary>
        /// Gets the directory name of scripts path
        /// </summary>
        public string ScriptDir
        {
            get { return this.scriptDir; }
        }
    }

    /// <summary>
    /// An abstract class which stores PowerShell script adapter information
    /// </summary>
    [Serializable]
    public class PowerShellAdapterConfig : AdapterConfig
    {
        private string scriptDir;

        /// <summary>
        /// Constructs a PowerShell adapter instance
        /// </summary>
        /// <param name="name">Adapter name</param>
        /// <param name="scriptDir">The directory name of the PowerShell scripts path</param>
        public PowerShellAdapterConfig(string name, string scriptDir)
            : base(name)
        {
            this.scriptDir = scriptDir;
        }

        /// <summary>
        /// Gets the directory name of the PowerShell script path
        /// </summary>
        public string ScriptDir
        {
            get { return this.scriptDir; }
        }
    }

    /// <summary>
    /// An abstract class which stores PowerShell script adapter information
    /// </summary>
    [Serializable]
    public class PsWrapperAdapterConfig : AdapterConfig
    {
        private string scriptFile;

        /// <summary>
        /// Constructs a PowerShell adapter instance
        /// </summary>
        /// <param name="name">Adapter name</param>
        /// <param name="scriptFile">The directory name of the PowerShell scripts path</param>
        public PsWrapperAdapterConfig(string name, string scriptFile)
            : base(name)
        {
            this.scriptFile = scriptFile;
        }

        /// <summary>
        /// Gets the directory name of the PowerShell script path
        /// </summary>
        public string ScriptFile
        {
            get { return this.scriptFile; }
        }
    }

    /// <summary>
    /// An abstract class which stores log sink config information
    /// </summary>
    [Serializable]
    public abstract class LogSinkConfig
    {
        private string name;

        /// <summary>
        /// Constructs a log sink config instance
        /// </summary>
        /// <param name="name">Log sink name</param>
        protected LogSinkConfig(string name)
        {
            this.name = name;
        }

        /// <summary>
        /// Gets or sets the log sink ID
        /// </summary>
        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }
    }

    /// <summary>
    /// An abstract class which stores custom log sink info
    /// </summary>
    [Serializable]
    public class CustomLogSinkConfig : LogSinkConfig
    {
        private string type;

        /// <summary>
        /// Constructs a customer log sink config instance
        /// </summary>
        /// <param name="name">Log sink name</param>
        /// <param name="type">Log sink implementation class name</param>
        public CustomLogSinkConfig(string name, string type)
            : base(name)
        {
            this.type = type;
        }

        /// <summary>
        /// Gets or sets the implementation class name of a
        /// customer defined log sink.
        /// </summary>
        public string Type
        {
            get { return this.type; }
            set { this.type = value; }
        }
    }

    /// <summary>
    /// An abstract class which stores file log sink information
    /// </summary>
    [Serializable]
    public class FileLogSinkConfig : LogSinkConfig
    {
        private string directory;
        private string format;
        private string file;

        /// <summary>
        /// Constructs a file log sink config
        /// </summary>
        /// <param name="name">Sink name</param>
        /// <param name="directory">Log file directory</param>
        /// <param name="file">Log file name</param>
        /// <param name="format">Log file format</param>
        public FileLogSinkConfig(string name, string directory, string file, string format)
            : base(name)
        {
            this.directory = directory;
            this.file = file;
            this.format = format;
        }




        /// <summary>
        /// Gets or sets the output directory
        /// of the log file
        /// </summary>
        public string Directory
        {
            get { return this.directory; }
            set { this.directory = value; }
        }

        /// <summary>
        /// Gets or sets the log file name
        /// like "file.txt", "file.xml"
        /// </summary>
        public string File
        {
            get { return this.file; }
            set { this.file = value; }
        }

        /// <summary>
        /// Gets or sets the log file format
        /// which can only be "txt" or "xml"
        /// </summary>
        public string Format
        {
            get { return this.format; }
            set { this.format = value; }
        }

    }

    /// <summary>
    /// An abstract class which stores console log sink config information
    /// </summary>
    [Serializable]
    public class ConsoleLogSinkConfig : LogSinkConfig
    {
        private string id;

        /// <summary>
        /// Constructs a console log sink
        /// </summary>
        /// <param name="name">Log sink name</param>
        /// <param name="id">Log sink ID which is the unique name of the sink</param>
        public ConsoleLogSinkConfig(string name, string id)
            : base(name)
        {
            this.id = id;
        }

        /// <summary>
        /// Gets or sets the unique name of the console sink
        /// </summary>
        public string ID
        {
            get { return this.id; }
            set { this.id = value; }
        }
    }

    /// <summary>
    /// An abstract class which stores profile rule config information
    /// </summary>
    [Serializable]
    public class ProfileRuleConfig
    {
        private string sink;
        private string kind;
        private bool delete;

        /// <summary>
        /// Constructs a log profile rule config
        /// </summary>
        /// <param name="kind">Log entry kind</param>
        /// <param name="sink">Log sink ID</param>
        /// <param name="delete">Indicates if this rule is disable</param>
        public ProfileRuleConfig(string kind, string sink, bool delete)
        {
            this.kind = kind;
            this.sink = sink;
            this.delete = delete;
        }

        /// <summary>
        /// Gets the value which indicates the kind of message,
        /// for example, CheckSucceeded, Comment.
        /// </summary>
        public string Kind
        {
            get { return this.kind; }
        }

        /// <summary>
        /// Gets the sink ID for the given log kind.
        /// </summary>
        public string Sink
        {
            get { return this.sink; }
        }

        /// <summary>
        /// Gets whether the rule is disabled.
        /// </summary>
        public bool Delete
        {
            get { return this.delete; }
        }
    }

    /// <summary>
    /// An abstract class which stores profile config information
    /// </summary>
    [Serializable]
    public class ProfileConfig
    {
        private string name;
        private Collection<ProfileRuleConfig> rules;
        private string baseProfile;

        /// <summary>
        /// Constructs a log profile config
        /// </summary>
        /// <param name="name">Profile name</param>
        /// <param name="baseProfile">Parent profile name</param>
        /// <param name="rules">Profile Rules in this config</param>
        public ProfileConfig(string name, string baseProfile, Collection<ProfileRuleConfig> rules)
        {
            this.name = name;
            this.baseProfile = baseProfile;
            this.rules = rules;
        }

        /// <summary>
        /// Gets the profile ID.
        /// </summary>
        public string Name
        {
            get { return this.name; }
        }

        /// <summary>
        /// Gets all the rules in this profile.
        /// </summary>
        public Collection<ProfileRuleConfig> Rules
        {
            get { return this.rules; }
        }

        /// <summary>
        /// Gets the profile name that the current one is extended from.
        /// </summary>
        public string BaseProfile
        {
            get { return this.baseProfile; }
        }
    }

    /// <summary>
    /// An abstract class which stores rpc adapter information
    /// </summary>
    [Serializable]
    public class RpcAdapterConfig : AdapterConfig
    {
        private bool needAutoValidate = true;
        private CallingConvention callingConvention;
        private CharSet charset;

        private string type;

        /// <summary>
        /// Constructs an instance of this class by passing adapter name and type and whether to enable the auto validation.
        /// </summary>
        /// <param name="name">The name of the adapter</param>
        /// <param name="type">The adapter type</param>
        /// <param name="autoValidate">True if it needs to autovalidate by default, false means to ignore validation.</param>
        /// <param name="callingConvention">The calling convention specified by the user through the config, the value could be winapi, stdcall or cdecl</param>
        /// <param name="charset">The char set specified by the user through the config, the value could be auto, ansi or unicode</param>
        public RpcAdapterConfig(string name, string type, bool autoValidate, CallingConvention callingConvention, CharSet charset)
            : base(name)
        {
            this.type = type;
            this.needAutoValidate = autoValidate;
            this.callingConvention = callingConvention;
            this.charset = charset;
        }

        /// <summary>
        /// Gets the customer defined adapter type name,
        /// for example, "RPC"
        /// </summary>
        public string Type
        {
            get { return this.type; }
        }

        /// <summary>
        /// Gets the adapter implementation class name
        /// </summary>
        public bool NeedAutoValidate
        {
            get { return this.needAutoValidate; }
        }

        /// <summary>
        /// Gets the calling convention specified by the user
        /// </summary>
        public CallingConvention CallingConvention
        {
            get { return callingConvention; }
        }

        /// <summary>
        /// Gets the char set specified by the user
        /// </summary>
        public CharSet Charset
        {
            get { return charset; }
        }
    }

}
