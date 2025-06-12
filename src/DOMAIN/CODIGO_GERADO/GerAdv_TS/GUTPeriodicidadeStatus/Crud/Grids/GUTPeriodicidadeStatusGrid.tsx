//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { GUTPeriodicidadeStatusEmpty } from '../../../Models/GUTPeriodicidadeStatus';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IGUTPeriodicidadeStatus } from '../../Interfaces/interface.GUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusService } from '../../Services/GUTPeriodicidadeStatus.service';
import { GUTPeriodicidadeStatusApi } from '../../Apis/ApiGUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusGridMobileComponent } from '../GridsMobile/GUTPeriodicidadeStatus';
import { GUTPeriodicidadeStatusGridDesktopComponent } from '../GridsDesktop/GUTPeriodicidadeStatus';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterGUTPeriodicidadeStatus } from '../../Filters/GUTPeriodicidadeStatus';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import GUTPeriodicidadeStatusWindow from './GUTPeriodicidadeStatusWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useGUTPeriodicidadeStatusList } from '../../Hooks/hookGUTPeriodicidadeStatus';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const GUTPeriodicidadeStatusGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const gutperiodicidadestatusService = useMemo(() => {
    return new GUTPeriodicidadeStatusService(
    new GUTPeriodicidadeStatusApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: gutperiodicidadestatus, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useGUTPeriodicidadeStatusList(gutperiodicidadestatusService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedGUTPeriodicidadeStatus, setSelectedGUTPeriodicidadeStatus] = useState<IGUTPeriodicidadeStatus>(GUTPeriodicidadeStatusEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterGUTPeriodicidadeStatus | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterGUTPeriodicidadeStatus | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterGUTPeriodicidadeStatus);
};
// Handlers para o grid
const handleRowClick = (gutperiodicidadestatus: IGUTPeriodicidadeStatus) => {
  setSelectedGUTPeriodicidadeStatus(gutperiodicidadestatus);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedGUTPeriodicidadeStatus(GUTPeriodicidadeStatusEmpty());
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
  const gutperiodicidadestatus = e.dataItem;
  setDeleteId(gutperiodicidadestatus.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await gutperiodicidadestatusService.deleteGUTPeriodicidadeStatus(deleteId);
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
    <GUTPeriodicidadeStatusGridMobileComponent
    data={gutperiodicidadestatus}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <GUTPeriodicidadeStatusGridDesktopComponent
    data={gutperiodicidadestatus}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <GUTPeriodicidadeStatusWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedGUTPeriodicidadeStatus={selectedGUTPeriodicidadeStatus}
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
export default GUTPeriodicidadeStatusGrid;