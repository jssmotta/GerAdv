//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { SMSAliceEmpty } from '../../../Models/SMSAlice';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { ISMSAlice } from '../../Interfaces/interface.SMSAlice';
import { SMSAliceService } from '../../Services/SMSAlice.service';
import { SMSAliceApi } from '../../Apis/ApiSMSAlice';
import { SMSAliceGridMobileComponent } from '../GridsMobile/SMSAlice';
import { SMSAliceGridDesktopComponent } from '../GridsDesktop/SMSAlice';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterSMSAlice } from '../../Filters/SMSAlice';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import SMSAliceWindow from './SMSAliceWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useSMSAliceList } from '../../Hooks/hookSMSAlice';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const SMSAliceGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const smsaliceService = useMemo(() => {
    return new SMSAliceService(
    new SMSAliceApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: smsalice, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useSMSAliceList(smsaliceService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedSMSAlice, setSelectedSMSAlice] = useState<ISMSAlice>(SMSAliceEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterSMSAlice | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterSMSAlice | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterSMSAlice);
};
// Handlers para o grid
const handleRowClick = (smsalice: ISMSAlice) => {
  setSelectedSMSAlice(smsalice);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedSMSAlice(SMSAliceEmpty());
  setShowInc(true);
};
const handleClose = () => {
  setShowInc(false);
};
const handleSuccess = () => {
  setShowInc(false);
  // O hook já escuta as notificações e recarrega automaticamente
};
const handleError = () => {
  setShowInc(false);
};
// Handlers para exclusão
const onDeleteClick = (e: any) => {
  const smsalice = e.dataItem;
  setDeleteId(smsalice.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await smsaliceService.deleteSMSAlice(deleteId);
      // O hook já escuta as notificações e recarrega automaticamente
    } catch (error) {
    console.error('Erro ao excluir:', error);
    setErrorMessage('Erro ao excluir o registro. Verifique se ele não está vinculado a outros registros.');
  } finally {
  setDeleteId(null);
  setIsModalOpen(false);
}
}
};
const cancelDelete = () => {
  setDeleteId(null);
  setIsModalOpen(false);
};
// Combinar erro do hook com erro local
const displayError = error || errorMessage;
useEffect(() => {
  const unsubscribe = subscribeToNotifications('*', (entity) => {
    reloadFilter();
  });
  return () => {
    unsubscribe();
  };
}, []);
return (
<>
<AppGridToolbar onAdd={handleAdd} />
{loading && (
  <LoadingSpinner />
  )}
  {isMobile ? (
    <SMSAliceGridMobileComponent
    data={smsalice}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <SMSAliceGridDesktopComponent
    data={smsalice}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <SMSAliceWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedSMSAlice={selectedSMSAlice}
    />
    <ConfirmationModal
    isOpen={isModalOpen}
    onConfirm={confirmDelete}
    onCancel={cancelDelete}
    message={`Deseja realmente excluir o registro?`}
    />
    <ErrorMessage
    mensagem={displayError}
    setErrorMessage={setErrorMessage}
    />
  </>
);
};
export default SMSAliceGrid;