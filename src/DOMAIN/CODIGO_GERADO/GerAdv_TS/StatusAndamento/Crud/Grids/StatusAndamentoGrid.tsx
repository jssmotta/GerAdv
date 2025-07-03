//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { StatusAndamentoEmpty } from '../../../Models/StatusAndamento';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IStatusAndamento } from '../../Interfaces/interface.StatusAndamento';
import { StatusAndamentoService } from '../../Services/StatusAndamento.service';
import { StatusAndamentoApi } from '../../Apis/ApiStatusAndamento';
import { StatusAndamentoGridMobileComponent } from '../GridsMobile/StatusAndamento';
import { StatusAndamentoGridDesktopComponent } from '../GridsDesktop/StatusAndamento';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterStatusAndamento } from '../../Filters/StatusAndamento';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import StatusAndamentoWindow from './StatusAndamentoWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useStatusAndamentoList } from '../../Hooks/hookStatusAndamento';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const StatusAndamentoGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const statusandamentoService = useMemo(() => {
    return new StatusAndamentoService(
    new StatusAndamentoApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: statusandamento, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useStatusAndamentoList(statusandamentoService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedStatusAndamento, setSelectedStatusAndamento] = useState<IStatusAndamento>(StatusAndamentoEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterStatusAndamento | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterStatusAndamento | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterStatusAndamento);
};
// Handlers para o grid
const handleRowClick = (statusandamento: IStatusAndamento) => {
  setSelectedStatusAndamento(statusandamento);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedStatusAndamento(StatusAndamentoEmpty());
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
  const statusandamento = e.dataItem;
  setDeleteId(statusandamento.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await statusandamentoService.deleteStatusAndamento(deleteId);
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
    <StatusAndamentoGridMobileComponent
    data={statusandamento}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <StatusAndamentoGridDesktopComponent
    data={statusandamento}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <StatusAndamentoWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedStatusAndamento={selectedStatusAndamento}
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
export default StatusAndamentoGrid;