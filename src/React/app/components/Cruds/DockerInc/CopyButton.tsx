'use client';
import React from 'react';
import { useIsMobile } from '@/app/context/MobileContext';
import { SvgIcon } from '@progress/kendo-react-common';
import { copyIcon } from '@progress/kendo-svg-icons'; 
import { useCopyWindowDialog } from '@/app/hooks/useCopyWindowDialog';
import { CopyContentDialog } from '@/app/components/CopyContentDialog';

interface CopyButtonProps {  
  formId: string;
}

const CopyButton: React.FC<CopyButtonProps> = ({    
  formId
}) => {
  const isMobile = useIsMobile();  
  const { isDialogOpen, dialogContent, showCopyDialog, closeDialog } = useCopyWindowDialog();

  const onCopyClick = () => {
    if (typeof window !== 'undefined') {
      showCopyDialog(formId, false);
    }
  }; 

  const desktopStyle = {
    display: 'inline-block',
    width: 'auto',
    color: 'white',
    height: '20px',
    cursor: 'pointer',
    marginLeft: '8px'
  };

  const mobileStyle = {
    width: '40px !important' as any,
    height: '40px !important' as any,
    minWidth: '40px !important' as any,
    minHeight: '40px !important' as any,
    backgroundColor: '#fff !important' as any,
    borderRadius: '50% !important' as any,
    display: 'flex !important' as any,
    alignItems: 'center !important' as any,
    justifyContent: 'center !important' as any,
    cursor: 'pointer !important' as any,
    boxShadow: '0 2px 8px rgba(0,0,0,0.5) !important' as any,
    color: '#4CAF50 !important' as any,
    border: '2px solid #4CAF50 !important' as any,
    position: 'relative' as any,
    zIndex: '10000 !important' as any,
    pointerEvents: 'auto !important' as any,
    visibility: 'visible !important' as any,
    opacity: '1 !important' as any
  };
 
  return (
    <>
      {isMobile && (
        <style jsx>{`
          .copy-button-mobile {
            width: 40px !important;
            height: 40px !important;
            min-width: 40px !important;
            min-height: 40px !important;
            background-color: #fff !important;
            border-radius: 50% !important;
            display: flex !important;
            align-items: center !important;
            justify-content: center !important;
            cursor: pointer !important;
            box-shadow: 0 2px 8px rgba(0,0,0,0.5) !important;
            color: #4CAF50 !important;
            border: 2px solid #4CAF50 !important;
            position: relative !important;
            z-index: 10000 !important;
            pointer-events: auto !important;
            visibility: visible !important;
            opacity: 1 !important;
          }
          
          .copy-button-mobile:hover {
            transform: scale(1.1) !important;
            box-shadow: 0 4px 12px rgba(0,0,0,0.6) !important;
          }
        `}</style>
      )}
      <div 
        title='Copiar este formulário' 
        onClick={onCopyClick} 
        style={isMobile ? mobileStyle : desktopStyle}
        className={isMobile ? 'copy-button-mobile' : ''}
        tabIndex={996}
      >
        <SvgIcon icon={copyIcon} />
      </div>

      <CopyContentDialog
        isOpen={isDialogOpen}
        onClose={closeDialog}
        content={dialogContent}
        title="Conteúdo do Formulário"
      />
    </>
  );
};

export default CopyButton;
