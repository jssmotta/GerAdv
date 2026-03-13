import React, { useState, useEffect } from 'react';
import { Button } from '@progress/kendo-react-buttons';
import { InputChangeEvent, MaskedTextBoxChangeEvent } from '@progress/kendo-react-inputs';
import { useIsMobile } from '@/app/context/MobileContext';
import { SvgIcon } from '@progress/kendo-react-common';
import { searchIcon, undoIcon } from '@progress/kendo-svg-icons';
import { EditWindow } from './EditWindow';
import { useWindow } from '@/app/hooks/useWindows';

// Tipos genéricos para handlers
// Handlers now accept either the original Kendo event or a plain object { name, value }
// to allow manual triggering (e.g., from useEffect) without causing runtime errors.
export type GenericInputHandler = (e: InputChangeEvent | { name: string; value: any } | { target: { name: string; value: any } }) => void;
export type handleInputMaskedChange = (e: MaskedTextBoxChangeEvent | { name: string; value: any } | { target: { name: string; value: any } }) => void;
export type GenericInputValorHandler = (e: React.ChangeEvent<HTMLInputElement>) => void;
export type GenericComboHandler = (e: any, fieldName: string) => void;
export type GenericDateHandler = (fieldName: string, value: string) => void;
export type GenericCustomHandler = (fieldName: string, value: any) => void;

// Interface para handlers personalizados
export interface FilterHandlers<T> {
  handleInputChange: GenericInputHandler;
  handleInputValorChange: GenericInputValorHandler;
  handleInputMaskedChange: handleInputMaskedChange;
  handleComboChange: GenericComboHandler;
  handleDateChange: GenericDateHandler;
  handleCustomChange: GenericCustomHandler;
  windowFilter: T;
  setWindowFilter: React.Dispatch<React.SetStateAction<T>>;
  // indica se este diálogo é nested (filho) — útil para renderizações condicionais
  isNested?: boolean;
}

interface GenericFilterDialogProps<T> {
  isOpen: boolean;
  onClose: () => void;
  onConfirm: (filter: T) => Promise<void>;
  title?: string;
  windowFilter: T;
  setWindowFilter: React.Dispatch<React.SetStateAction<T>>;
  renderInputFilters: (handlers: FilterHandlers<T>) => React.ReactNode;
  minWidth?: number;
  confirmText?: string;
  cancelText?: string;
  nested?: boolean;
}

