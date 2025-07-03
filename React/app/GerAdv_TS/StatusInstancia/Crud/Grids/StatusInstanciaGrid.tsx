//CrudGrid.tsx.txt
'use client';
import { AppGridToolbar } from '@/app/components/Cruds/GridToolbar';
import { useIsMobile } from '@/app/context/MobileContext';
import { useSystemContext } from '@/app/context/SystemContext';
import { StatusInstanciaEmpty } from '../../../Models/StatusInstancia';
import { useWindow } from '@/app/hooks/useWindows';
import { useRouter } from 'next/navigation';
import { useEffect, useMemo, useState } from 'react';
import { IStatusInstancia } from '../../Interfaces/interface.StatusInstancia';
import { StatusInstanciaService } from '../../Services/StatusInstancia.service';
import { StatusInstanciaApi } from '../../Apis/ApiStatusInstancia';
import { StatusInstanciaGridMobileComponent } from '../GridsMobile/StatusInstancia';
import { StatusInstanciaGridDesktopComponent } from '../GridsDesktop/StatusInstancia';
import { getParamFromUrl } from '@/app/tools/helpers';
import { FilterStatusInstancia } from '../../Filters/StatusInstancia';
import { ConfirmationModal } from '@/app/components/Cruds/ConfirmationModal';
import StatusInstanciaWindow from './StatusInstanciaWindow';
import ErrorMessage from '@/app/components/Cruds/ErrorMessage';
import { useStatusInstanciaList } from '../../Hooks/hookStatusInstancia';
import { LoadingSpinner } from '@/app/components/Cruds/LoadingSpinner';
import { NotifySystemActions, subscribeToNotifications } from '@/app/tools/NotifySystem';
const StatusInstanciaGrid: React.FC = () => {
  const { systemContext } = useSystemContext();
  const isMobile = useIsMobile();
  const dimensions = useWindow();

  // Service
  const statusinstanciaService = useMemo(() => {
    return new StatusInstanciaService(
    new StatusInstanciaApi(systemContext?.Uri ?? '', systemContext?.Token ?? '')
  );
}, [systemContext?.Uri, systemContext?.Token]);
// Hook customizado para lista
const {
  data: statusinstancia, 
  loading, 
  error, 
  fetchData, 
  refreshData
} = useStatusInstanciaList(statusinstanciaService);
// Estados locais para UI
const [showInc, setShowInc] = useState(false);
const [selectedStatusInstancia, setSelectedStatusInstancia] = useState<IStatusInstancia>(StatusInstanciaEmpty());
const [selectedId, setSelectedId] = useState<number | null>(null);
const [isModalOpen, setIsModalOpen] = useState(false);
const [deleteId, setDeleteId] = useState<number | null>(null);
const [errorMessage, setErrorMessage] = useState<string | null>(null);
const [currFilter, setCurrFilter] = useState<FilterStatusInstancia | undefined | null>(null);

const reloadFilter = () => {
  handleFetchWithFilter();
};
useEffect(() => { // Ref: FILTER_FETCH2
  if (!showInc) {
    handleFetchWithFilter();
  }
}, [showInc]);
// Buscar dados com filtro
const handleFetchWithFilter = async (filtro?: FilterStatusInstancia | undefined | null) => {
  setCurrFilter(filtro);
  await fetchData(filtro ?? {} as FilterStatusInstancia);
};
// Handlers para o grid
const handleRowClick = (statusinstancia: IStatusInstancia) => {
  setSelectedStatusInstancia(statusinstancia);
  setShowInc(true);
};
const handleAdd = () => {
  setSelectedStatusInstancia(StatusInstanciaEmpty());
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
  const statusinstancia = e.dataItem;
  setDeleteId(statusinstancia.id);
  setIsModalOpen(true);
};
const confirmDelete = async () => {
  if (deleteId !== null) {
    try {
      await statusinstanciaService.deleteStatusInstancia(deleteId);
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
    <StatusInstanciaGridMobileComponent
    data={statusinstancia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    ) : (
    <StatusInstanciaGridDesktopComponent
    data={statusinstancia}
    onRowClick={handleRowClick}
    onDeleteClick={onDeleteClick}
    setSelectedId={setSelectedId}

    />
    )}

    <StatusInstanciaWindow
    isOpen={showInc}
    onClose={handleClose}
    dimensions={dimensions}
    onSuccess={handleSuccess}
    onError={handleError}
    selectedStatusInstancia={selectedStatusInstancia}
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
export default StatusInstanciaGrid;