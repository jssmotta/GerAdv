'use client';
import React, { useState, useEffect } from 'react';
import { useIsMobile } from '@/app/context/MobileContext';
import { useRouter } from 'next/navigation';
import { SvgIcon } from '@progress/kendo-react-common';
import { trashIcon } from '@progress/kendo-svg-icons';
import { ConfirmationModal } from '../ConfirmationModal';

interface DeleteButtonProps {
  id: number;
  dadoApi: any;
  page: string;
  closeModel?: () => void;
}

const DeleteButton: React.FC<DeleteButtonProps> = ({
  id,
  dadoApi,
  page,
  closeModel,
}) => {
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [deleteId, setDeleteId] = useState<number | null>(null);
  const isMobile = useIsMobile();
  const router = useRouter();

  const onDeleteClick = () => {
    setDeleteId(id);
    setIsModalOpen(true);
  };

  const confirmDelete = async () => {
    if (deleteId !== null) {
      try {
        await dadoApi.delete(deleteId);
        router.push(page);
        router.refresh();
      } catch {
        // Trate o erro conforme necessário
      } finally {
        if (closeModel) closeModel();
        setDeleteId(null);
        setIsModalOpen(false);
      }
    }
  };

  const cancelDelete = () => {
    setDeleteId(null);
    setIsModalOpen(false);
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
    color: '#d32f2f !important' as any,
    border: '2px solid #d32f2f !important' as any,
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
          .delete-button-mobile {
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
            color: #d32f2f !important;
            border: 2px solid #d32f2f !important;
            position: relative !important;
            z-index: 10000 !important;
            pointer-events: auto !important;
            visibility: visible !important;
            opacity: 1 !important;
          }
          
          .delete-button-mobile:hover {
            transform: scale(1.1) !important;
            box-shadow: 0 4px 12px rgba(0,0,0,0.6) !important;
          }
        `}</style>
      )}
      {id > 0 && (
        <div 
          title='Excluir este registro (com confirmação).' 
          onClick={onDeleteClick} 
          style={isMobile ? mobileStyle : desktopStyle}
          className={isMobile ? 'delete-button-mobile' : ''}
          tabIndex={999}
        >
          <SvgIcon icon={trashIcon} />
        </div>
      )}

      <ConfirmationModal
        isOpen={isModalOpen}
        onConfirm={confirmDelete}
        onCancel={cancelDelete}
        message="Deseja realmente excluir o registro?"
      />
    </>
  );
};

export default DeleteButton;
