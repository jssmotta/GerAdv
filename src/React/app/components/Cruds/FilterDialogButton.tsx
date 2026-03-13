"use client";
import React, { useState } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import GenericFilterDialog, { FilterHandlers } from './GenericFilterDialog';

interface FilterDialogButtonProps<T> {
  // Current nested filter object (e.g. filterFuncionarios)
  filter: T;
  // Setter for the nested filter
  setFilter: React.Dispatch<React.SetStateAction<T>>;
  // Callback that will be invoked when the dialog confirms the filter
  onConfirm: (filter: T) => Promise<void> | void;
  // Optional: function that renders the inputs for the nested filter
  renderInputFilters?: (handlers: FilterHandlers<T>) => React.ReactNode;
  // Optional: a hook (e.g. useEstadoCivilFilter) that returns a renderInputFilters
  // This component will call it (unconditionally via a noop fallback) and use
  // its `renderInputFilters` when present. Calling hooks passed as props must
  // be done unconditionally to respect the rules of hooks.
  useFilterHook?: (opts: { handleFetchWithFilter: (f?: T) => Promise<void> }) => {
    renderInputFilters: (handlers: FilterHandlers<T>) => React.ReactNode;
  };
  // Optional texts
  title?: string;
  buttonText?: string;
  buttonClassName?: string;
  minWidth?: number;
}

/**
 * Generic button that opens a GenericFilterDialog for a nested filter object.
 * Usage: pass the nested filter & setter (e.g. filterFuncionarios, setFilterFuncionarios)
 * and a renderInputFilters function for that filter shape.
 */
const FilterDialogButton = <T extends Record<string, any>>({
  filter,
  setFilter,
  onConfirm,
  renderInputFilters,
  useFilterHook,
  title = 'Filtrar',
  buttonText = 'Filtrar',
  buttonClassName,
  minWidth = 480,
}: FilterDialogButtonProps<T>) => {
  const [isOpen, setIsOpen] = useState(false);
  const [localFilter, setLocalFilter] = useState<T>(filter);
  const localFilterRef = React.useRef<T>(filter);
  const isClosingRef = React.useRef(false);

  // Mantém a ref atualizada com o localFilter
  React.useEffect(() => {
    localFilterRef.current = localFilter;
  }, [localFilter]);

  // Sincroniza localFilter quando filter muda (importante para receber atualizações de dialogs nested)
  // MAS não sincroniza quando o dialog está fechando
  React.useEffect(() => {
    if (isOpen && !isClosingRef.current) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.log('🔍 [FilterDialogButton] filter prop mudou para:', filter);
      }
      setLocalFilter(filter);
    }
  }, [filter, isOpen]);

  // Call the passed hook unconditionally (via a safe default) to get its renderer.
  // This respects the rules of hooks while keeping the component generic.
  const useFilterHookLocal =
    useFilterHook ?? ((opts: { handleFetchWithFilter: (f?: T) => Promise<void> }) => ({ renderInputFilters: undefined }));

  const hookRenderProvider = useFilterHookLocal({ handleFetchWithFilter: async () => {} }) || { renderInputFilters: undefined };

  const handleOpen = () => {
    // Quando abre o dialog, sincroniza o filtro local com o filtro da prop
    isClosingRef.current = false;
    setLocalFilter(filter);
    setIsOpen(true);
  };

  const handleClose = () => {
    isClosingRef.current = true;
    setIsOpen(false);
  };

  const handleConfirm = async (f: T) => {
    isClosingRef.current = true;
    // Atualiza o filtro local primeiro
    setLocalFilter(f);
    const maybePromise = onConfirm(f);
    if (maybePromise && typeof (maybePromise as any).then === 'function') {
      await (maybePromise as Promise<void>);
    }
  };

  // Create a setter compatible with React's SetStateAction<T>
  // GenericFilterDialog will call setWindowFilter with either a value or an updater function.
  const setNestedFilter = (value: T | ((prev: T) => T)) => {
    try {
      if (typeof value === 'function') {
        // compute new nested value using current localFilter
        const updater = value as (prev: T) => T;
        const next = updater(localFilterRef.current);
        if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.log('🔍 [FilterDialogButton] setNestedFilter (function) atualizado para:', next);
        }
        setLocalFilter(next);
        setFilter(next);
      } else {
        if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
          console.log('🔍 [FilterDialogButton] setNestedFilter (value) atualizado para:', value);
        }
        setLocalFilter(value as T);
        setFilter(value as T);
      }
    } catch (err) {
      // fallback: set directly
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.log('🔍 [FilterDialogButton] setNestedFilter (erro) atualizado para:', value);
      }
      setLocalFilter(value as T);
      setFilter(value as T);
    }
  };

  // Decide which renderer to provide to GenericFilterDialog:
  const chooseRenderer = (handlers: FilterHandlers<any>) => {
    // If caller provided a renderer, use it
    if (renderInputFilters) return renderInputFilters(handlers as any);

    // If a hook was provided and it exposes a renderer, use it
    if (hookRenderProvider && hookRenderProvider.renderInputFilters)
      return (hookRenderProvider.renderInputFilters as any)(handlers);
    // Fallback: show a simple JSON editor style field (basic behavior)
    return (
      <div style={{ padding: 12 }}>
        <label>Filtro (editar manualmente não implementado)</label>
      </div>
    );
  };

  return (
    <>
      <Button className={buttonClassName} onClick={handleOpen} aria-label={buttonText} style={{ width: 160 }}>
        {buttonText}
      </Button>
      {isOpen && (
        <GenericFilterDialog<T>
          isOpen={isOpen}
          onClose={handleClose}
          onConfirm={handleConfirm}
          title={title}
          windowFilter={localFilter}
          setWindowFilter={setNestedFilter}
          renderInputFilters={(h) => chooseRenderer(h)}
          minWidth={minWidth}
          nested={true}
        />
      )}
    </>
  );
};

export default FilterDialogButton;
