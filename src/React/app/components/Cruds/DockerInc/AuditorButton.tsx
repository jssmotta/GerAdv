'use client';
import React, { useEffect, useState } from 'react';
import { useIsMobile } from '@/app/context/MobileContext';
import { SvgIcon } from '@progress/kendo-react-common';
import { useAppSelector } from '@/app/store/hooks';
import { selectSystemContext } from '@/app/store/slices/systemContextSlice';
import { Auditor, AuditorApi } from '../../msi/Auditor';
import { auditorIcon } from '../../svg/auditorIcon';
import AuditorModal from '../AuditorModal';

interface AuditorButtonProps {
  id: number;
  tableName: string;  
  coolName: string;
}

const AuditorButton: React.FC<AuditorButtonProps> = ({
  id,
  tableName,  
  coolName
}) => {
  const [showAuditor, setShowAuditor] = useState(false);
  const systemContext = useAppSelector(selectSystemContext);
  const [isModalOpen, setIsModalOpen] = useState(false);
  const [auditor, setAuditor] = useState<Auditor | null>(null);
  const isMobile = useIsMobile();
  const auditorApi = new AuditorApi(systemContext?.TenantApp ?? '', systemContext?.Token ?? '');

  const onAuditorClick = () => {
    setIsModalOpen(true);
    auditorApi.fetchAuditor(tableName, id).then((data) => {
      setAuditor(data);
    });
  };

  const confirmAuditor = async () => {    
       setAuditor(null);   
  };

  const cancelAuditor = () => {
    setAuditor(null);
    setIsModalOpen(false);
  };

  useEffect(() => {
    setShowAuditor(auditor!=null);
  }, [auditor]);

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
    color: '#FF9800 !important' as any,
    border: '2px solid #FF9800 !important' as any,
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
          .auditor-button-mobile {
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
            color: #FF9800 !important;
            border: 2px solid #FF9800 !important;
            position: relative !important;
            z-index: 10000 !important;
            pointer-events: auto !important;
            visibility: visible !important;
            opacity: 1 !important;
          }
          
          .auditor-button-mobile:hover {
            transform: scale(1.1) !important;
            box-shadow: 0 4px 12px rgba(0,0,0,0.6) !important;
          }
        `}</style>
      )}
      {id > 0 && (
        <div 
          title='Auditor deste registro.' 
          onClick={onAuditorClick} 
          style={isMobile ? mobileStyle : desktopStyle}
          className={isMobile ? 'auditor-button-mobile' : ''}
          tabIndex={998}
        >
          <SvgIcon icon={auditorIcon} />
        </div>
      )}

      {auditor && showAuditor && (
        <AuditorModal
          auditor={auditor}
          isOpen={isModalOpen}
          onConfirm={confirmAuditor}
          onCancel={cancelAuditor}
          entityName={tableName}
          id={id}
          title={coolName}
        />
      )}
    </>
  );
};

export default AuditorButton;
