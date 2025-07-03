//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { PenhoraStatusEmpty } from '../../../Models/PenhoraStatus';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IPenhoraStatus } from '../../Interfaces/interface.PenhoraStatus';
import { PenhoraStatusService } from '../../Services/PenhoraStatus.service';
import { PenhoraStatusApi } from '../../Apis/ApiPenhoraStatus';
import { PenhoraStatusGridMobileComponent } from '../GridsMobile/PenhoraStatus';
import { PenhoraStatusGridDesktopComponent } from '../GridsDesktop/PenhoraStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterPenhoraStatus } from '../../Filters/PenhoraStatus';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import PenhoraStatusWindow from './PenhoraStatusWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { usePenhoraStatusList } from '../../Hooks/hookPenhoraStatus';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const PenhoraStatusGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const penhorastatusService = useMemo(() => {
    return new PenhoraStatusService(
    new PenhoraStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: penhorastatus, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = usePenhoraStatusList(penhorastatusService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedPenhoraStatus, setSelectedPenhoraStatus] = useState<IPenhoraStatus>(PenhoraStatusEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterPenhoraStatus | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterPenhoraStatus | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterPenhoraStatus);
};
// Handlers para o grid
const handleRowClick = (penhorastatus: IPenhoraStatus) => {
  setSelectedPenhoraStatus(penhorastatus);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedPenhoraStatus(PenhoraStatusEmpty());
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
  const penhorastatus = e.dataItem;
  setDeleteId(penhorastatus.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await penhorastatusService.deletePenhoraStatus(deleteId);
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
    if (entity.action == NotifySystemActions.ERROR) {
      return;
    }
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
    <PenhoraStatusGridMobileComponent
    data={penhorastatus}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <PenhoraStatusGridDesktopComponent
    data={penhorastatus}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <PenhoraStatusWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedPenhoraStatus={selectedPenhoraStatus}
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
export default PenhoraStatusGrid;