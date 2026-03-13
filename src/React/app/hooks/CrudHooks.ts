// ============================================================================
// CrudHooks.ts — Source Genesys (SG) CRUD Lifecycle Hooks
// ============================================================================
// Core interfaces and hook runners used by every SG-generated CRUD.
// This file lives in the shared core, NOT in _STATIC.
// ============================================================================

// ----------------------------------------------------------------------------
// Result returned by cancelable "before" hooks.
// - cancel: if true, the action is aborted.
// - record: optionally returns a modified record to replace the original.
// ----------------------------------------------------------------------------
export interface BeforeHookResult<T> {
  cancel?: boolean;
  record?: T;
}

// ----------------------------------------------------------------------------
// Result returned by mass-operation "before" hooks.
// - cancel:       if true, the entire batch is aborted.
// - records:      the approved subset (may be filtered/modified).
// - rejected:     items that were vetoed by the hook.
// - rejectReason: human-readable explanation shown to the user.
// ----------------------------------------------------------------------------
export interface MassHookResult<T> {
  cancel?: boolean;
  records?: T[];
  rejected?: T[];
  rejectReason?: string;
}

// ============================================================================
// CrudHooks<T> — Full lifecycle hook interface
// ============================================================================
// T = the entity interface (e.g., IClientes, IConsulta, IProntuario)
// ============================================================================
export interface CrudHooks<T = any> {

