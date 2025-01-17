﻿// ----------------------------------------------------------------------------------
//
// Copyright Microsoft Corporation
// Licensed under the Apache License, Version 2.0 (the "License");
// you may not use this file except in compliance with the License.
// You may obtain a copy of the License at
// http://www.apache.org/licenses/LICENSE-2.0
// Unless required by applicable law or agreed to in writing, software
// distributed under the License is distributed on an "AS IS" BASIS,
// WITHOUT WARRANTIES OR CONDITIONS OF ANY KIND, either express or implied.
// See the License for the specific language governing permissions and
// limitations under the License.
// ----------------------------------------------------------------------------------

using Microsoft.Azure.Commands.Insights.Properties;
using Microsoft.Azure.Management.Monitor.Models;
using System;
using System.Management.Automation;
using Microsoft.WindowsAzure.Commands.Common.CustomAttributes;

namespace Microsoft.Azure.Commands.Insights.Autoscale
{
    /// <summary>
    /// Create an Autoscale rule
    /// </summary>
    [CmdletDeprecation(ReplacementCmdletName = "New-AzAutoscaleScaleRuleObject")]
    [Cmdlet("New", ResourceManager.Common.AzureRMConstants.AzureRMPrefix + "AutoscaleRule"), OutputType(typeof(Management.Monitor.Management.Models.ScaleRule))]
    public class NewAzureRmAutoscaleRuleCommand : MonitorCmdletBase
    {
        private readonly TimeSpan MinimumTimeWindow = TimeSpan.FromMinutes(5);
        private readonly TimeSpan MinimumTimeGrain = TimeSpan.FromMinutes(1);

        #region Cmdlet parameters

        /// <summary>
        /// Gets or sets the MetricName parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric name for the setting")]
        [ValidateNotNullOrEmpty]
        public string MetricName { get; set; }

        /// <summary>
        /// Gets or sets the MetricResourceId parameter
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric resource id for the setting")]
        [ValidateNotNullOrEmpty]
        public string MetricResourceId { get; set; }

        /// <summary>
        /// Gets or sets the setting condition operator
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The setting condition operator")]
        public Management.Monitor.Management.Models.ComparisonOperationType Operator { get; set; }

        /// <summary>
        /// Gets or sets the MetricStatistic
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The setting metric statistic")]
        public Management.Monitor.Management.Models.MetricStatisticType MetricStatistic { get; set; }

        /// <summary>
        /// Gets or sets the Threshold
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The threshold for the setting condition")]
        public double Threshold { get; set; }

        /// <summary>
        /// Gets or sets the TimeAggregationType parameter
        /// </summary>
        [Parameter(ValueFromPipelineByPropertyName = true, HelpMessage = "The time aggregation operator for the setting")]
        public Management.Monitor.Management.Models.TimeAggregationType TimeAggregationOperator { get; set; }

        /// <summary>
        /// Gets or sets the time grain
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric trigger time grain for the setting")]
        public TimeSpan TimeGrain { get; set; }

        /// <summary>
        /// Gets or sets the TimeWindow
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The metric trigger timewindow for the setting")]
        public TimeSpan TimeWindow { get; set; }

        /// <summary>
        /// Gets or sets the scale action cooldown time
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scale action cooldown time for the setting")]
        public TimeSpan ScaleActionCooldown { get; set; }

        /// <summary>
        /// Gets or sets the scale action direction
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The acale action direction for the setting")]
        public Management.Monitor.Management.Models.ScaleDirection ScaleActionDirection { get; set; }

        /// <summary>
        /// Gets or sets the scale action value
        /// </summary>
        [Parameter(Mandatory = false, ValueFromPipelineByPropertyName = true, HelpMessage = "The scale type for the setting. It supports these values: ChangeCount (default), PercentChangeCount, ExactCount")]
        [ValidateNotNullOrEmpty]
        public Management.Monitor.Management.Models.ScaleType ScaleActionScaleType { get; set; }

        /// <summary>
        /// Gets or sets the scale action value
        /// </summary>
        [Parameter(Mandatory = true, ValueFromPipelineByPropertyName = true, HelpMessage = "The scale action value for the setting")]
        [ValidateNotNullOrEmpty]
        public string ScaleActionValue { get; set; }

        #endregion

        /// <summary>
        /// Executes the Cmdlet. This is a callback function to simplify the exception handling
        /// </summary>
        protected override void ProcessRecordInternal()
        { }

        /// <summary>
        /// Execute the cmdlet
        /// </summary>
        public override void ExecuteCmdlet()
        {
            ScaleRule rule = this.CreateSettingRule();
            WriteObject(rule);
        }

        /// <summary>
        /// Create an Autoscale setting rule based on the properties of the object
        /// </summary>
        /// <returns>A ScaleRule created based on the properties of the object</returns>
        public Management.Monitor.Management.Models.ScaleRule CreateSettingRule()
        {
            if (this.TimeWindow != default(TimeSpan) && this.TimeWindow < MinimumTimeWindow)
            {
                throw new ArgumentOutOfRangeException("TimeWindow", this.TimeWindow, ResourcesForAutoscaleCmdlets.MinimumTimeWindow5min);
            }

            if (this.TimeGrain < MinimumTimeGrain)
            {
                throw new ArgumentOutOfRangeException("TimeGrain", this.TimeGrain, ResourcesForAutoscaleCmdlets.MinimumTimeGrain1min);
            }

            var trigger = new Management.Monitor.Management.Models.MetricTrigger()
            {
                MetricName = this.MetricName,
                MetricResourceUri = this.MetricResourceId,
                OperatorProperty = this.Operator,
                Statistic = this.MetricStatistic,
                Threshold = this.Threshold,
                TimeAggregation = this.TimeAggregationOperator,
                TimeGrain = this.TimeGrain,
                TimeWindow = this.TimeWindow == default(TimeSpan) ? MinimumTimeWindow : this.TimeWindow,
            };

            // Notice ChangeCount is (ScaleType)0, so this is the default in this version. It was the only value in the previous version.
            var action = new Management.Monitor.Management.Models.ScaleAction()
            {
                Cooldown = this.ScaleActionCooldown,
                Direction = this.ScaleActionDirection,
                Value = this.ScaleActionValue,
                Type = this.ScaleActionScaleType
            };

            return new Management.Monitor.Management.Models.ScaleRule(metricTrigger: trigger, scaleAction: action);
        }
    }
}
