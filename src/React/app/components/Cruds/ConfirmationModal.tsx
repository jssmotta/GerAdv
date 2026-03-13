import React, { useEffect, useRef } from 'react';
import { Dialog, DialogActionsBar } from '@progress/kendo-react-dialogs';
import { Button } from '@progress/kendo-react-buttons';
import { useIsMobile } from '@/app/context/MobileContext';
import { createPortal } from 'react-dom';
import { useSwipeToClose } from '@/app/hooks/useSwipeToClose';

interface ConfirmationModalProps {
  isOpen: boolean;
  onConfirm: () => void;
  onCancel: () => void;
  message: string;
}

export const ConfirmationModal: React.FC<ConfirmationModalProps> = ({
  isOpen,
  onConfirm,
  onCancel,
  message,
}) => {
  if (!isOpen) return null;
  const isMobile = useIsMobile();
  const modalRef = useRef<HTMLDivElement>(null);

  // Hook para swipe to close em mobile
  const { attachSwipeListeners, detachSwipeListeners } = useSwipeToClose({
    onClose: onCancel,
    threshold: 80,
    velocityThreshold: 0.4,
    enabled: isMobile,
    direction: 'right'
  });

  useEffect(() => {
    if (isMobile && modalRef.current) {
      attachSwipeListeners(modalRef.current);
      return () => {
        detachSwipeListeners();
      };
    }
  }, [isMobile, attachSwipeListeners, detachSwipeListeners]);
  
  if (isMobile) {
    return createPortal(
      <>
        <div 
          style={{
            position: 'fixed',
            top: 0,
            left: 0,
            width: '100vw',
            height: '100vh',
            backgroundColor: 'rgba(0, 0, 0, 0.5)',
            zIndex: 99998,
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center'
          }}
          onClick={onCancel}
        />
        <div
          ref={modalRef}
          style={{
            position: 'fixed',
            top: '50%',
            left: '50%',
            transform: 'translate(-50%, -50%)',
            width: '85vw',
            maxWidth: '350px',
            backgroundColor: 'var(--bg-tertiary, #fff)',
            borderRadius: '8px',
            boxShadow: '0 4px 20px rgba(0, 0, 0, 0.3)',
            zIndex: 99999,
            overflow: 'hidden',
            touchAction: 'pan-x' // Permite swipe horizontal mas previne scroll vertical
          }}
        > 
          <div style={{ 
            padding: '20px 15px 15px 15px', 
            textAlign: 'center', 
            fontSize: '15px',
            minHeight: '40px',
            display: 'flex',
            alignItems: 'center',
            justifyContent: 'center',
            color: 'var(--text-primary, #000)'
          }}>
            {message}
          </div>
          <div style={{
            display: 'flex',
            justifyContent: 'space-between',
            padding: '8px 15px 15px 15px',
            gap: '10px'
          }}>
            <Button
              style={{
                flex: 1,
                height: '35px',                 
                borderRadius: '4px',
                fontSize: '14px',
                fontWeight: 'bold'
              }}
              aria-label="Confirmar"
              className="k-button k-primary button-confirmation"
              onClick={onConfirm}
            >
              Confirmar
            </Button>
            <Button
              style={{
                flex: 1,
                height: '35px',                  
                borderRadius: '4px',
                fontSize: '14px'
              }}
              className="k-button button-cancel"
              aria-label="Cancelar"
              onClick={onCancel}
            >
              Cancelar
            </Button>
          </div>
        </div>
      </>,
      document.body
    );
  }
  
  return createPortal(
    <React.Fragment>
      <style>
        {`
          .custom-dialog-confirmation.k-dialog-wrapper {
            position: fixed !important;
            top: 50% !important;
            left: 50% !important;
            transform: translate(-50%, -50%) !important;
            z-index: 100000 !important;
          }
          
          .custom-dialog-confirmation .k-dialog {
            position: relative !important;
            top: auto !important;
            left: auto !important;
            transform: none !important;
            margin: 0 !important;
            z-index: 100001 !important;
            max-width: 600px !important;
            max-height: 250px !important;
            width: auto !important;
          }
          
          .custom-dialog-confirmation .k-overlay {
            z-index: 99999 !important;
          }
        `}
      </style>
      <Dialog 
        className="custom-dialog-confirmation msishad-shadow" 
        onClose={onCancel}
      >
      <p style={{ 
        padding: isMobile ? '15px 15px 10px 15px' : '20px 30px', 
        textAlign: 'center', 
        margin: 0, 
        fontSize: isMobile ? '15px' : '16px',
        minHeight: isMobile ? '40px' : 'auto',
        display: 'flex',
        alignItems: 'center',
        justifyContent: 'center'
      }}>
        {message}
      </p>
      <DialogActionsBar>
        <Button aria-label="Confirmar" className="k-button k-primary button-confirmation" onClick={onConfirm}>
          Confirmar
        </Button>
        <Button aria-label="Cancelar" className="k-button button-cancel" onClick={onCancel}>
          Cancelar
        </Button>
      </DialogActionsBar>
    </Dialog>
    </React.Fragment>,
    document.body
  );
}