  // --------------------------------------------------------------------------
  // ADD FORM — Preparing a new record for the CadInc screen
  // --------------------------------------------------------------------------
  // Receives the record created by EmptyX() and returns it enriched with
  // default values, calculated fields, or business rules.
  // This hook does NOT cancel — it prepares.
  // --------------------------------------------------------------------------
  beforeAddForm?: (record: T) => T | Promise<T>;
  afterAddForm?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // LOAD — Loading an existing record for editing
  // --------------------------------------------------------------------------
  // Runs when a record is fetched for the CadInc screen (edit mode).
  // Allows transforming data before display (formatting, computed fields,
  // fetching complementary data from other sources).
  // --------------------------------------------------------------------------
  beforeLoad?: (record: T) => T | Promise<T>;
  afterLoad?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // VALIDATION — Before and after field validation
  // --------------------------------------------------------------------------
  // beforeValidation can cancel (e.g., skip validation under certain rules)
  // or modify the record before validators run.
  // afterValidation receives the validation errors array for custom handling.
  // --------------------------------------------------------------------------
  beforeValidation?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterValidation?: (record: T, errors?: string[]) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // SAVE: NEW — Inserting a new record
  // --------------------------------------------------------------------------
  // Runs after validation passes, right before the API call to create.
  // Can cancel (e.g., duplicate check) or modify the record.
  // --------------------------------------------------------------------------
  beforeNew?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterNew?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // SAVE: CHANGE — Updating an existing record
  // --------------------------------------------------------------------------
  // Receives BOTH the current record and the original (before edits).
  // Enables comparison logic (e.g., block status transitions, detect
  // which fields changed, trigger side effects on specific changes).
  // --------------------------------------------------------------------------
  beforeChange?: (record: T, original: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterChange?: (record: T, original: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // AUDIT — Writing audit trail entries (on save/delete)
  // --------------------------------------------------------------------------
  // Fires when the system records audit data (the 5 mandatory fields).
  // Allows injecting extra audit logic (e.g., log specific field changes,
  // notify stakeholders, write to external audit systems).
  // --------------------------------------------------------------------------
  beforeAudit?: (record: T, action: 'new' | 'change' | 'delete') => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterAudit?: (record: T, action: 'new' | 'change' | 'delete') => void | Promise<void>;

  // --------------------------------------------------------------------------
  // DELETE — Removing a single record permanently
  // --------------------------------------------------------------------------
  // Can cancel (e.g., record has dependencies, active balance, etc.).
  // --------------------------------------------------------------------------
  beforeDelete?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterDelete?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // LIST / GRID — Before rendering the record list
  // --------------------------------------------------------------------------
  // Allows filtering, reordering, or injecting computed columns
  // before the grid renders. Does not cancel — transforms the array.
  // --------------------------------------------------------------------------
  beforeList?: (records: T[]) => T[] | Promise<T[]>;
  afterList?: (records: T[]) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // COPY TO CLIPBOARD — Sidebar button: "Copiar dados para a memória"
  // --------------------------------------------------------------------------
  // Intercepts the copy action. Allows omitting sensitive fields,
  // reformatting data, or canceling the copy entirely.
  // --------------------------------------------------------------------------
  beforeCopy?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterCopy?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // PRINT — Printing a single record / form
  // --------------------------------------------------------------------------
  beforePrint?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterPrint?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // EXPORT — Exporting a single record
  // --------------------------------------------------------------------------
  beforeExport?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterExport?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // OPEN AUDITOR — Sidebar button: "Abrir o Auditor"
  // --------------------------------------------------------------------------
  // Intercepts opening the Auditor panel (view mode, not write).
  // Can cancel (e.g., restrict access) or enrich the record context.
  // --------------------------------------------------------------------------
  beforeOpenAudit?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterOpenAudit?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // HELP — Sidebar button: "Esta Ajuda"
  // --------------------------------------------------------------------------
  // Intercepts opening the help panel. Allows injecting custom content,
  // redirecting to external docs, or canceling the default behavior.
  // --------------------------------------------------------------------------
  beforeHelp?: (record: T) => BeforeHookResult<T> | Promise<BeforeHookResult<T>>;
  afterHelp?: (record: T) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // MASS DELETE — Deleting multiple selected records
  // --------------------------------------------------------------------------
  // Receives the full selected array. Can filter out protected records,
  // cancel the entire batch, or modify records before deletion.
  // afterMassDelete receives both processed and rejected arrays.
  // --------------------------------------------------------------------------
  beforeMassDelete?: (records: T[]) => MassHookResult<T> | Promise<MassHookResult<T>>;
  afterMassDelete?: (deleted: T[], rejected?: T[]) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // MASS EXPORT — Exporting multiple selected records
  // --------------------------------------------------------------------------
  beforeMassExport?: (records: T[]) => MassHookResult<T> | Promise<MassHookResult<T>>;
  afterMassExport?: (exported: T[], rejected?: T[]) => void | Promise<void>;

  // --------------------------------------------------------------------------
  // MASS PRINT — Printing multiple selected records
  // --------------------------------------------------------------------------
  beforeMassPrint?: (records: T[]) => MassHookResult<T> | Promise<MassHookResult<T>>;
  afterMassPrint?: (printed: T[], rejected?: T[]) => void | Promise<void>;
}

// ============================================================================
// Hook Runners — Used by the SG-generated CRUD template
// ============================================================================

/**
 * Executes a cancelable "before" hook for single-record operations.
 * Returns { cancelled, record } where record may have been modified.
 */
export async function runBeforeHook<T>(
  hooks: CrudHooks<T>,
  name: keyof CrudHooks<T>,
  record: T,
  original?: T,
): Promise<{ cancelled: boolean; record: T }> {
  const fn = hooks[name] as any;
  if (!fn) return { cancelled: false, record };

  const result = await fn(record, original);

  // afterX hooks return void — treat as "proceed"
  if (!result) return { cancelled: false, record };

  return {
    cancelled: !!result.cancel,
    record: result.record ?? record,
  };
}

/**
 * Executes a cancelable "before" hook for mass operations.
 * Returns the full MassHookResult with approved/rejected arrays.
 */
export async function runMassHook<T>(
  hooks: CrudHooks<T>,
  name: keyof CrudHooks<T>,
  records: T[],
): Promise<MassHookResult<T>> {
  const fn = hooks[name] as any;
  if (!fn) return { cancel: false, records, rejected: [] };

  const result: MassHookResult<T> = await fn(records);

  return {
    cancel: !!result.cancel,
    records: result.records ?? records,
    rejected: result.rejected ?? [],
    rejectReason: result.rejectReason,
  };
}

// ============================================================================
// Lifecycle Flow Reference
// ============================================================================
//
// [NEW RECORD]
//   EmptyX() → beforeAddForm → CadInc opens
//     → beforeValidation → afterValidation
//     → beforeNew → beforeAudit('new') → SAVE → afterAudit('new') → afterNew
//     → afterAddForm
//
// [EDIT RECORD]
//   Fetch → beforeLoad → CadInc opens → afterLoad
//     → beforeValidation → afterValidation
//     → beforeChange(record, original) → beforeAudit('change') → SAVE
//     → afterAudit('change') → afterChange
//
// [DELETE]
//   beforeDelete → beforeAudit('delete') → DELETE
//   → afterAudit('delete') → afterDelete
//
// [SIDEBAR ACTIONS]
//   Grid:       beforeList → render → afterList
//   Copy:       beforeCopy → clipboard → afterCopy
//   Print:      beforePrint → print → afterPrint
//   Auditor:    beforeOpenAudit → open panel → afterOpenAudit
//   Help:       beforeHelp → open panel → afterHelp
//
// [MASS OPERATIONS]
//   Mass Delete:  beforeMassDelete → DELETE each → afterMassDelete
//   Mass Export:  beforeMassExport → export → afterMassExport
//   Mass Print:   beforeMassPrint → print → afterMassPrint
//
// ============================================================================
