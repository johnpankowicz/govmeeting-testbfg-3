// Idea for using IEnvironment: https://seangwright.medium.com/the-best-way-to-use-angulars-environment-files-a0c098551abc

export type LogLevel = 'debug' | 'info' | 'warn' | 'error';

export interface IEnvironment {
  production: boolean;
  enableDebugTools: boolean; // Enables use of ng.profiler.timeChangeDetection(); in browser console
  logLevel: LogLevel;
  apiHost: string;
  apiUrl: string;
  useServer: boolean; // If false we will use stubs for data received from server.
  isBeta: boolean; // Use only beta features
  useLargeData: boolean; // use the large data (full length videos and transcripts)
}
