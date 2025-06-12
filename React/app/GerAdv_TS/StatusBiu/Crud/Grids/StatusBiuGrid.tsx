//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { StatusBiuEmpty } from '../../../Models/StatusBiu';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IStatusBiu } from '../../Interfaces/interface.StatusBiu';
import { StatusBiuService } from '../../Services/StatusBiu.service';
import { StatusBiuApi } from '../../Apis/ApiStatusBiu';
import { StatusBiuGridMobileComponent } from '../GridsMobile/StatusBiu';
import { StatusBiuGridDesktopComponent } from '../GridsDesktop/StatusBiu';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterStatusBiu } from '../../Filters/StatusBiu';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import StatusBiuWindow from './StatusBiuWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useStatusBiuList } from '../../Hooks/hookStatusBiu';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const StatusBiuGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const statusbiuService = useMemo(() => {
    return new StatusBiuService(
    new StatusBiuApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: statusbiu, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useStatusBiuList(statusbiuService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedStatusBiu, setSelectedStatusBiu] = useState<IStatusBiu>(StatusBiuEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterStatusBiu | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterStatusBiu | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterStatusBiu);
};
// Handlers para o grid
const handleRowClick = (statusbiu: IStatusBiu) => {
  setSelectedStatusBiu(statusbiu);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedStatusBiu(StatusBiuEmpty());
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
  const statusbiu = e.dataItem;
  setDeleteId(statusbiu.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await statusbiuService.deleteStatusBiu(deleteId);
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
    <StatusBiuGridMobileComponent
    data={statusbiu}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <StatusBiuGridDesktopComponent
    data={statusbiu}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <StatusBiuWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedStatusBiu={selectedStatusBiu}
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
export default StatusBiuGrid;