export const GenericFilterDialog = <T extends Record<string, any>>({
  isOpen,
  onClose,
  onConfirm,
  title = "Filtrar",
  windowFilter,
  setWindowFilter,
  renderInputFilters,
  minWidth = 2400,
  nested = false,
  confirmText = nested ? "Voltar" : "Buscar",
  cancelText = "Cancelar"
}: GenericFilterDialogProps<T>) => {
  const [isLoading, setIsLoading] = useState(false);
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Handlers genéricos
  // Utilitário para extrair name/value de múltiplos formatos de evento
  const extractNameValue = (e: any): { name?: string; value?: any } => {
    if (!e) return {};
    if (e.target) {
      return { name: e.target.name, value: e.target.value };
    }
    // Caso seja passado direto { name, value }
    if (e.name !== undefined) {
      return { name: e.name, value: e.value };
    }
    return {};
  };

  const handleInputChange: GenericInputHandler = (e: any) => {
    const { name, value } = extractNameValue(e);
    if (typeof name === 'string') {
      setWindowFilter(prev => ({
        ...prev,
        [name]: value,
      }));
    } else if (process.env.NODE_ENV !== 'production') {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.warn('handleInputChange chamado sem name válido:', e);
      }
    }
  };

  const handleInputValorChange: GenericInputValorHandler = (e: React.ChangeEvent<HTMLInputElement> | any) => {
    const { name, value } = extractNameValue(e);
    if (typeof name === 'string') {
      setWindowFilter(prev => ({
        ...prev,
        [name]: value,
      }));
    } else if (process.env.NODE_ENV !== 'production') {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.warn('handleInputValorChange chamado sem name válido:', e);
      }
    }
  };

  const handleComboChange: GenericComboHandler = (e: any, fieldName: string) => {
    if (e?.id > 0) {
      setWindowFilter(prev => ({
        ...prev,
        [fieldName]: e.id,
      }));
    } else if (e?.value !== undefined) {
      setWindowFilter(prev => ({
        ...prev,
        [fieldName]: e.value,
      }));
    } else {
      setWindowFilter(prev => ({
        ...prev,
        [fieldName]: e,
      }));
    }
  };

  const handleDateChange: GenericDateHandler = (fieldName: string, value: string) => {
    setWindowFilter(prev => ({
      ...prev,
      [fieldName]: value,
    }));
  };

  const handleInputMaskedChange: handleInputMaskedChange = (e: any) => {
    const { name, value } = extractNameValue(e);
    if (typeof name === 'string') {
      setWindowFilter(prev => ({
        ...prev,
        [name]: value,
      }));
    } else if (process.env.NODE_ENV !== 'production') {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.warn('handleInputMaskedChange chamado sem name válido:', e);
      }
    }
  };

  const handleCustomChange: GenericCustomHandler = (fieldName: string, value: any) => {
    setWindowFilter(prev => ({
      ...prev,
      [fieldName]: value,
    }));
  };

  // Objeto com todos os handlers para passar para renderInputFilters
  const handlers: FilterHandlers<T> = {
    handleInputChange,
    handleInputValorChange,
    handleComboChange,
    handleDateChange,
    handleInputMaskedChange,
    handleCustomChange,
    windowFilter,
    setWindowFilter
  ,isNested: nested
  };

  const handleConfirm = async () => {
    setIsLoading(true);
    try {      
      await onConfirm(windowFilter);
      onClose();
    } catch (error) {
      if (process.env.NEXT_PUBLIC_SHOW_LOG === '1') {
        console.error('Erro ao aplicar filtro:', error);
      }
    } finally {
      setIsLoading(false);
    }
  };

  const handleCancel = () => {
    onClose();
  };

  const handleClean = async () => {
    setWindowFilter({} as T);
    await onConfirm({} as T);
    onClose();
  };

  // Handle Enter key press
  useEffect(() => {
    const handleKeyDown = (e: KeyboardEvent) => {
      if (e.key === 'Enter' && !isLoading && isOpen) {
        e.preventDefault();
        handleConfirm();
      }
    };

    if (isOpen) {
      window.addEventListener('keydown', handleKeyDown);
    }

    return () => {
      window.removeEventListener('keydown', handleKeyDown);
    };
  }, [isOpen, isLoading, windowFilter]);

  // Função utilitária para achatar filhos, incluindo fragmentos
  function flattenChildren(children: React.ReactNode): React.ReactElement[] {
    const result: React.ReactElement[] = [];
    React.Children.forEach(children, child => {
      if (React.isValidElement(child) && child.type === React.Fragment) {
        // Força o tipo para acessar props.children
        const fragment = child as React.ReactElement<{ children?: React.ReactNode }>;
        result.push(...flattenChildren(fragment.props.children));
      } else if (React.isValidElement(child)) {
        result.push(child);
      }
    });
    return result;
  }

  if (!isOpen) return null;

  // Largura fixa de 800px para desktop
  const effectiveWidth = isMobile ? dimensions.width : 1300;

  // Container principal que envolve tudo
  const mainContainerStyle: React.CSSProperties = {
    display: 'flex',
    flexDirection: 'column',
    height: '100%',
    width: '100%',
    overflow: 'hidden',
  };

  // Área de scroll do conteúdo
  const contentScrollStyle: React.CSSProperties = isMobile
    ? {
      flex: 1,
      overflowY: 'auto',
      overflowX: 'hidden',
      padding: '15px',
      display: 'flex',
      flexDirection: 'column',
      gap: 12,
    }
    : {
      flex: 1,
      overflowY: 'auto',
      overflowX: 'hidden',
      padding: '10px 20px 20px 20px',
      display: 'flex',
      flexDirection: 'row',
      gap: 16,
    };

  // Área dos botões fixos
  const footerStyle: React.CSSProperties = {
    display: 'flex',
    justifyContent: 'flex-end',
    gap: 8,
    padding: isMobile ? '16px' : '16px 20px',
    borderTop: '1px solid #e0e0e0',
    background: '#fff',
    flexShrink: 0,
  };

  return (
    <>
      <style >
        {`
       .k-window {    
        padding-top: 0 !important; 
      }
      .k-button-danger {
        background-color: #dc3545 !important;
        border-color: #dc3545 !important;
        color: white !important;
      }
      .k-button-danger:hover {
        background-color: #c82333 !important;
        border-color: #bd2130 !important;
      }
      .k-button-danger:disabled {
        background-color: #6c757d !important;
        border-color: #6c757d !important;
      }
      .k-button-filter {
        min-width: 100px;
      }
      .k-window-content {
        background-color: #fff !important;
      }
    `}
      </style>      
      <EditWindow
        tableTitle={title}
        isOpen={isOpen}
        onClose={handleCancel}
        dimensions={dimensions}
        newWidth={effectiveWidth}
        mobile={isMobile}
      >
        <div style={mainContainerStyle}>
          {/* Área de conteúdo com scroll */}
          <div style={contentScrollStyle}>
            {(() => {
              const filters = flattenChildren(renderInputFilters(handlers));

              // No mobile, exibe em coluna única
              if (isMobile) {
                return (
                  <>
                    {filters.map((el, idx) => (
                      <div key={idx} style={{ width: '100%', minHeight: 'auto' }}>{el}</div>
                    ))}
                  </>
                );
              }

              // No desktop, divide em três colunas para aproveitar o espaço
              const itemsPerColumn = Math.ceil(filters.length / 3);
              return (
                <>
                  <div style={{ flex: 1, display: 'flex', flexDirection: 'column', gap: 16, minWidth: 0 }}>
                    {filters.slice(0, itemsPerColumn).map((el, idx) => (
                      <div key={idx} style={{ width: '100%' }}>{el}</div>
                    ))}
                  </div>
                  <div style={{ flex: 1, display: 'flex', flexDirection: 'column', gap: 16, minWidth: 0 }}>
                    {filters.slice(itemsPerColumn, itemsPerColumn * 2).map((el, idx) => (
                      <div key={itemsPerColumn + idx} style={{ width: '100%' }}>{el}</div>
                    ))}
                  </div>
                  <div style={{ flex: 1, display: 'flex', flexDirection: 'column', gap: 16, minWidth: 0 }}>
                    {filters.slice(itemsPerColumn * 2).map((el, idx) => (
                      <div key={itemsPerColumn * 2 + idx} style={{ width: '100%' }}>{el}</div>
                    ))}
                  </div>
                </>
              );
            })()}
          </div>

          {/* Área dos botões fixos */}
          <div style={footerStyle}>
            <Button
              className="k-button-filter k-button"
              onClick={handleCancel}
              disabled={isLoading}
              aria-label="Cancelar"
            >
              {cancelText}
            </Button>
            <Button
              aria-label="Limpar"
              className="k-button-filter k-button k-button-danger"
              onClick={handleClean}
              disabled={isLoading}
            >
              LIMPAR
            </Button>
            {nested ?
              <Button
                aria-label={confirmText}
                className='k-button-filter k-button k-primary'
                onClick={handleConfirm}
                disabled={isLoading}
              >
                <SvgIcon icon={undoIcon} />
                {isLoading ? 'Voltando...' : confirmText}
              </Button>
              :
              <Button
                aria-label={confirmText}
                className='k-button-filter k-button k-primary k-button-filter-confirm'
                onClick={handleConfirm}                
                disabled={isLoading}
              >
                <SvgIcon icon={searchIcon} />
                {isLoading ? 'Buscando...' : confirmText}
              </Button>}
          </div>
        </div>
      </EditWindow>
    </>
  );

};

export default GenericFilterDialog;