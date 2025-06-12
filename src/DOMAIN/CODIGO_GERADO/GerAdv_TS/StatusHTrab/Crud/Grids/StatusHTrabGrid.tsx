//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { StatusHTrabEmpty } from '../../../Models/StatusHTrab';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IStatusHTrab } from '../../Interfaces/interface.StatusHTrab';
import { StatusHTrabService } from '../../Services/StatusHTrab.service';
import { StatusHTrabApi } from '../../Apis/ApiStatusHTrab';
import { StatusHTrabGridMobileComponent } from '../GridsMobile/StatusHTrab';
import { StatusHTrabGridDesktopComponent } from '../GridsDesktop/StatusHTrab';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterStatusHTrab } from '../../Filters/StatusHTrab';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import StatusHTrabWindow from './StatusHTrabWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useStatusHTrabList } from '../../Hooks/hookStatusHTrab';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const StatusHTrabGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const statushtrabService = useMemo(() => {
    return new StatusHTrabService(
    new StatusHTrabApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: statushtrab, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useStatusHTrabList(statushtrabService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedStatusHTrab, setSelectedStatusHTrab] = useState<IStatusHTrab>(StatusHTrabEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterStatusHTrab | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterStatusHTrab | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterStatusHTrab);
};
// Handlers para o grid
const handleRowClick = (statushtrab: IStatusHTrab) => {
  setSelectedStatusHTrab(statushtrab);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedStatusHTrab(StatusHTrabEmpty());
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
  const statushtrab = e.dataItem;
  setDeleteId(statushtrab.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await statushtrabService.deleteStatusHTrab(deleteId);
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
    <StatusHTrabGridMobileComponent
    data={statushtrab}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <StatusHTrabGridDesktopComponent
    data={statushtrab}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <StatusHTrabWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedStatusHTrab={selectedStatusHTrab}
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
export default StatusHTrabGrid;