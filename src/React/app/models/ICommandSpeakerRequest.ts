export interface ICommandSpeakerRequest {
  /**
   * Required message from the voice command
   */
  message: string;

  /**
   * Type of operation: "filter", "create", "update", "delete"
   * Defaults to "filter"
   */
  operation?: string;

  /**
   * Additional context for processing
   */
  context?: string;

  /**
   * Existing filter (optional) for combination with voice command
   */
  existingFilter?: any;

  /**
   * Additional domain-specific instructions
   */
  additionalInstructions?: string;
}