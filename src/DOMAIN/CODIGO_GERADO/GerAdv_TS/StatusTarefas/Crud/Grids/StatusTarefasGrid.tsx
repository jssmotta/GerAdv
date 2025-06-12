//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { StatusTarefasEmpty } from '../../../Models/StatusTarefas';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IStatusTarefas } from '../../Interfaces/interface.StatusTarefas';
import { StatusTarefasService } from '../../Services/StatusTarefas.service';
import { StatusTarefasApi } from '../../Apis/ApiStatusTarefas';
import { StatusTarefasGridMobileComponent } from '../GridsMobile/StatusTarefas';
import { StatusTarefasGridDesktopComponent } from '../GridsDesktop/StatusTarefas';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterStatusTarefas } from '../../Filters/StatusTarefas';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import StatusTarefasWindow from './StatusTarefasWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useStatusTarefasList } from '../../Hooks/hookStatusTarefas';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { subscribeToNotifications } from '@/app/tools/NotifySystem';
const StatusTarefasGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const statustarefasService = useMemo(() => {
    return new StatusTarefasService(
    new StatusTarefasApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: statustarefas, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useStatusTarefasList(statustarefasService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedStatusTarefas, setSelectedStatusTarefas] = useState<IStatusTarefas>(StatusTarefasEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterStatusTarefas | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterStatusTarefas | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterStatusTarefas);
};
// Handlers para o grid
const handleRowClick = (statustarefas: IStatusTarefas) => {
  setSelectedStatusTarefas(statustarefas);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedStatusTarefas(StatusTarefasEmpty());
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
  const statustarefas = e.dataItem;
  setDeleteId(statustarefas.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await statustarefasService.deleteStatusTarefas(deleteId);
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
    <StatusTarefasGridMobileComponent
    data={statustarefas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <StatusTarefasGridDesktopComponent
    data={statustarefas}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <StatusTarefasWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedStatusTarefas={selectedStatusTarefas}
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
export default StatusTarefasGrid;